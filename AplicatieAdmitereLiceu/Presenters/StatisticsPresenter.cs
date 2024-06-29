using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using Guna.Charts.WinForms;
using LicentaNou2.Models;
using LicentaNou2.Repositories;
using LicentaNou2.Util;
using LicentaNou2.Views.Interfaces;
using MathNet.Numerics;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static LicentaNou2.FrmMain;

namespace LicentaNou2.Presenters
{
    public class StatisticsPresenter
    {
        private IStatisticsView _statisticsView;
        private IStatisticsRepository _statisticsRepository;
        private IRecomandariRepository _recomandariRepository;
        public StatisticsPresenter(IStatisticsRepository statisticsRepository, IRecomandariRepository recomandariRepository)
        {
            _statisticsRepository = statisticsRepository;
            _recomandariRepository = recomandariRepository;
        }

        public void SetView(IStatisticsView statisticsView)
        {
            _statisticsView = statisticsView;
        }
        public async Task Load()
        {
            SetUpGMap();
            var data = await _statisticsRepository.GetLicee();
            _statisticsView.CmbLiceu.DataSource = data.Select(x => x.Liceu).ToList();
            _statisticsView.CmbLiceu.SelectedIndex = -1;

        }
        public async Task FillInfo()
        {
            var liceu = _statisticsView.CmbLiceu.Text;
            string pattern = @"[^\w\s]";
            string replacement = "";
            string whitespacePattern = @"\s+";
            string whitespaceReplacement = "";

            string result = Regex.Replace(liceu, pattern, replacement);
            result = Regex.Replace(result, whitespacePattern, whitespaceReplacement);
            result = result.Trim().ToUpper();

            result = result.Replace('Ă', 'A')
              .Replace('Â', 'A')
              .Replace('Î', 'I')
              .Replace('Ș', 'S')
              .Replace('Ş', 'S')
              .Replace('Ț', 'T')
              .Replace('Ţ', 'T');

            try
            {
                await FillChartProfil(result);
                await FillChartScoli(result);
                await DisplayLocation(liceu);
            }
            catch (Exception ex)
            {
                _statisticsView.ShowMessageBox(ex.Message);
            }

            _statisticsView.PanLoadImg.Visible = false;
            _statisticsView.PanLoadImg.SendToBack();

        }
        private async Task FillChartProfil(string liceu)
        {
            var profilList = await _statisticsRepository.GetAvgProfil(liceu);
            var profil = profilList.First();

            if (_statisticsView.DSRadarProfil.DataPointCount > 0)
            {
                _statisticsView.DSRadarProfil.DataPoints.Clear();
            }
            _statisticsView.DSRadarProfil.DataPoints.Add(new LPoint("Media absoluta maxima", ConvertToDouble(profil.MABS)));
            _statisticsView.DSRadarProfil.DataPoints.Add(new LPoint("Media evaluare", ConvertToDouble(profil.MEV)));
            _statisticsView.DSRadarProfil.DataPoints.Add(new LPoint("Media admitere", ConvertToDouble(profil.MADM)));
            _statisticsView.DSRadarProfil.DataPoints.Add(new LPoint("Nota romana", ConvertToDouble(profil.NRO)));
            _statisticsView.DSRadarProfil.DataPoints.Add(new LPoint("Nota mate", ConvertToDouble(profil.NMATE)));
        }

        private double ConvertToDouble(decimal value)
        {
            var result = Convert.ToDouble(value);
            Math.Round(result);
            return result;
        }
        private async Task FillChartScoli(string liceu)
        {
            var repart = await _statisticsRepository.GetRepartScoli(liceu);
            var repartModel = repart.First();

            if (_statisticsView.DSPAreaScoli.DataPointCount > 0)
            {
                _statisticsView.DSPAreaScoli.DataPoints.Clear();
            }
            _statisticsView.DSPAreaScoli.DataPoints.Add(new LPoint("Scoala Gimnaziala", repartModel.scoala_count));
            _statisticsView.DSPAreaScoli.DataPoints.Add(new LPoint("Liceu", repartModel.liceu_count));
            _statisticsView.DSPAreaScoli.DataPoints.Add(new LPoint("Colegiu National", repartModel.colegiu_count));
        }
        private void SetUpGMap()
        {
            _statisticsView.GMLocatieLiceu.MapProvider = GMapProviders.BingMap;
            _statisticsView.GMLocatieLiceu.MinZoom = 9;
            _statisticsView.GMLocatieLiceu.MaxZoom = 12;
            _statisticsView.GMLocatieLiceu.Zoom = 12;
            _statisticsView.GMLocatieLiceu.DragButton = MouseButtons.Left;
        }
        private async Task DisplayLocation(string liceu)
        {
            // atentie limita de utilizari 150 000  nu stiu cate sunt folosite
            // banuiersc ca nu mai merge cand se epuizeaza
            var adr = await _statisticsRepository.GetAdresaLiceu(liceu);
            var adresa = "Bucharest " + adr.FirstOrDefault();

            if (adresa != null)
            {
                BingStreeMapCall openStreeMapCall = new BingStreeMapCall();
                var pl = await openStreeMapCall.GetLocationAsync(adresa);
                if (pl != null)
                {
                    _statisticsView.GMLocatieLiceu.Position = (PointLatLng)pl;
                }
            }
        }
    }
}
