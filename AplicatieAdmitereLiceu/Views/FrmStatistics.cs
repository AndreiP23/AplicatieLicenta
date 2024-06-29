using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using Guna.Charts.WinForms;
using Guna.UI2.WinForms;
using LicentaNou2.Presenters;
using LicentaNou2.Views.Interfaces;

namespace LicentaNou2.Views
{
    public partial class FrmStatistics : BaseView, IStatisticsView
    {
        public GunaChart ChartPAreaScoli { get => pAreaChart; set => pAreaChart = value; }
        public GunaChart ChartRadarProfil { get => chartRadarProfil; set => chartRadarProfil = value; }
        public GunaRadarDataset DSRadarProfil { get => dsRadar; set => dsRadar = value; }
        public GunaPolarAreaDataset DSPAreaScoli { get => pAreaDataset; set => pAreaDataset = value; }
        public GMapControl GMLocatieLiceu { get => gmLocatieLiceu; set => gmLocatieLiceu = value; }
        public Guna2ComboBox CmbLiceu { get => cmbLiceu; set => cmbLiceu = value; }
        public Panel PanLoadImg { get => panLoadImg; set => panLoadImg = value; }
        public StatisticsPresenter Presenter { get; set; }
        public FrmStatistics(StatisticsPresenter statisticsPresenter)
        {
            InitializeComponent();
            Presenter = statisticsPresenter;
            Presenter.SetView(this);
        }

        private async void FrmStatistics_Load(object sender, EventArgs e)
        {
            await Presenter.Load();
        }

        private async void cmbLiceu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            await Presenter.FillInfo();
        }
    }
}
