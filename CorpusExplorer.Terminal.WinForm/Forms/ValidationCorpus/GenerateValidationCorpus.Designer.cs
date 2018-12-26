namespace CorpusExplorer.Terminal.WinForm.Forms.ValidationCorpus
{
  partial class GenerateValidationCorpus
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerateValidationCorpus));
      this.ihdPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.txt_c = new Telerik.WinControls.UI.RadTextBox();
      this.txt_b = new Telerik.WinControls.UI.RadTextBox();
      this.txt_a = new Telerik.WinControls.UI.RadTextBox();
      this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
      this.cnt_AB = new Telerik.WinControls.UI.RadSpinEditor();
      this.cnt_AnotB = new Telerik.WinControls.UI.RadSpinEditor();
      this.cnt_notAnotB = new Telerik.WinControls.UI.RadSpinEditor();
      this.cnt_notAB = new Telerik.WinControls.UI.RadSpinEditor();
      this.lbl_isNotB = new Telerik.WinControls.UI.RadLabel();
      this.lbl_isB = new Telerik.WinControls.UI.RadLabel();
      this.lbl_isNotA = new Telerik.WinControls.UI.RadLabel();
      this.lbl_isA = new Telerik.WinControls.UI.RadLabel();
      this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
      this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
      this.btn_generate = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_c)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_b)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_a)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
      this.radGroupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cnt_AB)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cnt_AnotB)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cnt_notAnotB)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cnt_notAB)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_isNotB)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_isB)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_isNotA)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_isA)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
      this.radGroupBox3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_generate)).BeginInit();
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
      this.ihdPanel1.IHDDescription = "Damit der CorpusExplorer keine Blackbox für Sie ist.";
      this.ihdPanel1.IHDHeader = "Überprüfen Sie den CorpusExplorer";
      this.ihdPanel1.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.test_properties;
      this.ihdPanel1.Name = "ihdPanel1";
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.txt_c);
      this.radGroupBox1.Controls.Add(this.txt_b);
      this.radGroupBox1.Controls.Add(this.txt_a);
      resources.ApplyResources(this.radGroupBox1, "radGroupBox1");
      this.radGroupBox1.Name = "radGroupBox1";
      // 
      // txt_c
      // 
      resources.ApplyResources(this.txt_c, "txt_c");
      this.txt_c.Name = "txt_c";
      this.txt_c.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.txt_c.TextChanged += new System.EventHandler(this.txt_c_TextChanged);
      // 
      // txt_b
      // 
      resources.ApplyResources(this.txt_b, "txt_b");
      this.txt_b.Name = "txt_b";
      this.txt_b.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.txt_b.TextChanged += new System.EventHandler(this.txt_b_TextChanged);
      // 
      // txt_a
      // 
      resources.ApplyResources(this.txt_a, "txt_a");
      this.txt_a.Name = "txt_a";
      this.txt_a.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.txt_a.TextChanged += new System.EventHandler(this.txt_a_TextChanged);
      // 
      // radGroupBox2
      // 
      this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add(this.cnt_AB);
      this.radGroupBox2.Controls.Add(this.cnt_AnotB);
      this.radGroupBox2.Controls.Add(this.cnt_notAnotB);
      this.radGroupBox2.Controls.Add(this.cnt_notAB);
      this.radGroupBox2.Controls.Add(this.lbl_isNotB);
      this.radGroupBox2.Controls.Add(this.lbl_isB);
      this.radGroupBox2.Controls.Add(this.lbl_isNotA);
      this.radGroupBox2.Controls.Add(this.lbl_isA);
      resources.ApplyResources(this.radGroupBox2, "radGroupBox2");
      this.radGroupBox2.Name = "radGroupBox2";
      // 
      // cnt_AB
      // 
      resources.ApplyResources(this.cnt_AB, "cnt_AB");
      this.cnt_AB.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
      this.cnt_AB.Name = "cnt_AB";
      this.cnt_AB.NullableValue = new decimal(new int[] {
            20,
            0,
            0,
            0});
      // 
      // 
      // 
      this.cnt_AB.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.cnt_AB.TabStop = false;
      this.cnt_AB.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
      this.cnt_AB.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
      this.cnt_AB.ValueChanged += new System.EventHandler(this.cnt_AB_ValueChanged);
      // 
      // cnt_AnotB
      // 
      resources.ApplyResources(this.cnt_AnotB, "cnt_AnotB");
      this.cnt_AnotB.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
      this.cnt_AnotB.Name = "cnt_AnotB";
      this.cnt_AnotB.NullableValue = new decimal(new int[] {
            500,
            0,
            0,
            0});
      // 
      // 
      // 
      this.cnt_AnotB.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.cnt_AnotB.TabStop = false;
      this.cnt_AnotB.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
      this.cnt_AnotB.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
      this.cnt_AnotB.ValueChanged += new System.EventHandler(this.cnt_AnotB_ValueChanged);
      // 
      // cnt_notAnotB
      // 
      resources.ApplyResources(this.cnt_notAnotB, "cnt_notAnotB");
      this.cnt_notAnotB.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
      this.cnt_notAnotB.Name = "cnt_notAnotB";
      this.cnt_notAnotB.NullableValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
      // 
      // 
      // 
      this.cnt_notAnotB.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.cnt_notAnotB.TabStop = false;
      this.cnt_notAnotB.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
      this.cnt_notAnotB.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
      this.cnt_notAnotB.ValueChanged += new System.EventHandler(this.cnt_notAnotB_ValueChanged);
      // 
      // cnt_notAB
      // 
      resources.ApplyResources(this.cnt_notAB, "cnt_notAB");
      this.cnt_notAB.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
      this.cnt_notAB.Name = "cnt_notAB";
      this.cnt_notAB.NullableValue = new decimal(new int[] {
            200,
            0,
            0,
            0});
      // 
      // 
      // 
      this.cnt_notAB.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.cnt_notAB.TabStop = false;
      this.cnt_notAB.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
      this.cnt_notAB.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
      this.cnt_notAB.ValueChanged += new System.EventHandler(this.cnt_notAB_ValueChanged);
      // 
      // lbl_isNotB
      // 
      resources.ApplyResources(this.lbl_isNotB, "lbl_isNotB");
      this.lbl_isNotB.Name = "lbl_isNotB";
      // 
      // lbl_isB
      // 
      resources.ApplyResources(this.lbl_isB, "lbl_isB");
      this.lbl_isB.Name = "lbl_isB";
      // 
      // lbl_isNotA
      // 
      resources.ApplyResources(this.lbl_isNotA, "lbl_isNotA");
      this.lbl_isNotA.Name = "lbl_isNotA";
      // 
      // lbl_isA
      // 
      resources.ApplyResources(this.lbl_isA, "lbl_isA");
      this.lbl_isA.Name = "lbl_isA";
      // 
      // radGroupBox3
      // 
      this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox3.Controls.Add(this.radLabel5);
      this.radGroupBox3.Controls.Add(this.btn_generate);
      resources.ApplyResources(this.radGroupBox3, "radGroupBox3");
      this.radGroupBox3.Name = "radGroupBox3";
      // 
      // radLabel5
      // 
      resources.ApplyResources(this.radLabel5, "radLabel5");
      this.radLabel5.Name = "radLabel5";
      // 
      // btn_generate
      // 
      resources.ApplyResources(this.btn_generate, "btn_generate");
      this.btn_generate.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_generate.Name = "btn_generate";
      this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
      // 
      // GenerateValidationCorpus
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.radGroupBox3);
      this.Controls.Add(this.radGroupBox2);
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this.ihdPanel1);
      this.DisplayAbort = true;
      this.Name = "GenerateValidationCorpus";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Controls.SetChildIndex(this.ihdPanel1, 0);
      this.Controls.SetChildIndex(this.radGroupBox1, 0);
      this.Controls.SetChildIndex(this.radGroupBox2, 0);
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.radGroupBox3, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_c)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_b)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_a)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
      this.radGroupBox2.ResumeLayout(false);
      this.radGroupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cnt_AB)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cnt_AnotB)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cnt_notAnotB)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cnt_notAB)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_isNotB)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_isB)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_isNotA)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_isA)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
      this.radGroupBox3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_generate)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.WinForm.IHDPanel ihdPanel1;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadTextBox txt_c;
    private Telerik.WinControls.UI.RadTextBox txt_b;
    private Telerik.WinControls.UI.RadTextBox txt_a;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
    private Telerik.WinControls.UI.RadSpinEditor cnt_AB;
    private Telerik.WinControls.UI.RadSpinEditor cnt_AnotB;
    private Telerik.WinControls.UI.RadSpinEditor cnt_notAnotB;
    private Telerik.WinControls.UI.RadSpinEditor cnt_notAB;
    private Telerik.WinControls.UI.RadLabel lbl_isNotB;
    private Telerik.WinControls.UI.RadLabel lbl_isB;
    private Telerik.WinControls.UI.RadLabel lbl_isNotA;
    private Telerik.WinControls.UI.RadLabel lbl_isA;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
    private Telerik.WinControls.UI.RadLabel radLabel5;
    private Telerik.WinControls.UI.RadButton btn_generate;
  }
}