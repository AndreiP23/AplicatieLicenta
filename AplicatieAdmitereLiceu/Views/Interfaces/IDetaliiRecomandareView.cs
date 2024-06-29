using Guna.Charts.WinForms;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Views.Interfaces
{
    public interface IDetaliiRecomandareView : IBaseView
    {
        public GunaChart ChartAdmis { get; set; }
        public GunaPieDataset ProgSituatie { get; set; }
        Label LblAdmis { get; set; }
        Label LblOptiuni { get; set; }
        Label LblSituatie { get; set; }
        Guna2DataGridView DgvOptiuni { get; set; }
        Guna2CircleProgressBar ProgSansaSituatie { get; set; }
    }
}
