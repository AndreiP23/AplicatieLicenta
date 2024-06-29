using Accord.Math;
using LicentaNou2.Models;
using LicentaNou2.Repositories;
using LicentaNou2.Util;
using LicentaNou2.Views.Interfaces;
using Microsoft.ML;
using System.Text.RegularExpressions;

namespace LicentaNou2.Presenters
{
    public class DetaliiRecomandarePresenter
    {
        private MLContext _mlContext;
        private ITransformer _model;
        public DetaliiRecomandarePresenter(IDetaliiRecomandareRepository detaliiRepo)
        {
            _detaliiRepo = detaliiRepo;
        }
        private IDetaliiRecomandareView _detaliiRecomView { get; set; }
        private IDetaliiRecomandareRepository _detaliiRepo { get; set; }
        public void SetView(IDetaliiRecomandareView view)
        {
            _detaliiRecomView = view;
        }
        public async Task Load(RecomandareModel data)
        {
            try
            {
                VerificareCompletareDate(data);
                var results = await LoadPrimaZona(data);
                await LoadZona2(data, results);
                await LoadOptiuni(data);
            }
            catch (Exception ex)
            {
                _detaliiRecomView.ShowMessageBox(ex.Message);
            }
        }
        private async Task<List<int>> LoadPrimaZona(RecomandareModel data)
        {
            List<int> result = await _detaliiRepo.LoadPrimaZonaIntSup(data.NotaRomana, data.NotaMate, data.MedieGenerala);
            List<int> result2 = await _detaliiRepo.LoadPrimaZonaIntrari();
            double prog = (double)result[0] / Convert.ToInt32(result2[0]) * 100;
            _detaliiRecomView.ProgSituatie.DataPoints.Clear();
            _detaliiRecomView.ProgSituatie.DataPoints.Add("Candidati cu medie superioara", Math.Round(100 - prog, 2));
            _detaliiRecomView.ProgSituatie.DataPoints.Add("Candidati nu medie inferioara", Math.Round(prog, 2));
            _detaliiRecomView.LblAdmis.Text = Util.Constants.MsgAdmis;
            return result;
        }

        private async Task LoadZona2(RecomandareModel data, List<int> resultsMEV)
        {
            List<Diff> result = await _detaliiRepo.GetLiceeProfil(data.Profil, data.Categorie);

            LinearRegression regr = new LinearRegression();
            double sansa = regr.PredictNextValue(result.Select(x => x.value).ToArray());

            sansa = await _detaliiRepo.GetSpecificUMA(data.Liceu, data.Limba, data.Profil) + sansa;

            sansa = regr.EstimateAdmissionProbability(data.MedieGenerala, sansa);
            _detaliiRecomView.ProgSansaSituatie.Value = (int)Math.Round(sansa * 100);
            _detaliiRecomView.ProgSansaSituatie.Text = Math.Round(sansa).ToString();

            _detaliiRecomView.LblSituatie.Text = Util.Constants.MsgSituatie;
        }

        private async Task LoadOptiuni(RecomandareModel data)
        {
            var limba = data.Limba;
            var profil = data.Profil;

            var an = DateTime.Parse("2023-01-01").ToString("yyyy-MM-dd");
            var anBefore = DateTime.Parse("2021-01-01").ToString("yyyy-MM-dd");

            var dataActuala = await _detaliiRepo.GetAvgAnualLimbaSiProfil(limba, profil, an);
            var dataBefore = await _detaliiRepo.GetAvgAnualLimbaSiProfil(limba, profil, anBefore);

            double diff = Math.Round(dataActuala - dataBefore, 2);

            List<LiceuViewModel> licee = await _detaliiRepo.GetLiceeAprpDeMedie(limba, profil, data.MedieGenerala - diff, data.MedieGenerala + diff);
            _detaliiRecomView.DgvOptiuni.DataSource = licee;

            _detaliiRecomView.LblOptiuni.Text = Util.Constants.MsgOptiune;
        }
        public void VerificareCompletareDate(RecomandareModel data)
        {
            if (data.MedieGenerala == 0)
            {
                throw new ArgumentException("Trebuie sa completati campul Medie Generala pentru a folosi functionalitatea.");
            }
            if (string.IsNullOrEmpty(data.Liceu))
            {
                throw new ArgumentException("Trebuie sa completati campul Liceu pentru a folosi functionalitatea.");
            }
            if (string.IsNullOrEmpty(data.Profil) && data.Categorie == -1)
            {
                throw new ArgumentException("Trebuie sa completati campul Profil pentru a folosi functionalitatea.");
            }
            if (string.IsNullOrEmpty(data.Limba))
            {
                throw new ArgumentException("Trebuie sa completati campul Limba pentru a folosi functionalitatea.");
            }
            if ((data.NotaRomana + data.NotaMate) / 2 != data.MedieGenerala)
            {
                throw new ArgumentException("Valorile numerice ale notelor nu sunt corecte.");
            }
        }
        public void SetUpMLPredict(ITransformer transformer)
        {
            _model = transformer;
            _mlContext = new MLContext();
        }
        public MLAdmissionPrediction PredictAdmission(MLAdmissionModel inputData)
        {
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<MLAdmissionModel, MLAdmissionPrediction>(_model);

            return predictionEngine.Predict(inputData);
        }
    }
}
