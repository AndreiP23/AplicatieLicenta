using LicentaNou2.Views.Interfaces;

namespace LicentaNou2.Views
{
    public class BaseView : Form , IBaseView
    {
        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }
        public void openChildForm(Form childForm, Panel targetPanel, Form activeForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            else
            {
                Program.mainView.activeForm = childForm;
            }
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            targetPanel.Controls.Add(childForm);
            targetPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public Form? activeForm { get; set; }
    }
}
