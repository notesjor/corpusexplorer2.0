namespace CorpusExplorer.Tool4.DocPlusEditor.Forms
{
  partial class TextAutoFixer
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
      this.btn_abort = new Telerik.WinControls.UI.RadButton();
      this.btn_ok = new Telerik.WinControls.UI.RadButton();
      this.chk_remove_space = new Telerik.WinControls.UI.RadCheckBox();
      this.chk_remove_linebreak = new Telerik.WinControls.UI.RadCheckBox();
      this.chk_remove_xmlstuff = new Telerik.WinControls.UI.RadCheckBox();
      this.chk_remove_htmlecoding = new Telerik.WinControls.UI.RadCheckBox();
      this.chk_in_corpus = new Telerik.WinControls.UI.RadCheckBox();
      this.chk_in_meta = new Telerik.WinControls.UI.RadCheckBox();
      this.chk_in_text = new Telerik.WinControls.UI.RadCheckBox();
      this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
      this.chk_remove_linebreakPdf = new Telerik.WinControls.UI.RadCheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_remove_space)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_remove_linebreak)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_remove_xmlstuff)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_remove_htmlecoding)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_in_corpus)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_in_meta)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_in_text)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_remove_linebreakPdf)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radLabel1
      // 
      this.radLabel1.Location = new System.Drawing.Point(17, 16);
      this.radLabel1.Margin = new System.Windows.Forms.Padding(4);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(200, 23);
      this.radLabel1.TabIndex = 0;
      this.radLabel1.Text = "Wende folge Korrekturen an:";
      // 
      // btn_abort
      // 
      this.btn_abort.DialogResult = System.Windows.Forms.DialogResult.No;
      this.btn_abort.Location = new System.Drawing.Point(299, 362);
      this.btn_abort.Margin = new System.Windows.Forms.Padding(4);
      this.btn_abort.Name = "btn_abort";
      this.btn_abort.Size = new System.Drawing.Size(147, 46);
      this.btn_abort.TabIndex = 6;
      this.btn_abort.Text = "Abbrechen";
      // 
      // btn_ok
      // 
      this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.Yes;
      this.btn_ok.Location = new System.Drawing.Point(17, 362);
      this.btn_ok.Margin = new System.Windows.Forms.Padding(4);
      this.btn_ok.Name = "btn_ok";
      this.btn_ok.Size = new System.Drawing.Size(147, 46);
      this.btn_ok.TabIndex = 5;
      this.btn_ok.Text = "Anwenden";
      this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
      // 
      // chk_remove_space
      // 
      this.chk_remove_space.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chk_remove_space.Location = new System.Drawing.Point(17, 47);
      this.chk_remove_space.Margin = new System.Windows.Forms.Padding(4);
      this.chk_remove_space.Name = "chk_remove_space";
      this.chk_remove_space.Size = new System.Drawing.Size(263, 32);
      this.chk_remove_space.TabIndex = 7;
      this.chk_remove_space.Text = "Doppelete Leerzeichen entfernen";
      // 
      // chk_remove_linebreak
      // 
      this.chk_remove_linebreak.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chk_remove_linebreak.Location = new System.Drawing.Point(17, 87);
      this.chk_remove_linebreak.Margin = new System.Windows.Forms.Padding(4);
      this.chk_remove_linebreak.Name = "chk_remove_linebreak";
      this.chk_remove_linebreak.Size = new System.Drawing.Size(172, 32);
      this.chk_remove_linebreak.TabIndex = 8;
      this.chk_remove_linebreak.Text = "Entferne Umbrüche";
      // 
      // chk_remove_xmlstuff
      // 
      this.chk_remove_xmlstuff.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chk_remove_xmlstuff.Location = new System.Drawing.Point(17, 167);
      this.chk_remove_xmlstuff.Margin = new System.Windows.Forms.Padding(4);
      this.chk_remove_xmlstuff.Name = "chk_remove_xmlstuff";
      this.chk_remove_xmlstuff.Size = new System.Drawing.Size(255, 32);
      this.chk_remove_xmlstuff.TabIndex = 8;
      this.chk_remove_xmlstuff.Text = "Entferne XML/HTML-Fragmente";
      // 
      // chk_remove_htmlecoding
      // 
      this.chk_remove_htmlecoding.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chk_remove_htmlecoding.Location = new System.Drawing.Point(17, 207);
      this.chk_remove_htmlecoding.Margin = new System.Windows.Forms.Padding(4);
      this.chk_remove_htmlecoding.Name = "chk_remove_htmlecoding";
      this.chk_remove_htmlecoding.Size = new System.Drawing.Size(287, 32);
      this.chk_remove_htmlecoding.TabIndex = 9;
      this.chk_remove_htmlecoding.Text = "Entferne HTML-Encoding-Fragmente";
      // 
      // chk_in_corpus
      // 
      this.chk_in_corpus.Location = new System.Drawing.Point(28, 322);
      this.chk_in_corpus.Name = "chk_in_corpus";
      this.chk_in_corpus.Size = new System.Drawing.Size(244, 32);
      this.chk_in_corpus.TabIndex = 16;
      this.chk_in_corpus.Text = "Für alle Dokumente im Korpus";
      // 
      // chk_in_meta
      // 
      this.chk_in_meta.Location = new System.Drawing.Point(133, 284);
      this.chk_in_meta.Name = "chk_in_meta";
      this.chk_in_meta.Size = new System.Drawing.Size(115, 32);
      this.chk_in_meta.TabIndex = 15;
      this.chk_in_meta.Text = "Metadaten";
      // 
      // chk_in_text
      // 
      this.chk_in_text.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chk_in_text.Location = new System.Drawing.Point(26, 284);
      this.chk_in_text.Name = "chk_in_text";
      this.chk_in_text.Size = new System.Drawing.Size(93, 32);
      this.chk_in_text.TabIndex = 14;
      this.chk_in_text.Text = "Volltext";
      // 
      // radLabel3
      // 
      this.radLabel3.Location = new System.Drawing.Point(26, 253);
      this.radLabel3.Margin = new System.Windows.Forms.Padding(4);
      this.radLabel3.Name = "radLabel3";
      this.radLabel3.Size = new System.Drawing.Size(148, 23);
      this.radLabel3.TabIndex = 13;
      this.radLabel3.Text = "Suche und Ersetze in:";
      // 
      // chk_remove_linebreakPdf
      // 
      this.chk_remove_linebreakPdf.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chk_remove_linebreakPdf.Location = new System.Drawing.Point(17, 127);
      this.chk_remove_linebreakPdf.Margin = new System.Windows.Forms.Padding(4);
      this.chk_remove_linebreakPdf.Name = "chk_remove_linebreakPdf";
      this.chk_remove_linebreakPdf.Size = new System.Drawing.Size(265, 32);
      this.chk_remove_linebreakPdf.TabIndex = 9;
      this.chk_remove_linebreakPdf.Text = "Entferne Umbrüche in PDF-Token";
      // 
      // TextAutoFixer
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(467, 443);
      this.Controls.Add(this.chk_remove_linebreakPdf);
      this.Controls.Add(this.chk_in_corpus);
      this.Controls.Add(this.chk_in_meta);
      this.Controls.Add(this.chk_in_text);
      this.Controls.Add(this.radLabel3);
      this.Controls.Add(this.chk_remove_htmlecoding);
      this.Controls.Add(this.chk_remove_xmlstuff);
      this.Controls.Add(this.chk_remove_linebreak);
      this.Controls.Add(this.chk_remove_space);
      this.Controls.Add(this.btn_abort);
      this.Controls.Add(this.btn_ok);
      this.Controls.Add(this.radLabel1);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "TextAutoFixer";
      this.Text = "DPXC-AutoFix";
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_remove_space)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_remove_linebreak)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_remove_xmlstuff)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_remove_htmlecoding)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_in_corpus)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_in_meta)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_in_text)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_remove_linebreakPdf)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.RadButton btn_abort;
    private Telerik.WinControls.UI.RadButton btn_ok;
    private Telerik.WinControls.UI.RadCheckBox chk_remove_space;
    private Telerik.WinControls.UI.RadCheckBox chk_remove_linebreak;
    private Telerik.WinControls.UI.RadCheckBox chk_remove_xmlstuff;
        private Telerik.WinControls.UI.RadCheckBox chk_remove_htmlecoding;
    private Telerik.WinControls.UI.RadCheckBox chk_in_corpus;
    private Telerik.WinControls.UI.RadCheckBox chk_in_meta;
    private Telerik.WinControls.UI.RadCheckBox chk_in_text;
    private Telerik.WinControls.UI.RadLabel radLabel3;
    private Telerik.WinControls.UI.RadCheckBox chk_remove_linebreakPdf;
  }
}