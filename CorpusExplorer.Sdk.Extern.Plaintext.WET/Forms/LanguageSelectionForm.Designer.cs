namespace CorpusExplorer.Sdk.Extern.Plaintext.WET.Forms
{
  partial class LanguageSelectionForm
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
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.combo_languages = new Telerik.WinControls.UI.RadDropDownList();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btn_abort = new Telerik.WinControls.UI.RadButton();
      this.btn_ok = new Telerik.WinControls.UI.RadButton();
      this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
      this.radAutoCompleteBox1 = new Telerik.WinControls.UI.RadAutoCompleteBox();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.combo_languages)).BeginInit();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
      this.radGroupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radAutoCompleteBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radLabel1
      // 
      this.radLabel1.AutoSize = false;
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel1.Location = new System.Drawing.Point(0, 0);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(489, 52);
      this.radLabel1.TabIndex = 0;
      this.radLabel1.Text = "Reduzieren Sie die Ergebnissmenge schnell und effizient auf eine einzelne Sprache" +
    " oder mehrere Domains.";
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.combo_languages);
      this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox1.HeaderText = "Sprachfilter - autom. Erkennung (langsam):";
      this.radGroupBox1.Location = new System.Drawing.Point(0, 52);
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox1.Size = new System.Drawing.Size(489, 63);
      this.radGroupBox1.TabIndex = 1;
      this.radGroupBox1.Text = "Sprachfilter - autom. Erkennung (langsam):";
      // 
      // combo_languages
      // 
      this.combo_languages.Dock = System.Windows.Forms.DockStyle.Fill;
      this.combo_languages.Location = new System.Drawing.Point(5, 25);
      this.combo_languages.Name = "combo_languages";
      this.combo_languages.NullText = "Bitte wählen Sie eine Sprache aus...";
      this.combo_languages.Size = new System.Drawing.Size(479, 33);
      this.combo_languages.TabIndex = 0;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btn_abort);
      this.panel1.Controls.Add(this.btn_ok);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 178);
      this.panel1.Name = "panel1";
      this.panel1.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
      this.panel1.Size = new System.Drawing.Size(489, 47);
      this.panel1.TabIndex = 2;
      // 
      // btn_abort
      // 
      this.btn_abort.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_abort.ForeColor = System.Drawing.Color.DarkRed;
      this.btn_abort.Location = new System.Drawing.Point(5, 10);
      this.btn_abort.Name = "btn_abort";
      this.btn_abort.Size = new System.Drawing.Size(110, 32);
      this.btn_abort.TabIndex = 1;
      this.btn_abort.Text = "Abbrechen";
      this.btn_abort.Click += new System.EventHandler(this.btn_abort_Click);
      // 
      // btn_ok
      // 
      this.btn_ok.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_ok.ForeColor = System.Drawing.Color.OliveDrab;
      this.btn_ok.Location = new System.Drawing.Point(374, 10);
      this.btn_ok.Name = "btn_ok";
      this.btn_ok.Size = new System.Drawing.Size(110, 32);
      this.btn_ok.TabIndex = 0;
      this.btn_ok.Text = "OK";
      this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
      // 
      // radGroupBox2
      // 
      this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add(this.radAutoCompleteBox1);
      this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox2.HeaderText = "Domainfilter (schnell / optional):";
      this.radGroupBox2.Location = new System.Drawing.Point(0, 115);
      this.radGroupBox2.Name = "radGroupBox2";
      this.radGroupBox2.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox2.Size = new System.Drawing.Size(489, 63);
      this.radGroupBox2.TabIndex = 3;
      this.radGroupBox2.Text = "Domainfilter (schnell / optional):";
      this.radGroupBox2.UseMnemonic = false;
      // 
      // radAutoCompleteBox1
      // 
      this.radAutoCompleteBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radAutoCompleteBox1.Location = new System.Drawing.Point(5, 25);
      this.radAutoCompleteBox1.Name = "radAutoCompleteBox1";
      this.radAutoCompleteBox1.Size = new System.Drawing.Size(479, 33);
      this.radAutoCompleteBox1.TabIndex = 0;
      // 
      // LanguageSelectionForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(489, 225);
      this.ControlBox = false;
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.radGroupBox2);
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this.radLabel1);
      this.IconScaling = Telerik.WinControls.Enumerations.ImageScaling.None;
      this.Name = "LanguageSelectionForm";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.ShowInTaskbar = false;
      this.Text = "WET-Filter konfigurieren...";
      this.Load += new System.EventHandler(this.LanguageSelectionForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.combo_languages)).EndInit();
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
      this.radGroupBox2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radAutoCompleteBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadDropDownList combo_languages;
    private System.Windows.Forms.Panel panel1;
    private Telerik.WinControls.UI.RadButton btn_abort;
    private Telerik.WinControls.UI.RadButton btn_ok;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
    private Telerik.WinControls.UI.RadAutoCompleteBox radAutoCompleteBox1;
  }
}