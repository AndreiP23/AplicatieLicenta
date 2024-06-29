using Accord.MachineLearning;
using LicentaNou2.Models;
using LicentaNou2.Repositories;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LicentaNou2.Presenters.MLAdmissionLogic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LicentaNou2.Presenters
{
    public interface IMLAdmissionLogic
    {
        MLAdmissionPrediction PredictAdmission(MLAdmissionModel inputData);
        Task GetModelAsync();
        MLAdmissionModel PreprocessData(MLAdmissionModel model);
        ITransformer GetTransf();
    }

    // Define a class to correspond to the label column
    public class LabelData
    {
        public bool Label { get; set; }
    }
    public class MLAdmissionLogic : IMLAdmissionLogic
    {
        private readonly IMLAdmissionRepository _mlAdmissionRepository;
        private readonly MLContext _mlContext;
        private ITransformer _model;
        private Lazy<Task<ITransformer>> _modelInitializer;
        public MLAdmissionLogic(IMLAdmissionRepository mlAdmissionRepository)
        {
            _mlAdmissionRepository = mlAdmissionRepository;
            _mlContext = new MLContext(seed: 0);
            _modelInitializer = new Lazy<Task<ITransformer>>(() => TrainModel());
        }
        public async Task GetModelAsync()
        {
            _model = await _modelInitializer.Value;
        }
        public ITransformer GetTransf()
        {
            return _model;
        }
        public async Task<IDataView> LoadData(MLContext mlContext)
        {
            var data = await _mlAdmissionRepository.GetDateForTraining();

            // Convert to IDataView
            IDataView dataView = mlContext.Data.LoadFromEnumerable(data);
            return dataView;
        }

        public async Task<ITransformer> TrainModel()
        {
            // Define a synthetic threshold for the target variable
            var context = _mlContext;

            // Load data
            var data = await LoadData(_mlContext);

            // Calculate the lowest admitted grade
            var dataEnumerable = context.Data.CreateEnumerable<MLAdmissionModel>(data, reuseRowObject: false).ToList();
            float lowestAdmittedGrade = dataEnumerable.Min(d => d.MedieAdmitere);

            // Create synthetic non-admitted data
            var syntheticData = dataEnumerable.Select(d => new MLAdmissionModel
            {
                MedieAdmitere = d.MedieAdmitere - 1.0f, // Reduce grade to ensure non-admission
                Locuri = d.Locuri,
                UltimaMedie = d.UltimaMedie,
                MedieAnPrecedent = d.MedieAnPrecedent,
                Medie2021 = d.Medie2021,
                Judet = d.Judet,
                Liceu = d.Liceu,
                Profil = d.Profil,
                ClasaProfil = d.ClasaProfil,
                IsAdmitted = false // Mark as not admitted
            }).ToList();

            // Combine real and synthetic data
            var combinedData = dataEnumerable.Select(d => new MLAdmissionModel
            {
                MedieAdmitere = d.MedieAdmitere,
                Locuri = d.Locuri,
                UltimaMedie = d.UltimaMedie,
                MedieAnPrecedent = d.MedieAnPrecedent,
                Medie2021 = d.Medie2021,
                Judet = d.Judet,
                Liceu = d.Liceu,
                Profil = d.Profil,
                ClasaProfil = d.ClasaProfil,
                IsAdmitted = true // Mark as admitted
            }).Concat(syntheticData);

            var transformedData = context.Data.LoadFromEnumerable(combinedData);

            // Split data into training and testing sets
            var dataSplit = context.Data.TrainTestSplit(transformedData, testFraction: 0.2);
            var trainData = dataSplit.TrainSet;
            var testData = dataSplit.TestSet;

            // Define the pipeline with imputation for missing values
            var pipeline = context.Transforms.Categorical.OneHotEncoding(new[]
                {
                    new InputOutputColumnPair("Judet", "Judet"),
                    new InputOutputColumnPair("Liceu", "Liceu"),
                    new InputOutputColumnPair("Profil", "Profil"),
                    new InputOutputColumnPair("ClasaProfil", "ClasaProfil")
                })
                .Append(context.Transforms.Concatenate("Features", "MedieAdmitere", "Locuri", "UltimaMedie", "MedieAnPrecedent", "Medie2021",
                    "Judet", "Liceu", "Profil", "ClasaProfil"))
                .Append(context.Transforms.ReplaceMissingValues("Features", replacementMode: MissingValueReplacingEstimator.ReplacementMode.Mean))
                .Append(context.Transforms.NormalizeMinMax("Features"))
                .Append(context.BinaryClassification.Trainers.LbfgsLogisticRegression(labelColumnName: "IsAdmitted"));

            // Train the model
            var model = pipeline.Fit(trainData);

            // Evaluate the model on the test data
            var predictions = model.Transform(testData);
            var metrics = context.BinaryClassification.Evaluate(predictions, labelColumnName: "IsAdmitted");

            // Print the accuracy metrics
            Debug.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
            Debug.WriteLine($"AUC: {metrics.AreaUnderRocCurve:P2}");
            Debug.WriteLine($"F1 Score: {metrics.F1Score:P2}");

            Debug.WriteLine("Model training and saving complete.");

            return model;
        }
        public void EvaluateModel(MLContext mlContext, ITransformer model, IDataView testSet)
        {
            var predictions = model.Transform(testSet);
            var metrics = _mlContext.BinaryClassification.Evaluate(predictions, "Admis");

            Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
        }
        public MLAdmissionPrediction PredictAdmission(MLAdmissionModel inputData)
        {
            // Create a prediction engine
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<MLAdmissionModel, MLAdmissionPrediction>(_model);
            // Make a prediction
            return predictionEngine.Predict(inputData);
        }
        public MLAdmissionModel PreprocessData(MLAdmissionModel model)
        {
            // Create a new MLContext
            MLContext mlContext = new MLContext();

            // Convert the input model to an IDataView
            var singleDataView = mlContext.Data.LoadFromEnumerable(new[] { model });

            // Log the initial data
            LogDataView(singleDataView, "Initial Data");

            // Define the pipeline for one-hot encoding
            var oneHotPipeline = mlContext.Transforms.Categorical.OneHotEncoding(new[]
            {
                new InputOutputColumnPair("JudetEncoded", "Judet"),
                new InputOutputColumnPair("LiceuEncoded", "Liceu"),
                new InputOutputColumnPair("ProfilEncoded", "Profil"),
                new InputOutputColumnPair("ClasaProfilEncoded", "ClasaProfil")
             });

            // Apply OneHotEncoding transformation and log the intermediate result
            var oneHotEncodedData = oneHotPipeline.Fit(singleDataView).Transform(singleDataView);
            LogDataView(oneHotEncodedData, "OneHotEncoded Data");

            // Concatenate features
            var concatenatePipeline = mlContext.Transforms.Concatenate("Features",
                "MedieAdmitere",
                "Locuri",
                "UltimaMedie",
                "MedieAnPrecedent",
                "Medie2021",
                "JudetEncoded",
                "LiceuEncoded",
                "ProfilEncoded",
                "ClasaProfilEncoded");

            var concatenatedData = concatenatePipeline.Fit(oneHotEncodedData).Transform(oneHotEncodedData);
            LogDataView(concatenatedData, "Concatenated Data");

            // Replace missing values and log the intermediate result
            var replaceMissingPipeline = mlContext.Transforms.ReplaceMissingValues("Features", replacementMode: MissingValueReplacingEstimator.ReplacementMode.Mean);
            var replacedMissingData = replaceMissingPipeline.Fit(concatenatedData).Transform(concatenatedData);
            LogDataView(replacedMissingData, "Replaced Missing Values Data");

            // Normalize features and log the final transformed result
            var normalizePipeline = mlContext.Transforms.NormalizeMinMax("Features");
            var normalizedData = normalizePipeline.Fit(replacedMissingData).Transform(replacedMissingData);
            LogDataView(normalizedData, "Normalized Data");

            // Extract the preprocessed data
            var preprocessedData = mlContext.Data.CreateEnumerable<MLAdmissionModel>(normalizedData, reuseRowObject: false).First();

            return preprocessedData;
        }
        private void LogDataView(IDataView dataView, string title)
        {
            Debug.WriteLine($"--- {title} ---");
            var preview = dataView.Preview();
            foreach (var row in preview.RowView)
            {
                foreach (var kvp in row.Values)
                {
                    Debug.Write($"{kvp.Key}: {kvp.Value} | ");
                }
                Debug.WriteLine(" ");
            }
            Debug.WriteLine($"--- End of {title} ---");
        }
    }
    public class PreprocessedData
    {
        [VectorType(15)]  // Adjust the size based on the actual number of features
        public float[] Features { get; set; }
    }
}
