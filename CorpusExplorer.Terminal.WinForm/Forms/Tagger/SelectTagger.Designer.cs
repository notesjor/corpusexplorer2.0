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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectTagger));
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
      resources.ApplyResources(this.radPanel1, "radPanel1");
      // 
      // ihdPanel1
      // 
      this.ihdPanel1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.ihdPanel1, "ihdPanel1");
      this.ihdPanel1.IHDDescription = "Wählen Sie einen Tagger und konfigurieren Sie ihn für die automatische Annotation" +
    "";
      this.ihdPanel1.IHDHeader = "Tagger-Optionen";
      this.ihdPanel1.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.gears1;
      this.ihdPanel1.Name = "ihdPanel1";
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.combo_tagger);
      resources.ApplyResources(this.radGroupBox1, "radGroupBox1");
      this.radGroupBox1.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.VerfügbareTaggerKonfigurationen;
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.VerfügbareTaggerKonfigurationen;
      // 
      // combo_tagger
      // 
      resources.ApplyResources(this.combo_tagger, "combo_tagger");
      this.combo_tagger.Name = "combo_tagger";
      this.combo_tagger.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.combo_tagger_SelectedIndexChanged);
      // 
      // radCollapsiblePanel1
      // 
      resources.ApplyResources(this.radCollapsiblePanel1, "radCollapsiblePanel1");
      this.radCollapsiblePanel1.Name = "radCollapsiblePanel1";
      this.radCollapsiblePanel1.OwnerBoundsCache = new System.Drawing.Rectangle(0, 117, 583, 179);
      // 
      // radCollapsiblePanel1.PanelContainer
      // 
      this.radCollapsiblePanel1.PanelContainer.Controls.Add(this.radGroupBox4);
      this.radCollapsiblePanel1.PanelContainer.Controls.Add(this.radGroupBox3);
      this.radCollapsiblePanel1.PanelContainer.Controls.Add(this.radGroupBox2);
      resources.ApplyResources(this.radCollapsiblePanel1.PanelContainer, "radCollapsiblePanel1.PanelContainer");
      // 
      // radGroupBox4
      // 
      this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox4.Controls.Add(this.radLabel1);
      this.radGroupBox4.Controls.Add(this.combo_backends);
      resources.ApplyResources(this.radGroupBox4, "radGroupBox4");
      this.radGroupBox4.Name = "radGroupBox4";
      // 
      // radLabel1
      // 
      resources.ApplyResources(this.radLabel1, "radLabel1");
      this.radLabel1.Name = "radLabel1";
      // 
      // combo_backends
      // 
      resources.ApplyResources(this.combo_backends, "combo_backends");
      this.combo_backends.Name = "combo_backends";
      this.combo_backends.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.combo_backends_SelectedIndexChanged);
      // 
      // radGroupBox3
      // 
      this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox3.Controls.Add(this.lbl_destination);
      this.radGroupBox3.Controls.Add(this.btn_destination);
      resources.ApplyResources(this.radGroupBox3, "radGroupBox3");
      this.radGroupBox3.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Installationsort;
      this.radGroupBox3.Name = "radGroupBox3";
      this.radGroupBox3.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Installationsort;
      // 
      // lbl_destination
      // 
      resources.ApplyResources(this.lbl_destination, "lbl_destination");
      this.lbl_destination.Name = "lbl_destination";
      // 
      // btn_destination
      // 
      resources.ApplyResources(this.btn_destination, "btn_destination");
      this.btn_destination.Name = "btn_destination";
      this.btn_destination.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Ändern;
      this.btn_destination.Click += new System.EventHandler(this.btn_destination_Click);
      // 
      // radGroupBox2
      // 
      this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add(this.combo_language);
      resources.ApplyResources(this.radGroupBox2, "radGroupBox2");
      this.radGroupBox2.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Sprache;
      this.radGroupBox2.Name = "radGroupBox2";
      this.radGroupBox2.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Sprache;
      // 
      // combo_language
      // 
      resources.ApplyResources(this.combo_language, "combo_language");
      this.combo_language.Name = "combo_language";
      this.combo_language.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.combo_language_SelectedIndexChanged);
      // 
      // SelectTagger
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.radCollapsiblePanel1);
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this.ihdPanel1);
      this.DisplayAbort = true;
      this.Name = "SelectTagger";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
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