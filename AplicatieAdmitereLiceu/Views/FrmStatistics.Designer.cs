using GMap.NET.WindowsForms;

namespace LicentaNou2.Views
{
    partial class FrmStatistics
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
            Guna.Charts.WinForms.LPoint lPoint1 = new Guna.Charts.WinForms.LPoint();
            Guna.Charts.WinForms.LPoint lPoint2 = new Guna.Charts.WinForms.LPoint();
            Guna.Charts.WinForms.LPoint lPoint3 = new Guna.Charts.WinForms.LPoint();
            Guna.Charts.WinForms.LPoint lPoint4 = new Guna.Charts.WinForms.LPoint();
            Guna.Charts.WinForms.LPoint lPoint5 = new Guna.Charts.WinForms.LPoint();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.Charts.WinForms.ChartFont chartFont9 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont10 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont11 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont12 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid4 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick4 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont13 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid5 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick5 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont14 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid6 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.PointLabel pointLabel2 = new Guna.Charts.WinForms.PointLabel();
            Guna.Charts.WinForms.ChartFont chartFont15 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Tick tick6 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont16 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.LPoint lPoint6 = new Guna.Charts.WinForms.LPoint();
            Guna.Charts.WinForms.LPoint lPoint7 = new Guna.Charts.WinForms.LPoint();
            Guna.Charts.WinForms.LPoint lPoint8 = new Guna.Charts.WinForms.LPoint();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStatistics));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            chartRadarProfil = new Guna.Charts.WinForms.GunaChart();
            dsRadar = new Guna.Charts.WinForms.GunaRadarDataset();
            lblSelection = new Label();
            cmbLiceu = new Guna.UI2.WinForms.Guna2ComboBox();
            gmLocatieLiceu = new GMapControl();
            pAreaChart = new Guna.Charts.WinForms.GunaChart();
            pAreaDataset = new Guna.Charts.WinForms.GunaPolarAreaDataset();
            panLoadImg = new Panel();
            pbLoadImg = new Guna.UI2.WinForms.Guna2PictureBox();
            panLoadImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLoadImg).BeginInit();
            SuspendLayout();
            // 
            // chartRadarProfil
            // 
            chartRadarProfil.BackColor = Color.Transparent;
            chartRadarProfil.BackgroundImageLayout = ImageLayout.None;
            chartRadarProfil.BorderStyle = BorderStyle.FixedSingle;
            chartRadarProfil.Datasets.AddRange(new Guna.Charts.Interfaces.IGunaDataset[] { dsRadar });
            chartRadarProfil.Legend.Align = Guna.Charts.WinForms.ChartTextAlignment.End;
            chartRadarProfil.Legend.Display = false;
            chartFont1.FontName = "Arial";
            chartRadarProfil.Legend.LabelFont = chartFont1;
            chartRadarProfil.Location = new Point(12, 12);
            chartRadarProfil.Name = "chartRadarProfil";
            chartRadarProfil.Size = new Size(474, 547);
            chartRadarProfil.TabIndex = 0;
            chartRadarProfil.Title.Display = false;
            chartFont2.FontName = "Arial";
            chartFont2.Size = 12;
            chartFont2.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            chartRadarProfil.Title.Font = chartFont2;
            chartFont3.FontName = "Arial";
            chartRadarProfil.Tooltips.BodyFont = chartFont3;
            chartFont4.FontName = "Arial";
            chartFont4.Size = 9;
            chartFont4.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            chartRadarProfil.Tooltips.TitleFont = chartFont4;
            chartRadarProfil.XAxes.Display = false;
            grid1.Color = Color.IndianRed;
            chartRadarProfil.XAxes.GridLines = grid1;
            chartFont5.FontName = "Arial";
            tick1.Font = chartFont5;
            tick1.HasMaximum = true;
            tick1.HasMinimum = true;
            tick1.Maximum = 10D;
            chartRadarProfil.XAxes.Ticks = tick1;
            chartRadarProfil.YAxes.Display = false;
            grid2.Color = Color.IndianRed;
            chartRadarProfil.YAxes.GridLines = grid2;
            tick2.BeginAtZero = false;
            chartFont6.FontName = "Arial";
            tick2.Font = chartFont6;
            tick2.HasMaximum = true;
            tick2.HasMinimum = true;
            tick2.Maximum = 10D;
            chartRadarProfil.YAxes.Ticks = tick2;
            chartRadarProfil.ZAxes.GridLines = grid3;
            chartFont7.FontName = "Arial";
            pointLabel1.Font = chartFont7;
            chartRadarProfil.ZAxes.PointLabels = pointLabel1;
            chartFont8.FontName = "Arial";
            tick3.Font = chartFont8;
            chartRadarProfil.ZAxes.Ticks = tick3;
            // 
            // dsRadar
            // 
            dsRadar.BorderColor = Color.Empty;
            lPoint1.Label = "test";
            lPoint1.Y = 9D;
            lPoint2.Y = 6.8D;
            lPoint3.Y = 7.6D;
            lPoint4.Y = 8.54D;
            lPoint5.Y = 5.32D;
            dsRadar.DataPoints.AddRange(new Guna.Charts.WinForms.LPoint[] { lPoint1, lPoint2, lPoint3, lPoint4, lPoint5 });
            dsRadar.FillColor = Color.FromArgb(255, 128, 128);
            dsRadar.Label = "Nota";
            dsRadar.PointBorderColors.AddRange(new Color[] { Color.FromArgb(64, 64, 64) });
            dsRadar.PointFillColors.AddRange(new Color[] { Color.FromArgb(255, 192, 192), Color.FromArgb(255, 128, 128), Color.FromArgb(192, 0, 0), Color.FromArgb(255, 128, 0) });
            dsRadar.TargetChart = chartRadarProfil;
            // 
            // lblSelection
            // 
            lblSelection.AutoSize = true;
            lblSelection.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSelection.ImeMode = ImeMode.NoControl;
            lblSelection.Location = new Point(12, 567);
            lblSelection.Name = "lblSelection";
            lblSelection.Size = new Size(502, 21);
            lblSelection.TabIndex = 3;
            lblSelection.Text = "Selecteaza un liceu pentru a vedea profilul general asociat candidatiului";
            // 
            // cmbLiceu
            // 
            cmbLiceu.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbLiceu.AutoRoundedCorners = true;
            cmbLiceu.BackColor = Color.Transparent;
            cmbLiceu.BorderColor = Color.FromArgb(255, 128, 128);
            cmbLiceu.BorderRadius = 17;
            cmbLiceu.CustomizableEdges = customizableEdges1;
            cmbLiceu.DrawMode = DrawMode.OwnerDrawFixed;
            cmbLiceu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLiceu.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbLiceu.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbLiceu.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cmbLiceu.ForeColor = Color.FromArgb(68, 88, 112);
            cmbLiceu.ItemHeight = 30;
            cmbLiceu.Location = new Point(12, 599);
            cmbLiceu.Margin = new Padding(3, 2, 3, 2);
            cmbLiceu.Name = "cmbLiceu";
            cmbLiceu.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cmbLiceu.Size = new Size(403, 36);
            cmbLiceu.TabIndex = 10;
            cmbLiceu.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            cmbLiceu.SelectionChangeCommitted += cmbLiceu_SelectionChangeCommitted;
            // 
            // gmLocatieLiceu
            // 
            gmLocatieLiceu.Bearing = 0F;
            gmLocatieLiceu.BorderStyle = BorderStyle.FixedSingle;
            gmLocatieLiceu.CanDragMap = true;
            gmLocatieLiceu.EmptyTileColor = Color.Navy;
            gmLocatieLiceu.GrayScaleMode = false;
            gmLocatieLiceu.HelperLineOption = HelperLineOptions.DontShow;
            gmLocatieLiceu.LevelsKeepInMemmory = 5;
            gmLocatieLiceu.Location = new Point(981, 12);
            gmLocatieLiceu.MarkersEnabled = true;
            gmLocatieLiceu.MaxZoom = 2;
            gmLocatieLiceu.MinZoom = 2;
            gmLocatieLiceu.MouseWheelZoomEnabled = true;
            gmLocatieLiceu.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gmLocatieLiceu.Name = "gmLocatieLiceu";
            gmLocatieLiceu.NegativeMode = false;
            gmLocatieLiceu.PolygonsEnabled = true;
            gmLocatieLiceu.RetryLoadTile = 0;
            gmLocatieLiceu.RoutesEnabled = true;
            gmLocatieLiceu.ScaleMode = ScaleModes.Integer;
            gmLocatieLiceu.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            gmLocatieLiceu.ShowTileGridLines = false;
            gmLocatieLiceu.Size = new Size(570, 547);
            gmLocatieLiceu.TabIndex = 11;
            gmLocatieLiceu.Zoom = 0D;
            // 
            // pAreaChart
            // 
            pAreaChart.Datasets.AddRange(new Guna.Charts.Interfaces.IGunaDataset[] { pAreaDataset });
            pAreaChart.Legend.Display = false;
            chartFont9.FontName = "Arial";
            pAreaChart.Legend.LabelFont = chartFont9;
            pAreaChart.Location = new Point(492, 12);
            pAreaChart.Name = "pAreaChart";
            pAreaChart.Size = new Size(483, 547);
            pAreaChart.TabIndex = 12;
            chartFont10.FontName = "Arial";
            chartFont10.Size = 12;
            chartFont10.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            pAreaChart.Title.Font = chartFont10;
            chartFont11.FontName = "Arial";
            pAreaChart.Tooltips.BodyFont = chartFont11;
            chartFont12.FontName = "Arial";
            chartFont12.Size = 9;
            chartFont12.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            pAreaChart.Tooltips.TitleFont = chartFont12;
            pAreaChart.XAxes.Display = false;
            pAreaChart.XAxes.GridLines = grid4;
            chartFont13.FontName = "Arial";
            tick4.Font = chartFont13;
            pAreaChart.XAxes.Ticks = tick4;
            pAreaChart.YAxes.Display = false;
            pAreaChart.YAxes.GridLines = grid5;
            chartFont14.FontName = "Arial";
            tick5.Font = chartFont14;
            pAreaChart.YAxes.Ticks = tick5;
            pAreaChart.ZAxes.GridLines = grid6;
            chartFont15.FontName = "Arial";
            pointLabel2.Font = chartFont15;
            pAreaChart.ZAxes.PointLabels = pointLabel2;
            chartFont16.FontName = "Arial";
            tick6.Font = chartFont16;
            pAreaChart.ZAxes.Ticks = tick6;
            // 
            // pAreaDataset
            // 
            lPoint6.Label = "test";
            lPoint6.Y = 50D;
            lPoint7.Label = "test2";
            lPoint7.Y = 60D;
            lPoint8.Label = "test4";
            lPoint8.Y = 30D;
            pAreaDataset.DataPoints.AddRange(new Guna.Charts.WinForms.LPoint[] { lPoint6, lPoint7, lPoint8 });
            pAreaDataset.Label = "Elevi";
            pAreaDataset.LegendBoxBorderColor = Color.FromArgb(255, 128, 128);
            pAreaDataset.LegendBoxFillColor = Color.IndianRed;
            pAreaDataset.TargetChart = pAreaChart;
            // 
            // panLoadImg
            // 
            panLoadImg.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panLoadImg.Controls.Add(pbLoadImg);
            panLoadImg.Location = new Point(12, 12);
            panLoadImg.Name = "panLoadImg";
            panLoadImg.Size = new Size(1539, 547);
            panLoadImg.TabIndex = 13;
            // 
            // pbLoadImg
            // 
            pbLoadImg.BackColor = Color.Coral;
            pbLoadImg.BorderRadius = 5;
            pbLoadImg.BorderStyle = BorderStyle.FixedSingle;
            pbLoadImg.CustomizableEdges = customizableEdges3;
            pbLoadImg.Dock = DockStyle.Fill;
            pbLoadImg.Image = (Image)resources.GetObject("pbLoadImg.Image");
            pbLoadImg.ImageRotate = 0F;
            pbLoadImg.InitialImage = null;
            pbLoadImg.Location = new Point(0, 0);
            pbLoadImg.Name = "pbLoadImg";
            pbLoadImg.ShadowDecoration.Color = Color.Salmon;
            pbLoadImg.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pbLoadImg.Size = new Size(1539, 547);
            pbLoadImg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLoadImg.TabIndex = 0;
            pbLoadImg.TabStop = false;
            // 
            // FrmStatistics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1563, 652);
            Controls.Add(panLoadImg);
            Controls.Add(pAreaChart);
            Controls.Add(gmLocatieLiceu);
            Controls.Add(cmbLiceu);
            Controls.Add(lblSelection);
            Controls.Add(chartRadarProfil);
            Name = "FrmStatistics";
            Text = "FrmStatistics";
            Load += FrmStatistics_Load;
            panLoadImg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbLoadImg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.Charts.WinForms.GunaChart chartRadarProfil;
        private Guna.Charts.WinForms.GunaRadarDataset dsRadar;
        private Label lblSelection;
        private Guna.UI2.WinForms.Guna2ComboBox cmbLiceu;
        private GMapControl gmLocatieLiceu;
        private Guna.Charts.WinForms.GunaChart pAreaChart;
        private Guna.Charts.WinForms.GunaPolarAreaDataset pAreaDataset;
        private Panel panLoadImg;
        private Guna.UI2.WinForms.Guna2PictureBox pbLoadImg;
    }
}