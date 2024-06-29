using Guna.Charts.WinForms;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Views.Interfaces
{
    public interface IMainView : IBaseView
    {
        // public DataGridView DgvTopLiceu { get; set; }
        Label LblTitluTopLiceu { get; set; }
        Guna2DataGridView GDGVLicee { get; set; }
        Guna2TileButton GTBtn2021 { get; set; }
        Guna2ComboBox CmbProfile { get; set; }
        Guna2TextBox TxtProfilDet { get; set; }
        Guna2TextBox TxtSearch { get; set; }
        GunaChart ChartTipuriLicee { get; set; }
        GunaChart ChartProfilePlacintar { get; set; }
        GunaPieDataset DatasetProfilePlacintar { get; set; }
        GunaBarDataset BarDatasetLicee { get; set; }
    }
}
