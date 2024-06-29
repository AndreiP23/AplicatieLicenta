using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicentaNou2.Views.Interfaces
{
    public interface IBaseView
    {
        void ShowMessageBox(string message);
        public void openChildForm(Form childForm, Panel targetPanel, Form activeForm);
        public Form? activeForm {  get; set; }
    }
}
