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
      this.ihdPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
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
      // ihdPanel1
      // 
      this.ihdPanel1.BackColor = System.Drawing.Color.White;
      this.ihdPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihdPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihdPanel1.IHDDeescribtion = "Alle Auswertungen des CorpusExplorers in einem Ausdruck";
      this.ihdPanel1.IHDHeader = "Ich ♥ das gedruckte Wort";
      this.ihdPanel1.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.print1;
      this.ihdPanel1.Location = new System.Drawing.Point(0, 0);
      this.ihdPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.ihdPanel1.Name = "ihdPanel1";
      this.ihdPanel1.Size = new System.Drawing.Size(780, 64);
      this.ihdPanel1.TabIndex = 0;
      // 
      // chk_overview_analy_corpusDistribution
      // 
      this.chk_overview_analy_corpusDistribution.Location = new System.Drawing.Point(8, 28);
      this.chk_overview_analy_corpusDistribution.Name = "chk_overview_analy_corpusDistribution";
      this.chk_overview_analy_corpusDistribution.Size = new System.Drawing.Size(201, 32);
      this.chk_overview_analy_corpusDistribution.TabIndex = 1;
      this.chk_overview_analy_corpusDistribution.Text = "Korpusverteilung - TOP:";
      // 
      // chk_overview_analy_frequency
      // 
      this.chk_overview_analy_frequency.Location = new System.Drawing.Point(8, 66);
      this.chk_overview_analy_frequency.Name = "chk_overview_analy_frequency";
      this.chk_overview_analy_frequency.Size = new System.Drawing.Size(198, 32);
      this.chk_overview_analy_frequency.TabIndex = 2;
      this.chk_overview_analy_frequency.Text = "Frequenzanalyse - TOP:";
      // 
      // num_overview_analy_corpusDistribution
      // 
      this.num_overview_analy_corpusDistribution.Location = new System.Drawing.Point(212, 28);
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
      this.num_overview_analy_corpusDistribution.MinimumSize = new System.Drawing.Size(100, 0);
      this.num_overview_analy_corpusDistribution.Name = "num_overview_analy_corpusDistribution";
      // 
      // 
      // 
      this.num_overview_analy_corpusDistribution.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.num_overview_analy_corpusDistribution.Size = new System.Drawing.Size(162, 32);
      this.num_overview_analy_corpusDistribution.TabIndex = 4;
      this.num_overview_analy_corpusDistribution.TabStop = false;
      this.num_overview_analy_corpusDistribution.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // num_overview_analy_frequency
      // 
      this.num_overview_analy_frequency.Location = new System.Drawing.Point(212, 66);
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
      this.num_overview_analy_frequency.MinimumSize = new System.Drawing.Size(100, 0);
      this.num_overview_analy_frequency.Name = "num_overview_analy_frequency";
      // 
      // 
      // 
      this.num_overview_analy_frequency.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.num_overview_analy_frequency.Size = new System.Drawing.Size(162, 32);
      this.num_overview_analy_frequency.TabIndex = 5;
      this.num_overview_analy_frequency.TabStop = false;
      this.num_overview_analy_frequency.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // chk_overview_analy_kwic
      // 
      this.chk_overview_analy_kwic.Location = new System.Drawing.Point(9, 102);
      this.chk_overview_analy_kwic.Name = "chk_overview_analy_kwic";
      this.chk_overview_analy_kwic.Size = new System.Drawing.Size(429, 32);
      this.chk_overview_analy_kwic.TabIndex = 3;
      this.chk_overview_analy_kwic.Text = "Für TOP-Frequenzen Abfragen (s. u.) erstellen - POS-Filter:";
      // 
      // txt_overview_analy_posFilter
      // 
      this.txt_overview_analy_posFilter.Location = new System.Drawing.Point(11, 135);
      this.txt_overview_analy_posFilter.Multiline = true;
      this.txt_overview_analy_posFilter.Name = "txt_overview_analy_posFilter";
      this.txt_overview_analy_posFilter.NullText = "Hier POS-Tags eingeben um die Frequenzanalyse zu filtern...";
      this.txt_overview_analy_posFilter.Size = new System.Drawing.Size(761, 60);
      this.txt_overview_analy_posFilter.TabIndex = 10;
      this.txt_overview_analy_posFilter.Text = "NN;ADJA;ADJD;ADV;VVINF;VAINF;VMINF;VVIZU;VVPP;VMPP;VAPP;";
      ((Telerik.WinControls.UI.TextBoxWrapPanel)(this.txt_overview_analy_posFilter.GetChildAt(0).GetChildAt(1))).TextOrientation = System.Windows.Forms.Orientation.Horizontal;
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
      this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox1.HeaderText = "Übersichtsanalyse";
      this.radGroupBox1.Location = new System.Drawing.Point(0, 64);
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox1.Size = new System.Drawing.Size(780, 207);
      this.radGroupBox1.TabIndex = 11;
      this.radGroupBox1.Text = "Übersichtsanalyse";
      // 
      // chk_overview_analy_cooccurrences
      // 
      this.chk_overview_analy_cooccurrences.Location = new System.Drawing.Point(401, 28);
      this.chk_overview_analy_cooccurrences.Name = "chk_overview_analy_cooccurrences";
      this.chk_overview_analy_cooccurrences.Size = new System.Drawing.Size(188, 32);
      this.chk_overview_analy_cooccurrences.TabIndex = 11;
      this.chk_overview_analy_cooccurrences.Text = "Kookkurrenzen - TOP:";
      // 
      // num_overview_analy_cooccurrences
      // 
      this.num_overview_analy_cooccurrences.Location = new System.Drawing.Point(595, 28);
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
      this.num_overview_analy_cooccurrences.MinimumSize = new System.Drawing.Size(100, 0);
      this.num_overview_analy_cooccurrences.Name = "num_overview_analy_cooccurrences";
      // 
      // 
      // 
      this.num_overview_analy_cooccurrences.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.num_overview_analy_cooccurrences.Size = new System.Drawing.Size(177, 32);
      this.num_overview_analy_cooccurrences.TabIndex = 12;
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
      this.radGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox3.HeaderText = "Abfragen";
      this.radGroupBox3.Location = new System.Drawing.Point(0, 271);
      this.radGroupBox3.Name = "radGroupBox3";
      this.radGroupBox3.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox3.Size = new System.Drawing.Size(780, 140);
      this.radGroupBox3.TabIndex = 13;
      this.radGroupBox3.Text = "Abfragen";
      // 
      // chk_query_kwic
      // 
      this.chk_query_kwic.Location = new System.Drawing.Point(167, 98);
      this.chk_query_kwic.Name = "chk_query_kwic";
      this.chk_query_kwic.Size = new System.Drawing.Size(165, 32);
      this.chk_query_kwic.TabIndex = 13;
      this.chk_query_kwic.Text = "KWIC-Belegstellen";
      // 
      // chk_query_cooccurrences
      // 
      this.chk_query_cooccurrences.Location = new System.Drawing.Point(11, 98);
      this.chk_query_cooccurrences.Name = "chk_query_cooccurrences";
      this.chk_query_cooccurrences.Size = new System.Drawing.Size(143, 32);
      this.chk_query_cooccurrences.TabIndex = 12;
      this.chk_query_cooccurrences.Text = "Kookkurrenzen";
      // 
      // txt_query_kwicRequests
      // 
      this.txt_query_kwicRequests.Location = new System.Drawing.Point(11, 28);
      this.txt_query_kwicRequests.Multiline = true;
      this.txt_query_kwicRequests.Name = "txt_query_kwicRequests";
      this.txt_query_kwicRequests.NullText = "Geben Sie hier Begriffe ein, zu denen Sie eine Abfrage wünschen...";
      this.txt_query_kwicRequests.Size = new System.Drawing.Size(761, 64);
      this.txt_query_kwicRequests.TabIndex = 11;
      // 
      // btn_execute
      // 
      this.btn_execute.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.btn_execute.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.print;
      this.btn_execute.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
      this.btn_execute.Location = new System.Drawing.Point(0, 474);
      this.btn_execute.Name = "btn_execute";
      this.btn_execute.Size = new System.Drawing.Size(780, 33);
      this.btn_execute.TabIndex = 14;
      this.btn_execute.Text = "Erzeuge Analysebericht";
      this.btn_execute.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.btn_execute.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btn_execute.Click += new System.EventHandler(this.btn_execute_Click);
      // 
      // PaperLinguist
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btn_execute);
      this.Controls.Add(this.radGroupBox3);
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this.ihdPanel1);
      this.Name = "PaperLinguist";
      this.Size = new System.Drawing.Size(780, 507);
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

    private Controls.WinForm.IHDPanel ihdPanel1;
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
