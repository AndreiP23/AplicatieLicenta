using GMap.NET.WindowsForms;
using Guna.Charts.WinForms;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Views.Interfaces
{
    public interface IStatisticsView :IBaseView
    {
        GunaChart ChartPAreaScoli { get; set; }
        GunaChart ChartRadarProfil { get; set; }
        GunaRadarDataset DSRadarProfil { get; set; }
        GunaPolarAreaDataset DSPAreaScoli { get; set; }
        GMapControl GMLocatieLiceu { get; set; }
        Guna2ComboBox CmbLiceu { get; set; }
        Panel PanLoadImg { get; set; }
    }
}
