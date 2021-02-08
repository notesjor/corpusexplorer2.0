namespace CorpusExplorer.Terminal.WinForm.View.Special
{
  partial class PaperLinguist
  {
    /// <summary> 
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Komponenten-Designer generierter Code

    /// <summary> 
    /// Erforderliche Methode für die Designerunterstützung. 
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaperLinguist));
      this._headPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HeadPanel();
      this.chk_overview_analy_corpusDistribution = new Telerik.WinControls.UI.RadCheckBox();
      this.chk_overview_analy_frequency = new Telerik.WinControls.UI.RadCheckBox();
      this.num_overview_analy_corpusDistribution = new Telerik.WinControls.UI.RadSpinEditor();
      this.num_overview_analy_frequency = new Telerik.WinControls.UI.RadSpinEditor();
      this.chk_overview_analy_kwic = new Telerik.WinControls.UI.RadCheckBox();
      this.txt_overview_analy_posFilter = new Telerik.WinControls.UI.RadAutoCompleteBox();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.chk_overview_analy_cooccurrences = new Telerik.WinControls.UI.RadCheckBox();
      this.num_overview_analy_cooccurrences = new Telerik.WinControls.UI.RadSpinEditor();
      this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
      this.chk_query_kwic = new Telerik.WinControls.UI.RadCheckBox();
      this.chk_query_cooccurrences = new Telerik.WinControls.UI.RadCheckBox();
      this.txt_query_kwicRequests = new Telerik.WinControls.UI.RadAutoCompleteBox();
      this.btn_execute = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.chk_overview_analy_corpusDistribution)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_overview_analy_frequency)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.num_overview_analy_corpusDistribution)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.num_overview_analy_frequency)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_overview_analy_kwic)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_overview_analy_posFilter)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chk_overview_analy_cooccurrences)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.num_overview_analy_cooccurrences)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
      this.radGroupBox3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chk_query_kwic)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_query_cooccurrences)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_query_kwicRequests)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_execute)).BeginInit();
      this.SuspendLayout();
      // 
      // _headPanel1
      // 
      this._headPanel1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this._headPanel1, "_headPanel1");
      this._headPanel1.HeadPanelDescription = "Alle Auswertungen des CorpusExplorers in einem Ausdruck";
      this._headPanel1.HeadPanelTitle = "Ich ♥ das gedruckte Wort";
      this._headPanel1.HeadPanelImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.print1;
      this._headPanel1.Name = "_headPanel1";
      // 
      // chk_overview_analy_corpusDistribution
      // 
      resources.ApplyResources(this.chk_overview_analy_corpusDistribution, "chk_overview_analy_corpusDistribution");
      this.chk_overview_analy_corpusDistribution.Name = "chk_overview_analy_corpusDistribution";
      // 
      // chk_overview_analy_frequency
      // 
      resources.ApplyResources(this.chk_overview_analy_frequency, "chk_overview_analy_frequency");
      this.chk_overview_analy_frequency.Name = "chk_overview_analy_frequency";
      // 
      // num_overview_analy_corpusDistribution
      // 
      resources.ApplyResources(this.num_overview_analy_corpusDistribution, "num_overview_analy_corpusDistribution");
      this.num_overview_analy_corpusDistribution.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.num_overview_analy_corpusDistribution.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.num_overview_analy_corpusDistribution.Name = "num_overview_analy_corpusDistribution";
      this.num_overview_analy_corpusDistribution.NullableValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // 
      // 
      this.num_overview_analy_corpusDistribution.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.num_overview_analy_corpusDistribution.TabStop = false;
      this.num_overview_analy_corpusDistribution.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // num_overview_analy_frequency
      // 
      resources.ApplyResources(this.num_overview_analy_frequency, "num_overview_analy_frequency");
      this.num_overview_analy_frequency.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.num_overview_analy_frequency.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.num_overview_analy_frequency.Name = "num_overview_analy_frequency";
      this.num_overview_analy_frequency.NullableValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // 
      // 
      this.num_overview_analy_frequency.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.num_overview_analy_frequency.TabStop = false;
      this.num_overview_analy_frequency.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // chk_overview_analy_kwic
      // 
      resources.ApplyResources(this.chk_overview_analy_kwic, "chk_overview_analy_kwic");
      this.chk_overview_analy_kwic.Name = "chk_overview_analy_kwic";
      // 
      // txt_overview_analy_posFilter
      // 
      resources.ApplyResources(this.txt_overview_analy_posFilter, "txt_overview_analy_posFilter");
      this.txt_overview_analy_posFilter.Multiline = true;
      this.txt_overview_analy_posFilter.Name = "txt_overview_analy_posFilter";
      ((Telerik.WinControls.UI.TextBoxWrapPanel)(this.txt_overview_analy_posFilter.GetChildAt(0).GetChildAt(1))).TextOrientation = ((System.Windows.Forms.Orientation)(resources.GetObject("resource.TextOrientation")));
      ((Telerik.WinControls.UI.TextBoxWrapPanel)(this.txt_overview_analy_posFilter.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.chk_overview_analy_cooccurrences);
      this.radGroupBox1.Controls.Add(this.num_overview_analy_cooccurrences);
      this.radGroupBox1.Controls.Add(this.chk_overview_analy_corpusDistribution);
      this.radGroupBox1.Controls.Add(this.chk_overview_analy_frequency);
      this.radGroupBox1.Controls.Add(this.txt_overview_analy_posFilter);
      this.radGroupBox1.Controls.Add(this.chk_overview_analy_kwic);
      this.radGroupBox1.Controls.Add(this.num_overview_analy_corpusDistribution);
      this.radGroupBox1.Controls.Add(this.num_overview_analy_frequency);
      resources.ApplyResources(this.radGroupBox1, "radGroupBox1");
      this.radGroupBox1.Name = "radGroupBox1";
      // 
      // chk_overview_analy_cooccurrences
      // 
      resources.ApplyResources(this.chk_overview_analy_cooccurrences, "chk_overview_analy_cooccurrences");
      this.chk_overview_analy_cooccurrences.Name = "chk_overview_analy_cooccurrences";
      // 
      // num_overview_analy_cooccurrences
      // 
      resources.ApplyResources(this.num_overview_analy_cooccurrences, "num_overview_analy_cooccurrences");
      this.num_overview_analy_cooccurrences.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.num_overview_analy_cooccurrences.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.num_overview_analy_cooccurrences.Name = "num_overview_analy_cooccurrences";
      this.num_overview_analy_cooccurrences.NullableValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // 
      // 
      this.num_overview_analy_cooccurrences.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.num_overview_analy_cooccurrences.TabStop = false;
      this.num_overview_analy_cooccurrences.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // radGroupBox3
      // 
      this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox3.Controls.Add(this.chk_query_kwic);
      this.radGroupBox3.Controls.Add(this.chk_query_cooccurrences);
      this.radGroupBox3.Controls.Add(this.txt_query_kwicRequests);
      resources.ApplyResources(this.radGroupBox3, "radGroupBox3");
      this.radGroupBox3.Name = "radGroupBox3";
      // 
      // chk_query_kwic
      // 
      resources.ApplyResources(this.chk_query_kwic, "chk_query_kwic");
      this.chk_query_kwic.Name = "chk_query_kwic";
      // 
      // chk_query_cooccurrences
      // 
      resources.ApplyResources(this.chk_query_cooccurrences, "chk_query_cooccurrences");
      this.chk_query_cooccurrences.Name = "chk_query_cooccurrences";
      // 
      // txt_query_kwicRequests
      // 
      resources.ApplyResources(this.txt_query_kwicRequests, "txt_query_kwicRequests");
      this.txt_query_kwicRequests.Multiline = true;
      this.txt_query_kwicRequests.Name = "txt_query_kwicRequests";
      // 
      // btn_execute
      // 
      resources.ApplyResources(this.btn_execute, "btn_execute");
      this.btn_execute.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.print;
      this.btn_execute.Name = "btn_execute";
      this.btn_execute.Click += new System.EventHandler(this.btn_execute_Click);
      // 
      // PaperLinguist
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.btn_execute);
      this.Controls.Add(this.radGroupBox3);
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this._headPanel1);
      this.Name = "PaperLinguist";
      resources.ApplyResources(this, "$this");
      ((System.ComponentModel.ISupportInitialize)(this.chk_overview_analy_corpusDistribution)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_overview_analy_frequency)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.num_overview_analy_corpusDistribution)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.num_overview_analy_frequency)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_overview_analy_kwic)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_overview_analy_posFilter)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chk_overview_analy_cooccurrences)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.num_overview_analy_cooccurrences)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
      this.radGroupBox3.ResumeLayout(false);
      this.radGroupBox3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chk_query_kwic)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_query_cooccurrences)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_query_kwicRequests)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_execute)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.WinForm.HeadPanel _headPanel1;
    private Telerik.WinControls.UI.RadCheckBox chk_overview_analy_corpusDistribution;
    private Telerik.WinControls.UI.RadCheckBox chk_overview_analy_frequency;
    private Telerik.WinControls.UI.RadSpinEditor num_overview_analy_corpusDistribution;
    private Telerik.WinControls.UI.RadSpinEditor num_overview_analy_frequency;
    private Telerik.WinControls.UI.RadCheckBox chk_overview_analy_kwic;
    private Telerik.WinControls.UI.RadAutoCompleteBox txt_overview_analy_posFilter;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadCheckBox chk_overview_analy_cooccurrences;
    private Telerik.WinControls.UI.RadSpinEditor num_overview_analy_cooccurrences;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
    private Telerik.WinControls.UI.RadCheckBox chk_query_kwic;
    private Telerik.WinControls.UI.RadCheckBox chk_query_cooccurrences;
    private Telerik.WinControls.UI.RadAutoCompleteBox txt_query_kwicRequests;
    private Telerik.WinControls.UI.RadButton btn_execute;
  }
}
