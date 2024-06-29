using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Views.Interfaces
{
    public interface IRecomandariView : IBaseView
    {
        Guna2NumericUpDown NumMGenerala { get; set; }
        Guna2NumericUpDown NumNRom { get; set; }
        Guna2NumericUpDown NumNMate { get; set; }
        Guna2ComboBox CmbLiceu { get; set; }
        Guna2ComboBox CmbProfil { get; set; }
        Guna2ComboBox CmbCategorie { get; set; }
        Guna2ComboBox CmbLimba { get; set; }

        Guna2Panel PanInfo1 { get; set; }
        Label LblInfo { get; set; }
    }
}
