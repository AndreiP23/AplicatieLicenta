using LicentaNou2.Models;
using LicentaNou2.Repositories;
using LicentaNou2.Util;
using LicentaNou2.Views.Interfaces;
using System.ComponentModel;
using System.Reflection;
using static LicentaNou2.FrmMain;

namespace LicentaNou2.Presenters
{
    public class MainPresenter
    {
        private IMainView mainView { get; set; }
        private IMainRepository _mainRepo { get; set; }
        public int anSelectat = 2021;
        public MainPresenter(IMainRepository mainRepo)
        {
            _mainRepo = mainRepo;
        }
        public void SetView(IMainView view)
        {
            mainView = view;
        }
        public async Task PopulareProfile()
        {
            var profile = await _mainRepo.GetProfile();
            int i = 0;
            foreach (Profil? profil in profile)
            {
                profil.Index = i;
                i++;
            }
            mainView.CmbProfile.DataSource = profile;
            mainView.CmbProfile.DisplayMember = "Nume";
            mainView.CmbProfile.ValueMember = "Index";

        }
        public async Task PopulareMainInfo()
        {
            mainView.GTBtn2021.FillColor = Color.Pink;
            await PopulareDGVTopLicee(2021);
            await PopulareProfile();
            await FillChart();
        }
        public async Task PopulareDGVTopLicee(int an)
        {
            var result = await _mainRepo.PopulareDGVTopLicee(an);
            if (result != null)
            {
                var lista = new List<LiceuViewModel>();
                foreach (var item in result)
                {
                    lista.Add(new LiceuViewModel() { Nume = item.I, Specializare = item.SP, Media = item.UM, NumarLocuri = item.NLT });
                }
                mainView.GDGVLicee.DataSource = new BindingList<LiceuViewModel>(lista);
            }
        }
        public async Task StatLiceeByANAndProfil(int an, string profil)
        {
            var result = await _mainRepo.StatLiceeByANAndProfil(an, profil);
            var result2 = await _mainRepo.StatLiceeByANAndProfilInt(an, profil);
            double prog = (double)result.FirstOrDefault().NrLicee / Convert.ToInt32(result2) * 100;
            mainView.DatasetProfilePlacintar.DataPoints.Clear();
            mainView.DatasetProfilePlacintar.DataPoints.Add("Restul de Profile", 100 - prog);
            mainView.DatasetProfilePlacintar.DataPoints.Add(profil, prog);
            mainView.TxtProfilDet.Text = string.Format(Constants.MsgInfoLiceu, profil, an, result[0].NrLicee, Math.Round(result[0].MedieMax, 2), Math.Round(result[0].MedieMin, 2), Math.Round(result[0].AvgDif, 2), Math.Round(result[0].MedieLocuri, 2));
        }

        public async Task Search()
        {
            if (string.IsNullOrEmpty(mainView.TxtSearch.Text))
            {
                mainView.ShowMessageBox("Va rugam completati o valoare in campul alaturat.");
                return;
            }
            var value = mainView.TxtSearch.Text;
            bool IsNumeric = double.TryParse(value, out _);
            var lista = new List<LiceuViewModel>();
            List<ModelRezLiceu> result = await _mainRepo.Search(value, anSelectat);
            if (result != null)
            {
                foreach (var item in result)
                {
                    lista.Add(new LiceuViewModel() { Nume = item.I, Specializare = item.SP, Media = item.UM, NumarLocuri = item.NLT });
                }
            }
            mainView.GDGVLicee.DataSource = new BindingList<LiceuViewModel>(lista);
        }
        public async Task FillChart()
        {
            var result = await _mainRepo.FillChart(anSelectat);
            Type type = typeof(ChartModel);
            PropertyInfo[] properties = type.GetProperties();
            mainView.BarDatasetLicee.DataPoints.Clear();
            foreach (var property in properties)
            {
                object Value = property.GetValue(result);
                string[] parts = property.Name.Split("Categoria");
                mainView.BarDatasetLicee.DataPoints.Add($"Categoria {parts[1]} - {Convert.ToDouble(Value)}", Convert.ToDouble(Value));
            }
        }
    }
}
