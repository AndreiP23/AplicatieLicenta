using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Views.Interfaces
{
    public interface ILoginView
    {
        Guna2TextBox TxtUsername { get; set; }
        Guna2TextBox TxtPassword { get; set; }
    }
}
