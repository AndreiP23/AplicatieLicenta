namespace LicentaNou2
{
    partial class FrmDetaliiRecomandare
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.Charts.WinForms.ChartFont chartFont1 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont2 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont3 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont4 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid1 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick1 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont5 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid2 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick2 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont6 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid3 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.PointLabel pointLabel1 = new Guna.Charts.WinForms.PointLabel();
            Guna.Charts.WinForms.ChartFont chartFont7 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Tick tick3 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont8 = new Guna.Charts.WinForms.ChartFont();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panAdmis = new Guna.UI2.WinForms.Guna2Panel();
            PlacitaNote = new Guna.Charts.WinForms.GunaChart();
            btnExit = new Guna.UI2.WinForms.Guna2CircleButton();
            lblDetaliiAdmitere = new Label();
            PieCompozitieNota = new Guna.Charts.WinForms.GunaPieDataset();
            panOptiuni = new Guna.UI2.WinForms.Guna2Panel();
            dgvOptiuni = new Guna.UI2.WinForms.Guna2DataGridView();
            lblOptiuni = new Label();
            panSituatie = new Guna.UI2.WinForms.Guna2Panel();
            progSituatie = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            lblSituat = new Label();
            panAdmis.SuspendLayout();
            panOptiuni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOptiuni).BeginInit();
            panSituatie.SuspendLayout();
            SuspendLayout();
            // 
            // panAdmis
            // 
            panAdmis.Controls.Add(PlacitaNote);
            panAdmis.Controls.Add(btnExit);
            panAdmis.Controls.Add(lblDetaliiAdmitere);
            panAdmis.CustomizableEdges = customizableEdges2;
            panAdmis.Dock = DockStyle.Top;
            panAdmis.Location = new Point(0, 0);
            panAdmis.Margin = new Padding(3, 2, 3, 2);
            panAdmis.Name = "panAdmis";
            panAdmis.ShadowDecoration.CustomizableEdges = customizableEdges3;
            panAdmis.Size = new Size(796, 150);
            panAdmis.TabIndex = 0;
            // 
            // PlacitaNote
            // 
            PlacitaNote.AutoSize = true;
            PlacitaNote.BackColor = Color.Transparent;
            PlacitaNote.BackgroundImageLayout = ImageLayout.None;
            PlacitaNote.BorderStyle = BorderStyle.FixedSingle;
            PlacitaNote.Datasets.AddRange(new Guna.Charts.Interfaces.IGunaDataset[] { PieCompozitieNota });
            PlacitaNote.Legend.Display = false;
            chartFont1.FontName = "Arial";
            PlacitaNote.Legend.LabelFont = chartFont1;
            PlacitaNote.Location = new Point(0, 0);
            PlacitaNote.Name = "PlacitaNote";
            PlacitaNote.PaletteCustomColors.FillColors.AddRange(new Color[] { Color.FromArgb(255, 192, 192), Color.Red });
            PlacitaNote.Size = new Size(178, 147);
            PlacitaNote.TabIndex = 13;
            PlacitaNote.Title.Display = false;
            chartFont2.FontName = "Arial";
            chartFont2.Size = 12;
            chartFont2.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            PlacitaNote.Title.Font = chartFont2;
            chartFont3.FontName = "Arial";
            PlacitaNote.Tooltips.BodyFont = chartFont3;
            chartFont4.FontName = "Arial";
            chartFont4.Size = 9;
            chartFont4.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            PlacitaNote.Tooltips.TitleFont = chartFont4;
            PlacitaNote.XAxes.Display = false;
            PlacitaNote.XAxes.GridLines = grid1;
            chartFont5.FontName = "Arial";
            tick1.Font = chartFont5;
            PlacitaNote.XAxes.Ticks = tick1;
            PlacitaNote.YAxes.Display = false;
            PlacitaNote.YAxes.GridLines = grid2;
            chartFont6.FontName = "Arial";
            tick2.Font = chartFont6;
            PlacitaNote.YAxes.Ticks = tick2;
            PlacitaNote.ZAxes.GridLines = grid3;
            chartFont7.FontName = "Arial";
            pointLabel1.Font = chartFont7;
            PlacitaNote.ZAxes.PointLabels = pointLabel1;
            chartFont8.FontName = "Arial";
            tick3.Font = chartFont8;
            PlacitaNote.ZAxes.Ticks = tick3;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.BorderThickness = 1;
            btnExit.DisabledState.BorderColor = Color.DarkGray;
            btnExit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExit.FillColor = Color.Transparent;
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnExit.ForeColor = Color.White;
            btnExit.HoverState.FillColor = Color.FromArgb(255, 128, 128);
            btnExit.Image = Properties.Resources.Close;
            btnExit.Location = new Point(769, 0);
            btnExit.Margin = new Padding(3, 2, 3, 2);
            btnExit.Name = "btnExit";
            btnExit.PressedColor = Color.LightCoral;
            btnExit.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btnExit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnExit.Size = new Size(27, 22);
            btnExit.TabIndex = 12;
            btnExit.Click += btnExit_Click;
            // 
            // lblDetaliiAdmitere
            // 
            lblDetaliiAdmitere.Dock = DockStyle.Right;
            lblDetaliiAdmitere.Location = new Point(184, 0);
            lblDetaliiAdmitere.Name = "lblDetaliiAdmitere";
            lblDetaliiAdmitere.Size = new Size(612, 150);
            lblDetaliiAdmitere.TabIndex = 2;
            lblDetaliiAdmitere.Text = "label1";
            lblDetaliiAdmitere.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PieCompozitieNota
            // 
            PieCompozitieNota.Label = "Pie1";
            PieCompozitieNota.TargetChart = PlacitaNote;
            // 
            // panOptiuni
            // 
            panOptiuni.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panOptiuni.Controls.Add(dgvOptiuni);
            panOptiuni.Controls.Add(lblOptiuni);
            panOptiuni.CustomizableEdges = customizableEdges4;
            panOptiuni.Location = new Point(0, 148);
            panOptiuni.Margin = new Padding(3, 2, 3, 2);
            panOptiuni.Name = "panOptiuni";
            panOptiuni.ShadowDecoration.CustomizableEdges = customizableEdges5;
            panOptiuni.Size = new Size(796, 146);
            panOptiuni.TabIndex = 1;
            // 
            // dgvOptiuni
            // 
            dgvOptiuni.AllowUserToAddRows = false;
            dgvOptiuni.AllowUserToDeleteRows = false;
            dgvOptiuni.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(215, 215, 215);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 128, 64);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvOptiuni.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvOptiuni.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOptiuni.BackgroundColor = Color.LightGray;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 128, 128);
            dataGridViewCellStyle2.Font = new Font("Palatino Linotype", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 128, 128);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvOptiuni.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvOptiuni.ColumnHeadersHeight = 24;
            dgvOptiuni.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Palatino Linotype", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 128, 64);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvOptiuni.DefaultCellStyle = dataGridViewCellStyle3;
            dgvOptiuni.GridColor = Color.FromArgb(255, 128, 128);
            dgvOptiuni.Location = new Point(291, 3);
            dgvOptiuni.Name = "dgvOptiuni";
            dgvOptiuni.ReadOnly = true;
            dgvOptiuni.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Palatino Linotype", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvOptiuni.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvOptiuni.RowHeadersVisible = false;
            dgvOptiuni.RowHeadersWidth = 51;
            dgvOptiuni.RowTemplate.Height = 29;
            dgvOptiuni.Size = new Size(505, 143);
            dgvOptiuni.TabIndex = 9;
            dgvOptiuni.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvOptiuni.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvOptiuni.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvOptiuni.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvOptiuni.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvOptiuni.ThemeStyle.BackColor = Color.LightGray;
            dgvOptiuni.ThemeStyle.GridColor = Color.FromArgb(255, 128, 128);
            dgvOptiuni.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvOptiuni.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvOptiuni.ThemeStyle.HeaderStyle.Font = new Font("Palatino Linotype", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgvOptiuni.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvOptiuni.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvOptiuni.ThemeStyle.HeaderStyle.Height = 24;
            dgvOptiuni.ThemeStyle.ReadOnly = true;
            dgvOptiuni.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvOptiuni.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvOptiuni.ThemeStyle.RowsStyle.Font = new Font("Palatino Linotype", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgvOptiuni.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvOptiuni.ThemeStyle.RowsStyle.Height = 29;
            dgvOptiuni.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvOptiuni.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // lblOptiuni
            // 
            lblOptiuni.Dock = DockStyle.Left;
            lblOptiuni.Location = new Point(0, 0);
            lblOptiuni.Name = "lblOptiuni";
            lblOptiuni.Size = new Size(285, 146);
            lblOptiuni.TabIndex = 3;
            lblOptiuni.Text = "label2";
            lblOptiuni.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panSituatie
            // 
            panSituatie.Controls.Add(progSituatie);
            panSituatie.Controls.Add(lblSituat);
            panSituatie.CustomizableEdges = customizableEdges7;
            panSituatie.Dock = DockStyle.Bottom;
            panSituatie.Location = new Point(0, 297);
            panSituatie.Margin = new Padding(3, 2, 3, 2);
            panSituatie.Name = "panSituatie";
            panSituatie.ShadowDecoration.CustomizableEdges = customizableEdges8;
            panSituatie.Size = new Size(796, 143);
            panSituatie.TabIndex = 2;
            // 
            // progSituatie
            // 
            progSituatie.Dock = DockStyle.Right;
            progSituatie.FillColor = Color.FromArgb(200, 213, 218, 223);
            progSituatie.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            progSituatie.ForeColor = Color.Black;
            progSituatie.Location = new Point(653, 0);
            progSituatie.Margin = new Padding(3, 2, 3, 2);
            progSituatie.Minimum = 0;
            progSituatie.Name = "progSituatie";
            progSituatie.ShadowDecoration.CustomizableEdges = customizableEdges6;
            progSituatie.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            progSituatie.ShowText = true;
            progSituatie.Size = new Size(143, 143);
            progSituatie.TabIndex = 4;
            progSituatie.Text = "67";
            progSituatie.Value = 67;
            // 
            // lblSituat
            // 
            lblSituat.Dock = DockStyle.Left;
            lblSituat.Location = new Point(0, 0);
            lblSituat.Name = "lblSituat";
            lblSituat.Size = new Size(624, 143);
            lblSituat.TabIndex = 3;
            lblSituat.Text = "label3";
            lblSituat.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmDetaliiRecomandare
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 440);
            Controls.Add(panSituatie);
            Controls.Add(panOptiuni);
            Controls.Add(panAdmis);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmDetaliiRecomandare";
            Text = "FrmDetaliiRecomandare";
            Load += FrmDetaliiRecomandare_Load;
            panAdmis.ResumeLayout(false);
            panAdmis.PerformLayout();
            panOptiuni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOptiuni).EndInit();
            panSituatie.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panAdmis;
        private Label lblDetaliiAdmitere;
        private Guna.UI2.WinForms.Guna2Panel panOptiuni;
        private Guna.UI2.WinForms.Guna2Panel panSituatie;
        private Guna.UI2.WinForms.Guna2ProgressBar guna2ProgressBar1;
        private Label lblOptiuni;
        private Guna.UI2.WinForms.Guna2CircleProgressBar progSituatie;
        private Label lblSituat;
        private Guna.Charts.WinForms.GunaPieDataset PieCompozitieNota;
        private Guna.UI2.WinForms.Guna2CircleButton btnExit;
        private Guna.UI2.WinForms.Guna2DataGridView dgvOptiuni;
        private Guna.Charts.WinForms.GunaChart PlacitaNote;
    }
}