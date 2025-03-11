namespace CorpusExplorer.Terminal.WinForm.Forms.Publishing
{
  partial class CorpusRandomizer
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorpusRandomizer));
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.btn_abort = new Telerik.WinControls.UI.RadButton();
      this.btn_ok = new Telerik.WinControls.UI.RadButton();
      this.headPanel1 = new CorpusExplorer.Tool4.DocPlusEditor.Controls.HeadPanel();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.chk_sentences = new Telerik.WinControls.UI.RadRadioButton();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.chk_sentences_and_words = new Telerik.WinControls.UI.RadRadioButton();
      this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
      this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
      this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
      this.chk_words = new Telerik.WinControls.UI.RadRadioButton();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_sentences)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_sentences_and_words)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_words)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.btn_abort);
      this.clearPanel1.Controls.Add(this.btn_ok);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.clearPanel1.Location = new System.Drawing.Point(0, 565);
      this.clearPanel1.Margin = new System.Windows.Forms.Padding(4);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Padding = new System.Windows.Forms.Padding(12);
      this.clearPanel1.Size = new System.Drawing.Size(498, 52);
      this.clearPanel1.TabIndex = 5;
      // 
      // btn_abort
      // 
      this.btn_abort.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_abort.Location = new System.Drawing.Point(12, 12);
      this.btn_abort.Margin = new System.Windows.Forms.Padding(4);
      this.btn_abort.Name = "btn_abort";
      this.btn_abort.Size = new System.Drawing.Size(138, 28);
      this.btn_abort.TabIndex = 1;
      this.btn_abort.Text = "Abbrechen";
      this.btn_abort.Click += new System.EventHandler(this.btn_abort_Click);
      // 
      // btn_ok
      // 
      this.btn_ok.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_ok.Location = new System.Drawing.Point(245, 12);
      this.btn_ok.Margin = new System.Windows.Forms.Padding(4);
      this.btn_ok.Name = "btn_ok";
      this.btn_ok.Size = new System.Drawing.Size(241, 28);
      this.btn_ok.TabIndex = 0;
      this.btn_ok.Text = "Randomizer starten";
      this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
      // 
      // headPanel1
      // 
      this.headPanel1.BackColor = System.Drawing.Color.White;
      this.headPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.headPanel1.Font = new System.Drawing.Font("Segoe UI", 12F);
      this.headPanel1.HeadPanelDescription = "Schützt das Korpusmaterial effektiv vor Rekonstruktion";
      this.headPanel1.HeadPanelImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.archive_download_48px;
      this.headPanel1.HeadPanelTitle = "Korpus zufällig verwürfeln";
      this.headPanel1.Location = new System.Drawing.Point(0, 0);
      this.headPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.headPanel1.Name = "headPanel1";
      this.headPanel1.Size = new System.Drawing.Size(498, 55);
      this.headPanel1.TabIndex = 6;
      // 
      // radLabel1
      // 
      this.radLabel1.AutoSize = false;
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel1.Location = new System.Drawing.Point(0, 55);
      this.radLabel1.Margin = new System.Windows.Forms.Padding(4);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(498, 132);
      this.radLabel1.TabIndex = 7;
      this.radLabel1.Text = resources.GetString("radLabel1.Text");
      this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
      // 
      // chk_sentences
      // 
      this.chk_sentences.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chk_sentences.Dock = System.Windows.Forms.DockStyle.Top;
      this.chk_sentences.Location = new System.Drawing.Point(0, 187);
      this.chk_sentences.Margin = new System.Windows.Forms.Padding(4);
      this.chk_sentences.Name = "chk_sentences";
      this.chk_sentences.Size = new System.Drawing.Size(219, 30);
      this.chk_sentences.TabIndex = 8;
      this.chk_sentences.Text = "Vetrtausche Sätze (schnell)";
      // 
      // radLabel2
      // 
      this.radLabel2.AutoSize = false;
      this.radLabel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel2.Location = new System.Drawing.Point(0, 217);
      this.radLabel2.Margin = new System.Windows.Forms.Padding(4);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Size = new System.Drawing.Size(498, 71);
      this.radLabel2.TabIndex = 9;
      this.radLabel2.Text = resources.GetString("radLabel2.Text");
      this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
      // 
      // chk_sentences_and_words
      // 
      this.chk_sentences_and_words.Dock = System.Windows.Forms.DockStyle.Top;
      this.chk_sentences_and_words.Location = new System.Drawing.Point(0, 388);
      this.chk_sentences_and_words.Margin = new System.Windows.Forms.Padding(4);
      this.chk_sentences_and_words.Name = "chk_sentences_and_words";
      this.chk_sentences_and_words.Size = new System.Drawing.Size(305, 30);
      this.chk_sentences_and_words.TabIndex = 10;
      this.chk_sentences_and_words.TabStop = false;
      this.chk_sentences_and_words.Text = "Vetrtausche Sätze und Worte (langsam)";
      // 
      // radLabel3
      // 
      this.radLabel3.AutoSize = false;
      this.radLabel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel3.Location = new System.Drawing.Point(0, 418);
      this.radLabel3.Margin = new System.Windows.Forms.Padding(4);
      this.radLabel3.Name = "radLabel3";
      this.radLabel3.Size = new System.Drawing.Size(498, 70);
      this.radLabel3.TabIndex = 11;
      this.radLabel3.Text = resources.GetString("radLabel3.Text");
      this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
      // 
      // radLabel4
      // 
      this.radLabel4.AutoSize = false;
      this.radLabel4.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel4.Location = new System.Drawing.Point(0, 514);
      this.radLabel4.Margin = new System.Windows.Forms.Padding(4);
      this.radLabel4.Name = "radLabel4";
      this.radLabel4.Size = new System.Drawing.Size(498, 51);
      this.radLabel4.TabIndex = 12;
      this.radLabel4.Text = "<html><strong>Wichtig:</strong> Dieser Schritt kann nicht rückgängig gemacht werd" +
    "en. Sie sollten auf jeden Fall das Originalmaterial sichern und nicht überschrei" +
    "ben.</html>";
      this.radLabel4.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
      // 
      // radLabel5
      // 
      this.radLabel5.AutoSize = false;
      this.radLabel5.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel5.Location = new System.Drawing.Point(0, 318);
      this.radLabel5.Margin = new System.Windows.Forms.Padding(4);
      this.radLabel5.Name = "radLabel5";
      this.radLabel5.Size = new System.Drawing.Size(498, 70);
      this.radLabel5.TabIndex = 14;
      this.radLabel5.Text = resources.GetString("radLabel5.Text");
      this.radLabel5.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
      // 
      // chk_words
      // 
      this.chk_words.Dock = System.Windows.Forms.DockStyle.Top;
      this.chk_words.Location = new System.Drawing.Point(0, 288);
      this.chk_words.Margin = new System.Windows.Forms.Padding(4);
      this.chk_words.Name = "chk_words";
      this.chk_words.Size = new System.Drawing.Size(217, 30);
      this.chk_words.TabIndex = 13;
      this.chk_words.TabStop = false;
      this.chk_words.Text = "Vetrtausche Worte (mittel)";
      // 
      // CorpusRandomizer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(498, 617);
      this.Controls.Add(this.radLabel3);
      this.Controls.Add(this.chk_sentences_and_words);
      this.Controls.Add(this.radLabel5);
      this.Controls.Add(this.chk_words);
      this.Controls.Add(this.radLabel4);
      this.Controls.Add(this.radLabel2);
      this.Controls.Add(this.chk_sentences);
      this.Controls.Add(this.radLabel1);
      this.Controls.Add(this.headPanel1);
      this.Controls.Add(this.clearPanel1);
      this.Name = "CorpusRandomizer";
      this.Text = "CorpusExplorer - CorpusRandomizer";
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_sentences)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_sentences_and_words)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_words)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Controls.WinForm.ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadButton btn_abort;
    private Telerik.WinControls.UI.RadButton btn_ok;
    private Tool4.DocPlusEditor.Controls.HeadPanel headPanel1;
    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.RadRadioButton chk_sentences;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private Telerik.WinControls.UI.RadRadioButton chk_sentences_and_words;
    private Telerik.WinControls.UI.RadLabel radLabel3;
    private Telerik.WinControls.UI.RadLabel radLabel4;
    private Telerik.WinControls.UI.RadRadioButton chk_words;
    private Telerik.WinControls.UI.RadLabel radLabel5;
  }
}