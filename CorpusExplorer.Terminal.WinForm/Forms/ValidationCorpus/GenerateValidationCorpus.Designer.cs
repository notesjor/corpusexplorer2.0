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
      this.radPanel1.Location = new System.Drawing.Point(0, 439);
      this.radPanel1.Size = new System.Drawing.Size(519, 38);
      // 
      // ihdPanel1
      // 
      this.ihdPanel1.BackColor = System.Drawing.Color.White;
      this.ihdPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihdPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihdPanel1.IHDDeescribtion = "Damit der CorpusExplorer keine Blackbox für Sie ist.";
      this.ihdPanel1.IHDHeader = "Überprüfen Sie den CorpusExplorer";
      this.ihdPanel1.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.test_properties;
      this.ihdPanel1.Location = new System.Drawing.Point(0, 0);
      this.ihdPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.ihdPanel1.Name = "ihdPanel1";
      this.ihdPanel1.Size = new System.Drawing.Size(519, 64);
      this.ihdPanel1.TabIndex = 1;
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.txt_c);
      this.radGroupBox1.Controls.Add(this.txt_b);
      this.radGroupBox1.Controls.Add(this.txt_a);
      this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox1.HeaderText = "1. Definieren Sie drei Token";
      this.radGroupBox1.Location = new System.Drawing.Point(0, 64);
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox1.Size = new System.Drawing.Size(519, 71);
      this.radGroupBox1.TabIndex = 2;
      this.radGroupBox1.Text = "1. Definieren Sie drei Token";
      // 
      // txt_c
      // 
      this.txt_c.Location = new System.Drawing.Point(346, 28);
      this.txt_c.Name = "txt_c";
      this.txt_c.Size = new System.Drawing.Size(161, 32);
      this.txt_c.TabIndex = 1;
      this.txt_c.Text = "C";
      this.txt_c.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.txt_c.TextChanged += new System.EventHandler(this.txt_c_TextChanged);
      // 
      // txt_b
      // 
      this.txt_b.Location = new System.Drawing.Point(179, 28);
      this.txt_b.Name = "txt_b";
      this.txt_b.Size = new System.Drawing.Size(161, 32);
      this.txt_b.TabIndex = 1;
      this.txt_b.Text = "B";
      this.txt_b.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.txt_b.TextChanged += new System.EventHandler(this.txt_b_TextChanged);
      // 
      // txt_a
      // 
      this.txt_a.Location = new System.Drawing.Point(12, 28);
      this.txt_a.Name = "txt_a";
      this.txt_a.Size = new System.Drawing.Size(161, 32);
      this.txt_a.TabIndex = 0;
      this.txt_a.Text = "A";
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
      this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox2.HeaderText = "2. Definieren Sie die Satzfrequenz";
      this.radGroupBox2.Location = new System.Drawing.Point(0, 135);
      this.radGroupBox2.Name = "radGroupBox2";
      this.radGroupBox2.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox2.Size = new System.Drawing.Size(519, 147);
      this.radGroupBox2.TabIndex = 3;
      this.radGroupBox2.Text = "2. Definieren Sie die Satzfrequenz";
      // 
      // cnt_AB
      // 
      this.cnt_AB.Location = new System.Drawing.Point(179, 60);
      this.cnt_AB.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
      this.cnt_AB.MinimumSize = new System.Drawing.Size(100, 0);
      this.cnt_AB.Name = "cnt_AB";
      // 
      // 
      // 
      this.cnt_AB.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.cnt_AB.Size = new System.Drawing.Size(161, 32);
      this.cnt_AB.TabIndex = 2;
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
      this.cnt_AnotB.Location = new System.Drawing.Point(179, 98);
      this.cnt_AnotB.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
      this.cnt_AnotB.MinimumSize = new System.Drawing.Size(100, 0);
      this.cnt_AnotB.Name = "cnt_AnotB";
      // 
      // 
      // 
      this.cnt_AnotB.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.cnt_AnotB.Size = new System.Drawing.Size(161, 32);
      this.cnt_AnotB.TabIndex = 2;
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
      this.cnt_notAnotB.Location = new System.Drawing.Point(346, 98);
      this.cnt_notAnotB.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
      this.cnt_notAnotB.MinimumSize = new System.Drawing.Size(100, 0);
      this.cnt_notAnotB.Name = "cnt_notAnotB";
      // 
      // 
      // 
      this.cnt_notAnotB.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.cnt_notAnotB.Size = new System.Drawing.Size(161, 32);
      this.cnt_notAnotB.TabIndex = 2;
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
      this.cnt_notAB.Location = new System.Drawing.Point(346, 60);
      this.cnt_notAB.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
      this.cnt_notAB.MinimumSize = new System.Drawing.Size(100, 0);
      this.cnt_notAB.Name = "cnt_notAB";
      // 
      // 
      // 
      this.cnt_notAB.RootElement.MinSize = new System.Drawing.Size(100, 0);
      this.cnt_notAB.Size = new System.Drawing.Size(161, 32);
      this.cnt_notAB.TabIndex = 1;
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
      this.lbl_isNotB.AutoSize = false;
      this.lbl_isNotB.Location = new System.Drawing.Point(12, 102);
      this.lbl_isNotB.Name = "lbl_isNotB";
      this.lbl_isNotB.Size = new System.Drawing.Size(161, 23);
      this.lbl_isNotB.TabIndex = 5;
      this.lbl_isNotB.Text = "nicht B";
      this.lbl_isNotB.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lbl_isB
      // 
      this.lbl_isB.AutoSize = false;
      this.lbl_isB.Location = new System.Drawing.Point(12, 64);
      this.lbl_isB.Name = "lbl_isB";
      this.lbl_isB.Size = new System.Drawing.Size(161, 23);
      this.lbl_isB.TabIndex = 4;
      this.lbl_isB.Text = "B";
      this.lbl_isB.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lbl_isNotA
      // 
      this.lbl_isNotA.AutoSize = false;
      this.lbl_isNotA.Location = new System.Drawing.Point(346, 32);
      this.lbl_isNotA.Name = "lbl_isNotA";
      this.lbl_isNotA.Size = new System.Drawing.Size(161, 23);
      this.lbl_isNotA.TabIndex = 4;
      this.lbl_isNotA.Text = "nicht A";
      this.lbl_isNotA.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
      // 
      // lbl_isA
      // 
      this.lbl_isA.AutoSize = false;
      this.lbl_isA.Location = new System.Drawing.Point(179, 32);
      this.lbl_isA.Name = "lbl_isA";
      this.lbl_isA.Size = new System.Drawing.Size(161, 23);
      this.lbl_isA.TabIndex = 3;
      this.lbl_isA.Text = "A";
      this.lbl_isA.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
      // 
      // radGroupBox3
      // 
      this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox3.Controls.Add(this.radLabel5);
      this.radGroupBox3.Controls.Add(this.btn_generate);
      this.radGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox3.HeaderText = "3. Erzeuge Korpus";
      this.radGroupBox3.Location = new System.Drawing.Point(0, 282);
      this.radGroupBox3.Name = "radGroupBox3";
      this.radGroupBox3.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox3.Size = new System.Drawing.Size(519, 151);
      this.radGroupBox3.TabIndex = 4;
      this.radGroupBox3.Text = "3. Erzeuge Korpus";
      // 
      // radLabel5
      // 
      this.radLabel5.AutoSize = false;
      this.radLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel5.Location = new System.Drawing.Point(5, 57);
      this.radLabel5.Name = "radLabel5";
      this.radLabel5.Size = new System.Drawing.Size(509, 89);
      this.radLabel5.TabIndex = 1;
      this.radLabel5.Text = resources.GetString("radLabel5.Text");
      // 
      // btn_generate
      // 
      this.btn_generate.Dock = System.Windows.Forms.DockStyle.Top;
      this.btn_generate.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_generate.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
      this.btn_generate.Location = new System.Drawing.Point(5, 25);
      this.btn_generate.Name = "btn_generate";
      this.btn_generate.Size = new System.Drawing.Size(509, 32);
      this.btn_generate.TabIndex = 0;
      this.btn_generate.Text = "Klicken Sie hier um das Test-Korpus zu erstellen...";
      this.btn_generate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.btn_generate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
      // 
      // GenerateValidationCorpus
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(519, 477);
      this.Controls.Add(this.radGroupBox3);
      this.Controls.Add(this.radGroupBox2);
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this.ihdPanel1);
      this.Name = "GenerateValidationCorpus";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "Test-Korpus erzeugen";
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