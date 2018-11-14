using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;

namespace CorpusExplorer.Terminal.WinForm.Forms.Tagger
{
  partial class SelectTagger
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
      this.ihdPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.combo_tagger = new Telerik.WinControls.UI.RadDropDownList();
      this.radCollapsiblePanel1 = new Telerik.WinControls.UI.RadCollapsiblePanel();
      this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.combo_backends = new Telerik.WinControls.UI.RadDropDownList();
      this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
      this.lbl_destination = new System.Windows.Forms.Label();
      this.btn_destination = new Telerik.WinControls.UI.RadButton();
      this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
      this.combo_language = new Telerik.WinControls.UI.RadDropDownList();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.combo_tagger)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCollapsiblePanel1)).BeginInit();
      this.radCollapsiblePanel1.PanelContainer.SuspendLayout();
      this.radCollapsiblePanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
      this.radGroupBox4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.combo_backends)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
      this.radGroupBox3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_destination)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
      this.radGroupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.combo_language)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Location = new System.Drawing.Point(0, 296);
      this.radPanel1.Size = new System.Drawing.Size(583, 38);
      // 
      // ihdPanel1
      // 
      this.ihdPanel1.BackColor = System.Drawing.Color.White;
      this.ihdPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihdPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihdPanel1.IHDDeescribtion = "Wählen Sie einen Tagger und konfigurieren Sie ihn für die automatische Annotation" +
    "";
      this.ihdPanel1.IHDHeader = "Tagger-Optionen";
      this.ihdPanel1.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.gears1;
      this.ihdPanel1.Location = new System.Drawing.Point(0, 0);
      this.ihdPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.ihdPanel1.Name = "ihdPanel1";
      this.ihdPanel1.Size = new System.Drawing.Size(583, 55);
      this.ihdPanel1.TabIndex = 2;
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.combo_tagger);
      this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox1.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.VerfügbareTaggerKonfigurationen;
      this.radGroupBox1.Location = new System.Drawing.Point(0, 55);
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Padding = new System.Windows.Forms.Padding(7, 25, 7, 7);
      this.radGroupBox1.Size = new System.Drawing.Size(583, 65);
      this.radGroupBox1.TabIndex = 3;
      this.radGroupBox1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.VerfügbareTaggerKonfigurationen;
      // 
      // combo_tagger
      // 
      this.combo_tagger.Dock = System.Windows.Forms.DockStyle.Fill;
      this.combo_tagger.Location = new System.Drawing.Point(7, 25);
      this.combo_tagger.Name = "combo_tagger";
      this.combo_tagger.Size = new System.Drawing.Size(569, 33);
      this.combo_tagger.TabIndex = 0;
      this.combo_tagger.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.combo_tagger_SelectedIndexChanged);
      // 
      // radCollapsiblePanel1
      // 
      this.radCollapsiblePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radCollapsiblePanel1.HeaderText = "Erweiterte Einstellungen (Sprache / Backend)";
      this.radCollapsiblePanel1.Location = new System.Drawing.Point(0, 120);
      this.radCollapsiblePanel1.Name = "radCollapsiblePanel1";
      this.radCollapsiblePanel1.OwnerBoundsCache = new System.Drawing.Rectangle(0, 117, 583, 179);
      // 
      // radCollapsiblePanel1.PanelContainer
      // 
      this.radCollapsiblePanel1.PanelContainer.Controls.Add(this.radGroupBox4);
      this.radCollapsiblePanel1.PanelContainer.Controls.Add(this.radGroupBox3);
      this.radCollapsiblePanel1.PanelContainer.Controls.Add(this.radGroupBox2);
      this.radCollapsiblePanel1.PanelContainer.Size = new System.Drawing.Size(545, 140);
      this.radCollapsiblePanel1.Size = new System.Drawing.Size(583, 176);
      this.radCollapsiblePanel1.TabIndex = 4;
      this.radCollapsiblePanel1.Text = "radCollapsiblePanel1";
      // 
      // radGroupBox4
      // 
      this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox4.Controls.Add(this.radLabel1);
      this.radGroupBox4.Controls.Add(this.combo_backends);
      this.radGroupBox4.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox4.HeaderText = "Daten-Backend (Für Expert*innen)";
      this.radGroupBox4.Location = new System.Drawing.Point(0, 126);
      this.radGroupBox4.Name = "radGroupBox4";
      this.radGroupBox4.Padding = new System.Windows.Forms.Padding(7, 25, 7, 7);
      this.radGroupBox4.Size = new System.Drawing.Size(545, 104);
      this.radGroupBox4.TabIndex = 2;
      this.radGroupBox4.Text = "Daten-Backend (Für Expert*innen)";
      // 
      // radLabel1
      // 
      this.radLabel1.AutoSize = false;
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel1.Location = new System.Drawing.Point(7, 57);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(531, 37);
      this.radLabel1.TabIndex = 1;
      this.radLabel1.Text = "<html><strong>Hinweis:</strong> Externe Datenbanken müssen zuvor über die Projekt" +
    "einstellungen konfiguriert werden.</html>";
      this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // combo_backends
      // 
      this.combo_backends.Dock = System.Windows.Forms.DockStyle.Top;
      this.combo_backends.Location = new System.Drawing.Point(7, 25);
      this.combo_backends.Name = "combo_backends";
      this.combo_backends.Size = new System.Drawing.Size(531, 32);
      this.combo_backends.TabIndex = 0;
      this.combo_backends.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.combo_backends_SelectedIndexChanged);
      // 
      // radGroupBox3
      // 
      this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox3.Controls.Add(this.lbl_destination);
      this.radGroupBox3.Controls.Add(this.btn_destination);
      this.radGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox3.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Installationsort;
      this.radGroupBox3.Location = new System.Drawing.Point(0, 64);
      this.radGroupBox3.Name = "radGroupBox3";
      this.radGroupBox3.Padding = new System.Windows.Forms.Padding(7, 25, 7, 7);
      this.radGroupBox3.Size = new System.Drawing.Size(545, 62);
      this.radGroupBox3.TabIndex = 1;
      this.radGroupBox3.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Installationsort;
      // 
      // lbl_destination
      // 
      this.lbl_destination.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbl_destination.Location = new System.Drawing.Point(7, 25);
      this.lbl_destination.Name = "lbl_destination";
      this.lbl_destination.Size = new System.Drawing.Size(421, 30);
      this.lbl_destination.TabIndex = 1;
      this.lbl_destination.Text = "C:\\TreeTagger\\bin";
      this.lbl_destination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btn_destination
      // 
      this.btn_destination.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_destination.Location = new System.Drawing.Point(428, 25);
      this.btn_destination.Name = "btn_destination";
      this.btn_destination.Size = new System.Drawing.Size(110, 30);
      this.btn_destination.TabIndex = 0;
      this.btn_destination.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Ändern;
      this.btn_destination.Click += new System.EventHandler(this.btn_destination_Click);
      // 
      // radGroupBox2
      // 
      this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add(this.combo_language);
      this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox2.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Sprache;
      this.radGroupBox2.Location = new System.Drawing.Point(0, 0);
      this.radGroupBox2.Name = "radGroupBox2";
      this.radGroupBox2.Padding = new System.Windows.Forms.Padding(7, 25, 7, 7);
      this.radGroupBox2.Size = new System.Drawing.Size(545, 64);
      this.radGroupBox2.TabIndex = 0;
      this.radGroupBox2.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Sprache;
      // 
      // combo_language
      // 
      this.combo_language.Dock = System.Windows.Forms.DockStyle.Fill;
      this.combo_language.Location = new System.Drawing.Point(7, 25);
      this.combo_language.Name = "combo_language";
      this.combo_language.Size = new System.Drawing.Size(531, 32);
      this.combo_language.TabIndex = 1;
      this.combo_language.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.combo_language_SelectedIndexChanged);
      // 
      // SelectTagger
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(583, 334);
      this.Controls.Add(this.radCollapsiblePanel1);
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this.ihdPanel1);
      this.DisplayAbort = true;
      this.Name = "SelectTagger";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "Tagger für Annotation auswählen";
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.ihdPanel1, 0);
      this.Controls.SetChildIndex(this.radGroupBox1, 0);
      this.Controls.SetChildIndex(this.radCollapsiblePanel1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.combo_tagger)).EndInit();
      this.radCollapsiblePanel1.PanelContainer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radCollapsiblePanel1)).EndInit();
      this.radCollapsiblePanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
      this.radGroupBox4.ResumeLayout(false);
      this.radGroupBox4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.combo_backends)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
      this.radGroupBox3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_destination)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
      this.radGroupBox2.ResumeLayout(false);
      this.radGroupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.combo_language)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private IHDPanel ihdPanel1;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadDropDownList combo_tagger;
    private Telerik.WinControls.UI.RadCollapsiblePanel radCollapsiblePanel1;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
    private System.Windows.Forms.Label lbl_destination;
    private Telerik.WinControls.UI.RadButton btn_destination;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
    private Telerik.WinControls.UI.RadDropDownList combo_language;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
    private Telerik.WinControls.UI.RadDropDownList combo_backends;
    private Telerik.WinControls.UI.RadLabel radLabel1;
  }
}