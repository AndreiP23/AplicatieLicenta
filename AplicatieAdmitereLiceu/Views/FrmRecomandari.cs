using Guna.UI2.WinForms;
using LicentaNou2.Presenters;
using LicentaNou2.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicentaNou2.Views
{
    public partial class FrmRecomandari : BaseView, IRecomandariView
    {
        public IViewFactory _viewFactory;
        public RecomandariPresenter Presenter { get; set; }
        public Guna2NumericUpDown NumMGenerala { get => numMGenerala; set => numMGenerala = value; }
        public Guna2NumericUpDown NumNRom { get => numNRom; set => numNRom = value; }
        public Guna2NumericUpDown NumNMate { get => numNMate; set => numNMate = value; }
        public Guna2ComboBox CmbLiceu { get => cmbLiceu; set => cmbLiceu = value; }
        public Guna2ComboBox CmbProfil { get => cmbProfil; set => cmbProfil = value; }
        public Guna2ComboBox CmbCategorie { get => cmbCategorie; set => cmbCategorie = value; }
        public Guna2ComboBox CmbLimba { get => cmbLimba; set => cmbLimba = value; }
        public Guna2Panel PanInfo1 { get => panInfo1; set => panInfo1 = value; }
        public Label LblInfo { get => lblInfo; set => lblInfo = value; }

        public FrmRecomandari(RecomandariPresenter presenter, IViewFactory viewFactory)
        {
            InitializeComponent();
            Presenter = presenter;
            Presenter.SetView(this);
            _viewFactory = viewFactory;
        }

        private Form? activeForm = null;

        private void btnCalculeaza_Click(object sender, EventArgs e)
        {
            try
            {
                var data = Presenter.FillDataInModel();
                var frmDetaliiRecomandari = _viewFactory.Create<FrmDetaliiRecomandare>();
                frmDetaliiRecomandari.RetriveData(data, Presenter.ReturnModelTrained());
                frmDetaliiRecomandari.VerifyData(data);
                Program.mainView.openChildForm(frmDetaliiRecomandari, panInfoUser, activeForm);
                activeForm = frmDetaliiRecomandari;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void FrmRecomandari_Load(object sender, EventArgs e)
        {
            await Presenter.Load();
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            //await Presenter.TESTPred();
            lblInfo.Visible = false;
            Presenter.NextInfo();
            lblInfo.Visible = true;
            guna2Transition1.ShowSync(lblInfo);
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            await Presenter.ResetForm();
            if (activeForm != null)
            {
                activeForm.Close();
            }
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
            Presenter.NextInfo();
            lblInfo.Visible = true;
            guna2Transition1.ShowSync(lblInfo);
        }
    }
}
