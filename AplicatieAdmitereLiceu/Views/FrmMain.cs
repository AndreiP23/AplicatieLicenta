using Accord.Math;
using Guna.Charts.WinForms;
using Guna.UI2.WinForms;
using LicentaNou2.Presenters;
using LicentaNou2.Util;
using LicentaNou2.Views;
using LicentaNou2.Views.Interfaces;



namespace LicentaNou2
{
    public partial class FrmMain : BaseView, IMainView
    {
        private int anSelectat = 2021;
        private IViewFactory _viewFactory;
        public class Profil
        {
            public string Nume { get; set; }
            public int Index { get; set; }
        }

        #region Propretati
        public Guna2TileButton GTBtn2021 { get => tBtnAn2021; set => tBtnAn2021 = value; }
        public Guna2DataGridView GDGVLicee { get => gDGVLicee; set => gDGVLicee = value; }
        public MainPresenter Presenter { get; set; }
        public Label LblTitluTopLiceu { get => lblTopLiceu; set => lblTopLiceu = value; }
        public Guna2ComboBox CmbProfile { get => cmbProfile; set => cmbProfile = value; }
        public Guna2TextBox TxtProfilDet { get => txtProfilDet; set => txtProfilDet = value; }
        public Guna2TextBox TxtSearch { get => txtSearch; set => txtSearch = value; }
        public GunaChart ChartTipuriLicee { get => chartTipuriLicee; set => chartTipuriLicee = value; }
        public GunaBarDataset BarDatasetLicee { get => barDatasetLicee; set => barDatasetLicee = value; }
        public GunaChart ChartProfilePlacintar { get => ChartCompozitieProfile; set => ChartCompozitieProfile = value; }
        public GunaPieDataset DatasetProfilePlacintar { get => PieDataset; set => PieDataset = value; }
        #endregion

        public FrmMain(MainPresenter presenter, IViewFactory viewFactory)
        {
            InitializeComponent();
            GDGVLicee = this.gDGVLicee;
            Presenter = presenter;
            Presenter.SetView(this);
            _viewFactory = viewFactory;
        }

        private async void FrmMain2_Load(object sender, EventArgs e)
        {
            await Presenter.PopulareMainInfo();
        }

        private async void tBtnAn2023_Click(object sender, EventArgs e)
        {
            try
            {
                tBtnAn2021.FillColor = Color.Salmon;
                await Presenter.PopulareDGVTopLicee(Convert.ToInt32(tBtnAn2023.Text));
                await Presenter.StatLiceeByANAndProfil(2023, cmbProfile.Text);
                await Presenter.FillChart();
                tBtnAn2023.FillColor = Color.Pink;
                anSelectat = 2023;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private async void tBtnAn2021_Click(object sender, EventArgs e)
        {
            try
            {
                tBtnAn2023.FillColor = Color.Salmon;
                await Presenter.PopulareDGVTopLicee(Convert.ToInt32(tBtnAn2021.Text));
                await Presenter.StatLiceeByANAndProfil(2021, cmbProfile.Text);
                await Presenter.FillChart();
                tBtnAn2021.FillColor = Color.Pink;
                anSelectat = 2021;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private async void cmbProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProfile.SelectedItem != null)
            {
                await Presenter.StatLiceeByANAndProfil(anSelectat, cmbProfile.Text);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await Presenter.Search();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSectoare_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms.Count > 0)
                {
                    if (activeForm != null)
                    {
                        Program.mainView.activeForm.Close();
                        Program.mainView.activeForm = null;
                    }

                    List<Form> formsToDispose = new List<Form>();

                    foreach (Form form in Application.OpenForms)
                    {
                        if (!form.Equals(Program.mainView))
                        {
                            formsToDispose.Add(form);
                        }
                    }
                    foreach (Form form in formsToDispose)
                    {
                        form.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }
        }

        private void btnRecomandari_Click(object sender, EventArgs e)
        {
            try
            {
                var frmRecom = _viewFactory.Create<FrmRecomandari>();
                openChildForm(frmRecom, panMainInfo, Program.mainView.activeForm);
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }
        }

        private void btnArhiva_Click(object sender, EventArgs e)
        {
            try
            {
                var frmStat = _viewFactory.Create<FrmStatistics>();
                openChildForm(frmStat, panMainInfo, Program.mainView.activeForm);
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }
        }
    }
}
