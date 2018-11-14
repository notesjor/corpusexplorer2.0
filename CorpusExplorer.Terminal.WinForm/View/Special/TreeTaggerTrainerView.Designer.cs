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
      this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox1.HeaderText = Resources._1TreeTaggerTrainingsprogrammAuswählen;
      this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox1.Size = new System.Drawing.Size(780, 63);
      this.radGroupBox1.TabIndex = 10;
      this.radGroupBox1.Text = Resources._1TreeTaggerTrainingsprogrammAuswählen;
      // 
      // label1
      // 
      this.label1.AutoSize = false;
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Location = new System.Drawing.Point(5, 25);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(660, 33);
      this.label1.TabIndex = 0;
      this.label1.Text = Resources.BitteAuswählen;
      this.label1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btn_selectExe
      // 
      this.btn_selectExe.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_selectExe.Location = new System.Drawing.Point(665, 25);
      this.btn_selectExe.Name = "btn_selectExe";
      this.btn_selectExe.Size = new System.Drawing.Size(110, 33);
      this.btn_selectExe.TabIndex = 1;
      this.btn_selectExe.Text = Resources.Auswählen;
      this.btn_selectExe.Click += new System.EventHandler(this.btn_selectExe_Click);
      // 
      // radGroupBox2
      // 
      this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add(this.combo_layer);
      this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox2.HeaderText = Resources._2LayerAuswählen;
      this.radGroupBox2.Location = new System.Drawing.Point(0, 63);
      this.radGroupBox2.Name = "radGroupBox2";
      this.radGroupBox2.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox2.Size = new System.Drawing.Size(780, 63);
      this.radGroupBox2.TabIndex = 11;
      this.radGroupBox2.Text = Resources._2LayerAuswählen;
      // 
      // combo_layer
      // 
      this.combo_layer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.combo_layer.Location = new System.Drawing.Point(5, 25);
      this.combo_layer.Name = "combo_layer";
      this.combo_layer.NullText = Resources.BitteAuswählen;
      this.combo_layer.Size = new System.Drawing.Size(770, 32);
      this.combo_layer.TabIndex = 0;
      this.combo_layer.Click += new System.EventHandler(this.combo_layer_SelectedIndexChanged);
      // 
      // radGroupBox3
      // 
      this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox3.Controls.Add(this.radLabel1);
      this.radGroupBox3.Controls.Add(this.btn_gen_lexica);
      this.radGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox3.HeaderText = Resources._3LexikonErzeugen;
      this.radGroupBox3.Location = new System.Drawing.Point(0, 126);
      this.radGroupBox3.Name = "radGroupBox3";
      this.radGroupBox3.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox3.Size = new System.Drawing.Size(780, 63);
      this.radGroupBox3.TabIndex = 12;
      this.radGroupBox3.Text = Resources._3LexikonErzeugen;
      // 
      // radLabel1
      // 
      this.radLabel1.AutoSize = false;
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radLabel1.Location = new System.Drawing.Point(5, 25);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(660, 33);
      this.radLabel1.TabIndex = 3;
      this.radLabel1.Text = Resources.ErzeugenSieEinLexikonAusDemAktuellenSchnappschuss;
      this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btn_gen_lexica
      // 
      this.btn_gen_lexica.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_gen_lexica.Location = new System.Drawing.Point(665, 25);
      this.btn_gen_lexica.Name = "btn_gen_lexica";
      this.btn_gen_lexica.Size = new System.Drawing.Size(110, 33);
      this.btn_gen_lexica.TabIndex = 2;
      this.btn_gen_lexica.Text = Resources.Erzeugen;
      this.btn_gen_lexica.Click += new System.EventHandler(this.btn_gen_lexica_Click);
      // 
      // radGroupBox4
      // 
      this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox4.Controls.Add(this.radLabel2);
      this.radGroupBox4.Controls.Add(this.btn_gen_traindata);
      this.radGroupBox4.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox4.HeaderText = Resources._4TrainingsdatenErzeugen;
      this.radGroupBox4.Location = new System.Drawing.Point(0, 189);
      this.radGroupBox4.Name = "radGroupBox4";
      this.radGroupBox4.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox4.Size = new System.Drawing.Size(780, 63);
      this.radGroupBox4.TabIndex = 13;
      this.radGroupBox4.Text = Resources._4TrainingsdatenErzeugen;
      // 
      // radLabel2
      // 
      this.radLabel2.AutoSize = false;
      this.radLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radLabel2.Location = new System.Drawing.Point(5, 25);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Size = new System.Drawing.Size(660, 33);
      this.radLabel2.TabIndex = 4;
      this.radLabel2.Text = Resources.ErzeugenSieTrainingsdatenAusDemAktuellenSchnappschuss;
      this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btn_gen_traindata
      // 
      this.btn_gen_traindata.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_gen_traindata.Location = new System.Drawing.Point(665, 25);
      this.btn_gen_traindata.Name = "btn_gen_traindata";
      this.btn_gen_traindata.Size = new System.Drawing.Size(110, 33);
      this.btn_gen_traindata.TabIndex = 3;
      this.btn_gen_traindata.Text = Resources.Erzeugen;
      this.btn_gen_traindata.Click += new System.EventHandler(this.btn_gen_traindata_Click);
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.radGroupBox7);
      this.clearPanel1.Controls.Add(this.radGroupBox6);
      this.clearPanel1.Controls.Add(this.radGroupBox5);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.clearPanel1.Location = new System.Drawing.Point(0, 252);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Size = new System.Drawing.Size(780, 148);
      this.clearPanel1.TabIndex = 14;
      // 
      // radGroupBox7
      // 
      this.radGroupBox7.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox7.Controls.Add(this.btn_selectOutput);
      this.radGroupBox7.Controls.Add(this.btn_start);
      this.radGroupBox7.Dock = System.Windows.Forms.DockStyle.Right;
      this.radGroupBox7.HeaderText = Resources._6Ausgabe;
      this.radGroupBox7.Location = new System.Drawing.Point(580, 0);
      this.radGroupBox7.Name = "radGroupBox7";
      this.radGroupBox7.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox7.Size = new System.Drawing.Size(200, 148);
      this.radGroupBox7.TabIndex = 2;
      this.radGroupBox7.Text = Resources._6Ausgabe;
      // 
      // btn_selectOutput
      // 
      this.btn_selectOutput.Dock = System.Windows.Forms.DockStyle.Top;
      this.btn_selectOutput.Location = new System.Drawing.Point(5, 25);
      this.btn_selectOutput.Name = "btn_selectOutput";
      this.btn_selectOutput.Size = new System.Drawing.Size(190, 33);
      this.btn_selectOutput.TabIndex = 7;
      this.btn_selectOutput.Text = Resources.PARAusgabedatei;
      this.btn_selectOutput.Click += new System.EventHandler(this.btn_selectOutput_Click);
      // 
      // btn_start
      // 
      this.btn_start.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.btn_start.Location = new System.Drawing.Point(5, 110);
      this.btn_start.Name = "btn_start";
      this.btn_start.Size = new System.Drawing.Size(190, 33);
      this.btn_start.TabIndex = 6;
      this.btn_start.Text = Resources.TrainingStarten;
      this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
      // 
      // radGroupBox6
      // 
      this.radGroupBox6.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox6.Controls.Add(this.lbl_traindataCount);
      this.radGroupBox6.Controls.Add(this.btn_add_traindata);
      this.radGroupBox6.Controls.Add(this.btn_del_traindata);
      this.radGroupBox6.Dock = System.Windows.Forms.DockStyle.Left;
      this.radGroupBox6.HeaderText = Resources.AusgewählteTrainings;
      this.radGroupBox6.Location = new System.Drawing.Point(200, 0);
      this.radGroupBox6.Name = "radGroupBox6";
      this.radGroupBox6.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox6.Size = new System.Drawing.Size(200, 148);
      this.radGroupBox6.TabIndex = 1;
      this.radGroupBox6.Text = Resources.AusgewählteTrainings;
      // 
      // lbl_traindataCount
      // 
      this.lbl_traindataCount.AutoSize = false;
      this.lbl_traindataCount.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbl_traindataCount.Font = new System.Drawing.Font("Segoe UI Light", 20F);
      this.lbl_traindataCount.Location = new System.Drawing.Point(5, 25);
      this.lbl_traindataCount.Name = "lbl_traindataCount";
      this.lbl_traindataCount.Size = new System.Drawing.Size(190, 52);
      this.lbl_traindataCount.TabIndex = 7;
      this.lbl_traindataCount.Text = "0";
      this.lbl_traindataCount.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // btn_add_traindata
      // 
      this.btn_add_traindata.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.btn_add_traindata.Location = new System.Drawing.Point(5, 77);
      this.btn_add_traindata.Name = "btn_add_traindata";
      this.btn_add_traindata.Size = new System.Drawing.Size(190, 33);
      this.btn_add_traindata.TabIndex = 6;
      this.btn_add_traindata.Text = Resources.Hinzufügen;
      this.btn_add_traindata.Click += new System.EventHandler(this.btn_add_traindata_Click);
      // 
      // btn_del_traindata
      // 
      this.btn_del_traindata.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.btn_del_traindata.Location = new System.Drawing.Point(5, 110);
      this.btn_del_traindata.Name = "btn_del_traindata";
      this.btn_del_traindata.Size = new System.Drawing.Size(190, 33);
      this.btn_del_traindata.TabIndex = 5;
      this.btn_del_traindata.Text = Resources.AlleLöschen;
      this.btn_del_traindata.Click += new System.EventHandler(this.btn_del_traindata_Click);
      // 
      // radGroupBox5
      // 
      this.radGroupBox5.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox5.Controls.Add(this.lbl_lexicaCount);
      this.radGroupBox5.Controls.Add(this.btn_add_lexica);
      this.radGroupBox5.Controls.Add(this.btn_del_lexica);
      this.radGroupBox5.Dock = System.Windows.Forms.DockStyle.Left;
      this.radGroupBox5.HeaderText = Resources.AusgewählteLexika;
      this.radGroupBox5.Location = new System.Drawing.Point(0, 0);
      this.radGroupBox5.Name = "radGroupBox5";
      this.radGroupBox5.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox5.Size = new System.Drawing.Size(200, 148);
      this.radGroupBox5.TabIndex = 0;
      this.radGroupBox5.Text = Resources.AusgewählteLexika;
      // 
      // lbl_lexicaCount
      // 
      this.lbl_lexicaCount.AutoSize = false;
      this.lbl_lexicaCount.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbl_lexicaCount.Font = new System.Drawing.Font("Segoe UI Light", 20F);
      this.lbl_lexicaCount.Location = new System.Drawing.Point(5, 25);
      this.lbl_lexicaCount.Name = "lbl_lexicaCount";
      this.lbl_lexicaCount.Size = new System.Drawing.Size(190, 52);
      this.lbl_lexicaCount.TabIndex = 6;
      this.lbl_lexicaCount.Text = "0";
      this.lbl_lexicaCount.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // btn_add_lexica
      // 
      this.btn_add_lexica.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.btn_add_lexica.Location = new System.Drawing.Point(5, 77);
      this.btn_add_lexica.Name = "btn_add_lexica";
      this.btn_add_lexica.Size = new System.Drawing.Size(190, 33);
      this.btn_add_lexica.TabIndex = 5;
      this.btn_add_lexica.Text = Resources.Hinzufügen;
      this.btn_add_lexica.Click += new System.EventHandler(this.btn_add_lexica_Click);
      // 
      // btn_del_lexica
      // 
      this.btn_del_lexica.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.btn_del_lexica.Location = new System.Drawing.Point(5, 110);
      this.btn_del_lexica.Name = "btn_del_lexica";
      this.btn_del_lexica.Size = new System.Drawing.Size(190, 33);
      this.btn_del_lexica.TabIndex = 4;
      this.btn_del_lexica.Text = Resources.AlleLöschen;
      this.btn_del_lexica.Click += new System.EventHandler(this.btn_del_lexica_Click);
      // 
      // TreeTaggerTrainerView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
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
