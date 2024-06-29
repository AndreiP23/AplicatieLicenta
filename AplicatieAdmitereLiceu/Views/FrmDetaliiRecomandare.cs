using Guna.Charts.WinForms;
using Guna.UI2.WinForms;
using LicentaNou2.Models;
using LicentaNou2.Presenters;
using LicentaNou2.Views;
using LicentaNou2.Views.Interfaces;
using Microsoft.ML;


namespace LicentaNou2
{
    public partial class FrmDetaliiRecomandare : BaseView, IDetaliiRecomandareView
    {
        public DetaliiRecomandarePresenter Presenter { get; set; }
        public GunaChart ChartAdmis { get => PlacitaNote; set => PlacitaNote = value; }
        public GunaPieDataset ProgSituatie { get => PieCompozitieNota; set => PieCompozitieNota = value; }
        public Label LblAdmis { get => lblDetaliiAdmitere; set => lblDetaliiAdmitere = value; }
        public Label LblOptiuni { get => lblOptiuni; set => lblOptiuni = value; }
        public Label LblSituatie { get => lblSituat; set => lblSituat = value; }
        public Guna2DataGridView DgvOptiuni { get => dgvOptiuni; set => dgvOptiuni = value; }
        public Guna2CircleProgressBar ProgSansaSituatie { get => progSituatie; set => progSituatie = value; }
        public RecomandareModel loadedData { get; set; }
        public FrmDetaliiRecomandare( DetaliiRecomandarePresenter presenter)
        {
            InitializeComponent();
            Presenter = presenter;
            Presenter.SetView(this);
        }

        private void FrmDetaliiRecomandare_Load(object sender, EventArgs e)
        {
            Presenter.Load(loadedData);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void RetriveData(RecomandareModel data, ITransformer transformer)
        {
            Presenter.SetUpMLPredict(transformer);

            loadedData = data;
        }
        public void VerifyData(RecomandareModel data)
        {
            Presenter.VerificareCompletareDate(data);
        }
    }
}
