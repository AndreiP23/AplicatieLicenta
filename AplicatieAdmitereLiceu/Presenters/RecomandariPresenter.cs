using LicentaNou2.Models;
using LicentaNou2.Repositories;
using LicentaNou2.Util;
using LicentaNou2.Views.Interfaces;
using Microsoft.ML;
using Microsoft.ML.Data;
using System.Text.RegularExpressions;

namespace LicentaNou2.Presenters
{
    public class RecomandariPresenter
    {
        private IRecomandariView _recomandariView { get; set; }
        private IRecomandariRepository _recomandariRepository { get; set; }
        private IMLAdmissionLogic _mlAdmissionLogic { get; set; }

        private List<string> infoForUsers = Constants.InfoForUsers;

        public RecomandariPresenter(IRecomandariRepository repo, IMLAdmissionLogic mlAdmissionLogic)
        {
            _recomandariRepository = repo;
            _mlAdmissionLogic = mlAdmissionLogic;
        }
        public void SetView(IRecomandariView view)
        {
            _recomandariView = view;
        }
        public RecomandareModel FillDataInModel()
        {
            Verificari();
            var data = new RecomandareModel();
            data.MedieGenerala = Convert.ToDouble(_recomandariView.NumMGenerala.Value);
            data.NotaRomana = Convert.ToDouble(_recomandariView.NumNRom.Value);
            data.NotaMate = Convert.ToDouble(_recomandariView.NumNMate.Value);
            data.Liceu = _recomandariView.CmbLiceu.Text;
            data.Profil = _recomandariView.CmbProfil.Text;
            data.Categorie = _recomandariView.CmbCategorie.SelectedIndex;
            data.Limba = _recomandariView.CmbLimba.Text;
            return data;
        }
        private void Verificari()
        {
            if (_recomandariView.CmbLiceu.SelectedIndex == -1 && !string.IsNullOrEmpty(_recomandariView.CmbLiceu.Text))
            {
                throw new ArgumentException("Nu a fost selectat liceul.");
            }
            if (_recomandariView.CmbProfil.SelectedIndex == -1 && !string.IsNullOrEmpty(_recomandariView.CmbProfil.Text))
            {
                throw new ArgumentException("Nu a fost selectat proilul.");
            }
            if (_recomandariView.CmbCategorie.SelectedIndex == -1 && !string.IsNullOrEmpty(_recomandariView.CmbCategorie.Text))
            {
                throw new ArgumentException("Nu a fost selectata categoria.");
            }
            if (_recomandariView.NumMGenerala.Value == 0)
            {
                throw new ArgumentException("Nu a fost selectata media generala.");
            }
            if (_recomandariView.NumNMate.Value == 0)
            {
                throw new ArgumentException("Nu a fost selectata nota la matematica.");
            }
            if (_recomandariView.NumNRom.Value == 0)
            {
                throw new ArgumentException("Nu a fost selectata nota la romana.");
            }

        }
        static string RemoveDiacritics(string text)
        {
            string normalizedText = text.Normalize(System.Text.NormalizationForm.FormD);
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string withoutDiacritics = regex.Replace(normalizedText, String.Empty);

            withoutDiacritics = withoutDiacritics.Replace('ă', 'a')
                                                 .Replace('â', 'a')
                                                 .Replace('î', 'i')
                                                 .Replace('ș', 's')
                                                 .Replace('ş', 's')
                                                 .Replace('ț', 't')
                                                 .Replace('ţ', 't')
                                                 .Replace('Ă', 'A')
                                                 .Replace('Â', 'A')
                                                 .Replace('Î', 'I')
                                                 .Replace('Ș', 'S')
                                                 .Replace('Ş', 'S')
                                                 .Replace('Ț', 'T')
                                                 .Replace('Ţ', 'T');

            return withoutDiacritics;
        }
        public async Task Load()
        {
            try
            {
                await PopulateLicee();
                await PopulateProfile();
                await PopulateLimba();
                PopulateCateg();
                FillInfoPanels();
                await TaskGetModelReady();
            }
            catch (Exception ex)
            {
                _recomandariView.ShowMessageBox(ex.Message);
            }
        }
        private async Task TaskGetModelReady()
        {
             await _mlAdmissionLogic.GetModelAsync();
        }
        public async Task PopulateLicee()
        {
            List<string> result = await _recomandariRepository.PopulateLicee();
            if (result.Count != 0)
            {
                for(int i = 0; i<= result.Count - 1; i++)
                {
                    result[i] = RemoveDiacritics(result[i]);
                }
                _recomandariView.CmbLiceu.DataSource = result;
                _recomandariView.CmbLiceu.SelectedIndex = -1;
            }
        }
        private void FillInfoPanels()
        {
            _recomandariView.LblInfo.Text = Constants.MsgInfo1;
            _recomandariView.PanInfo1.Visible = true;
            _recomandariView.PanInfo1.BringToFront();
        }
        public async Task PopulateProfile()
        {
            List<string> result = await _recomandariRepository.PopulateProfile();
            if (result.Count != 0)
            {
                _recomandariView.CmbProfil.DataSource = result;
                _recomandariView.CmbProfil.SelectedIndex = -1;
            }
        }
        public void PopulateCateg()
        {
            List<string> categ = new List<string>
            {
                "A - Medii intre 9 si 10",
                "B - Medii intre 8 si 9",
                "C - Medii intre 7 si 8",
                "D - Medii intre 6 si 7",
                "F - Medii sub 6"
            };

            _recomandariView.CmbCategorie.DataSource = categ;
            _recomandariView.CmbCategorie.SelectedIndex = -1;
        }
        public async Task PopulateLimba()
        {
            List<string> result = await _recomandariRepository.PopulateLimba();
            if (result.Count != 0)
            {
                _recomandariView.CmbLimba.DataSource = result;
                _recomandariView.CmbLimba.SelectedIndex = -1;
            }
        }
        public void NextInfo()
        {
            var rnd = new Random();
            if(infoForUsers.Any())
                _recomandariView.LblInfo.Text = infoForUsers[rnd.Next(infoForUsers.Count)];
        }
        public async Task ResetForm()
        {
            _recomandariView.NumMGenerala.Value = 0;
            _recomandariView.NumNMate.Value = 0;
            _recomandariView.NumNRom.Value = 0;
            _recomandariView.CmbLiceu.SelectedIndex = -1;
            _recomandariView.CmbLiceu.SelectedText = string.Empty;
            _recomandariView.CmbLiceu.SelectedItem = null;
            _recomandariView.CmbLimba.SelectedIndex = -1;
            _recomandariView.CmbLimba.SelectedText = string.Empty;
            _recomandariView.CmbLimba.SelectedItem = null;
            _recomandariView.CmbCategorie.SelectedIndex = -1;
            _recomandariView.CmbCategorie.SelectedText = string.Empty;
            _recomandariView.CmbCategorie.SelectedItem = null;
            _recomandariView.CmbProfil.SelectedIndex = -1;
            _recomandariView.CmbProfil.SelectedText = string.Empty;
            _recomandariView.CmbProfil.SelectedItem = null;
        }
        public ITransformer ReturnModelTrained()
        {
            return _mlAdmissionLogic.GetTransf();
        }
        public async Task TESTPred()
        {
            try
            {
                MLAdmissionModel mLAdmissionModel = new MLAdmissionModel
                {
                    Liceu = "COLEGIUL TEHNOLOGIC VIACESLAV HARNAJ",
                    Profil = "Agricultura",
                    UltimaMedie = (float)4.67,
                    MedieAnPrecedent = (float)5.25,
                    Medie2021 = (float)5.21,
                    Locuri = 90,
                    ClasaProfil = "F",
                    Judet = "MUNICIUPIUL BUCURESTI",
                    MedieAdmitere = (float)5.20
                };

                // Ensure data preprocessing is consistent with the training process
                var preprocessedData = _mlAdmissionLogic.PreprocessData(mLAdmissionModel);

                //// Define schema for the prediction
                //var schemaDefinition = SchemaDefinition.Create(typeof(PreprocessedData));
                //schemaDefinition["Features"].ColumnType = new VectorDataViewType(NumberDataViewType.Single, preprocessedData.Features.Length);

                //// Create a prediction engine
                //var mlContext = new MLContext();
                //var predictionEngine = mlContext.Model.CreatePredictionEngine<PreprocessedData, MLAdmissionPrediction>(_mlAdmissionLogic.GetTransf(), inputSchemaDefinition: schemaDefinition);

                // Use the prediction engine to get the raw prediction
                var result = _mlAdmissionLogic.PredictAdmission(mLAdmissionModel);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
