using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Presenters
{
    internal class CalibrationLogic
    {
        private ITransformer _calibrationTransformer;
        private MLContext _mlContext;

        public CalibrationLogic(MLContext mlContext)
        {
            _mlContext = mlContext;
        }

        public void FitCalibrationModel(IDataView validationData)
        {
            // Assume validationData has columns: Features, Label
            var calibrationPipeline = _mlContext.BinaryClassification.Trainers.LbfgsLogisticRegression(labelColumnName: "Label");

            _calibrationTransformer = calibrationPipeline.Fit(validationData);
        }
        public float CalibrateProbability(float predictedProbability)
        {
            // Create a single row data view for the predicted probability
            var singleData = new[] { new PreprocessedData { Features = new float[] { predictedProbability } } };
            var singleDataView = _mlContext.Data.LoadFromEnumerable(singleData);

            // Transform the single row data view
            var transformedData = _calibrationTransformer.Transform(singleDataView);

            // Extract the calibrated probability
            var calibratedProbability = _mlContext.Data.CreateEnumerable<CalibratedOutput>(transformedData, reuseRowObject: false).First().Score;

            return calibratedProbability;
        }

        private class CalibratedOutput
        {
            public float Score { get; set; }
        }
    }
}
