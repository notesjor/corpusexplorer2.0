using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.View.Special
{
  partial class TreeTaggerTrainerView
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeTaggerTrainerView));
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.label1 = new Telerik.WinControls.UI.RadLabel();
      this.btn_selectExe = new Telerik.WinControls.UI.RadButton();
      this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
      this.combo_layer = new Telerik.WinControls.UI.RadDropDownList();
      this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.btn_gen_lexica = new Telerik.WinControls.UI.RadButton();
      this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.btn_gen_traindata = new Telerik.WinControls.UI.RadButton();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.radGroupBox7 = new Telerik.WinControls.UI.RadGroupBox();
      this.btn_selectOutput = new Telerik.WinControls.UI.RadButton();
      this.btn_start = new Telerik.WinControls.UI.RadButton();
      this.radGroupBox6 = new Telerik.WinControls.UI.RadGroupBox();
      this.lbl_traindataCount = new Telerik.WinControls.UI.RadLabel();
      this.btn_add_traindata = new Telerik.WinControls.UI.RadButton();
      this.btn_del_traindata = new Telerik.WinControls.UI.RadButton();
      this.radGroupBox5 = new Telerik.WinControls.UI.RadGroupBox();
      this.lbl_lexicaCount = new Telerik.WinControls.UI.RadLabel();
      this.btn_add_lexica = new Telerik.WinControls.UI.RadButton();
      this.btn_del_lexica = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_selectExe)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
      this.radGroupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.combo_layer)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
      this.radGroupBox3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_gen_lexica)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
      this.radGroupBox4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_gen_traindata)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox7)).BeginInit();
      this.radGroupBox7.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_selectOutput)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_start)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox6)).BeginInit();
      this.radGroupBox6.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_traindataCount)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_add_traindata)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_del_traindata)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).BeginInit();
      this.radGroupBox5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_lexicaCount)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_add_lexica)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_del_lexica)).BeginInit();
      this.SuspendLayout();
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.label1);
      this.radGroupBox1.Controls.Add(this.btn_selectExe);
      resources.ApplyResources(this.radGroupBox1, "radGroupBox1");
      this.radGroupBox1.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._1TreeTaggerTrainingsprogrammAuswählen;
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._1TreeTaggerTrainingsprogrammAuswählen;
      // 
      // label1
      // 
      resources.ApplyResources(this.label1, "label1");
      this.label1.Name = "label1";
      // 
      // btn_selectExe
      // 
      resources.ApplyResources(this.btn_selectExe, "btn_selectExe");
      this.btn_selectExe.Name = "btn_selectExe";
      this.btn_selectExe.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Auswählen;
      this.btn_selectExe.Click += new System.EventHandler(this.btn_selectExe_Click);
      // 
      // radGroupBox2
      // 
      this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add(this.combo_layer);
      resources.ApplyResources(this.radGroupBox2, "radGroupBox2");
      this.radGroupBox2.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._2LayerAuswählen;
      this.radGroupBox2.Name = "radGroupBox2";
      this.radGroupBox2.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._2LayerAuswählen;
      // 
      // combo_layer
      // 
      resources.ApplyResources(this.combo_layer, "combo_layer");
      this.combo_layer.Name = "combo_layer";
      this.combo_layer.NullText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.BitteAuswählen;
      this.combo_layer.Click += new System.EventHandler(this.combo_layer_SelectedIndexChanged);
      // 
      // radGroupBox3
      // 
      this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox3.Controls.Add(this.radLabel1);
      this.radGroupBox3.Controls.Add(this.btn_gen_lexica);
      resources.ApplyResources(this.radGroupBox3, "radGroupBox3");
      this.radGroupBox3.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._3LexikonErzeugen;
      this.radGroupBox3.Name = "radGroupBox3";
      this.radGroupBox3.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._3LexikonErzeugen;
      // 
      // radLabel1
      // 
      resources.ApplyResources(this.radLabel1, "radLabel1");
      this.radLabel1.Name = "radLabel1";
      // 
      // btn_gen_lexica
      // 
      resources.ApplyResources(this.btn_gen_lexica, "btn_gen_lexica");
      this.btn_gen_lexica.Name = "btn_gen_lexica";
      this.btn_gen_lexica.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Erzeugen;
      this.btn_gen_lexica.Click += new System.EventHandler(this.btn_gen_lexica_Click);
      // 
      // radGroupBox4
      // 
      this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox4.Controls.Add(this.radLabel2);
      this.radGroupBox4.Controls.Add(this.btn_gen_traindata);
      resources.ApplyResources(this.radGroupBox4, "radGroupBox4");
      this.radGroupBox4.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._4TrainingsdatenErzeugen;
      this.radGroupBox4.Name = "radGroupBox4";
      this.radGroupBox4.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._4TrainingsdatenErzeugen;
      // 
      // radLabel2
      // 
      resources.ApplyResources(this.radLabel2, "radLabel2");
      this.radLabel2.Name = "radLabel2";
      // 
      // btn_gen_traindata
      // 
      resources.ApplyResources(this.btn_gen_traindata, "btn_gen_traindata");
      this.btn_gen_traindata.Name = "btn_gen_traindata";
      this.btn_gen_traindata.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Erzeugen;
      this.btn_gen_traindata.Click += new System.EventHandler(this.btn_gen_traindata_Click);
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.radGroupBox7);
      this.clearPanel1.Controls.Add(this.radGroupBox6);
      this.clearPanel1.Controls.Add(this.radGroupBox5);
      resources.ApplyResources(this.clearPanel1, "clearPanel1");
      this.clearPanel1.Name = "clearPanel1";
      // 
      // radGroupBox7
      // 
      this.radGroupBox7.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox7.Controls.Add(this.btn_selectOutput);
      this.radGroupBox7.Controls.Add(this.btn_start);
      resources.ApplyResources(this.radGroupBox7, "radGroupBox7");
      this.radGroupBox7.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._6Ausgabe;
      this.radGroupBox7.Name = "radGroupBox7";
      this.radGroupBox7.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources._6Ausgabe;
      // 
      // btn_selectOutput
      // 
      resources.ApplyResources(this.btn_selectOutput, "btn_selectOutput");
      this.btn_selectOutput.Name = "btn_selectOutput";
      this.btn_selectOutput.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.PARAusgabedatei;
      this.btn_selectOutput.Click += new System.EventHandler(this.btn_selectOutput_Click);
      // 
      // btn_start
      // 
      resources.ApplyResources(this.btn_start, "btn_start");
      this.btn_start.Name = "btn_start";
      this.btn_start.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.TrainingStarten;
      this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
      // 
      // radGroupBox6
      // 
      this.radGroupBox6.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox6.Controls.Add(this.lbl_traindataCount);
      this.radGroupBox6.Controls.Add(this.btn_add_traindata);
      this.radGroupBox6.Controls.Add(this.btn_del_traindata);
      resources.ApplyResources(this.radGroupBox6, "radGroupBox6");
      this.radGroupBox6.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AusgewählteTrainings;
      this.radGroupBox6.Name = "radGroupBox6";
      this.radGroupBox6.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AusgewählteTrainings;
      // 
      // lbl_traindataCount
      // 
      resources.ApplyResources(this.lbl_traindataCount, "lbl_traindataCount");
      this.lbl_traindataCount.Name = "lbl_traindataCount";
      // 
      // btn_add_traindata
      // 
      resources.ApplyResources(this.btn_add_traindata, "btn_add_traindata");
      this.btn_add_traindata.Name = "btn_add_traindata";
      this.btn_add_traindata.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Hinzufügen;
      this.btn_add_traindata.Click += new System.EventHandler(this.btn_add_traindata_Click);
      // 
      // btn_del_traindata
      // 
      resources.ApplyResources(this.btn_del_traindata, "btn_del_traindata");
      this.btn_del_traindata.Name = "btn_del_traindata";
      this.btn_del_traindata.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AlleLöschen;
      this.btn_del_traindata.Click += new System.EventHandler(this.btn_del_traindata_Click);
      // 
      // radGroupBox5
      // 
      this.radGroupBox5.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox5.Controls.Add(this.lbl_lexicaCount);
      this.radGroupBox5.Controls.Add(this.btn_add_lexica);
      this.radGroupBox5.Controls.Add(this.btn_del_lexica);
      resources.ApplyResources(this.radGroupBox5, "radGroupBox5");
      this.radGroupBox5.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AusgewählteLexika;
      this.radGroupBox5.Name = "radGroupBox5";
      this.radGroupBox5.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AusgewählteLexika;
      // 
      // lbl_lexicaCount
      // 
      resources.ApplyResources(this.lbl_lexicaCount, "lbl_lexicaCount");
      this.lbl_lexicaCount.Name = "lbl_lexicaCount";
      // 
      // btn_add_lexica
      // 
      resources.ApplyResources(this.btn_add_lexica, "btn_add_lexica");
      this.btn_add_lexica.Name = "btn_add_lexica";
      this.btn_add_lexica.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.Hinzufügen;
      this.btn_add_lexica.Click += new System.EventHandler(this.btn_add_lexica_Click);
      // 
      // btn_del_lexica
      // 
      resources.ApplyResources(this.btn_del_lexica, "btn_del_lexica");
      this.btn_del_lexica.Name = "btn_del_lexica";
      this.btn_del_lexica.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.AlleLöschen;
      this.btn_del_lexica.Click += new System.EventHandler(this.btn_del_lexica_Click);
      // 
      // TreeTaggerTrainerView
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.clearPanel1);
      this.Controls.Add(this.radGroupBox4);
      this.Controls.Add(this.radGroupBox3);
      this.Controls.Add(this.radGroupBox2);
      this.Controls.Add(this.radGroupBox1);
      this.Name = "TreeTaggerTrainerView";
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_selectExe)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
      this.radGroupBox2.ResumeLayout(false);
      this.radGroupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.combo_layer)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
      this.radGroupBox3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_gen_lexica)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
      this.radGroupBox4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_gen_traindata)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox7)).EndInit();
      this.radGroupBox7.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_selectOutput)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_start)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox6)).EndInit();
      this.radGroupBox6.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.lbl_traindataCount)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_add_traindata)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_del_traindata)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).EndInit();
      this.radGroupBox5.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.lbl_lexicaCount)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_add_lexica)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_del_lexica)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadLabel label1;
    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.RadButton btn_selectExe;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
    private Telerik.WinControls.UI.RadDropDownList combo_layer;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
    private Telerik.WinControls.UI.RadButton btn_gen_lexica;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private Telerik.WinControls.UI.RadButton btn_gen_traindata;
    private Controls.WinForm.ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox7;
    private Telerik.WinControls.UI.RadButton btn_selectOutput;
    private Telerik.WinControls.UI.RadButton btn_start;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox6;
    private Telerik.WinControls.UI.RadLabel lbl_traindataCount;
    private Telerik.WinControls.UI.RadButton btn_add_traindata;
    private Telerik.WinControls.UI.RadButton btn_del_traindata;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox5;
    private Telerik.WinControls.UI.RadLabel lbl_lexicaCount;
    private Telerik.WinControls.UI.RadButton btn_add_lexica;
    private Telerik.WinControls.UI.RadButton btn_del_lexica;

  }
}
