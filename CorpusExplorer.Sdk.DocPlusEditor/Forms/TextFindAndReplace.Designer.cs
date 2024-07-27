namespace CorpusExplorer.Tool4.DocPlusEditor.Forms
{
  partial class TextFindAndReplace
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
      this.btn_abort = new Telerik.WinControls.UI.RadButton();
      this.btn_ok = new Telerik.WinControls.UI.RadButton();
      this.txt_query = new Telerik.WinControls.UI.RadTextBox();
      this.txt_replace = new Telerik.WinControls.UI.RadTextBox();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
      this.chk_in_text = new Telerik.WinControls.UI.RadCheckBox();
      this.chk_in_meta = new Telerik.WinControls.UI.RadCheckBox();
      this.chk_regex = new Telerik.WinControls.UI.RadCheckBox();
      this.chk_in_corpus = new Telerik.WinControls.UI.RadCheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_query)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_replace)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_in_text)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_in_meta)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_regex)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_in_corpus)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // btn_abort
      // 
      this.btn_abort.DialogResult = System.Windows.Forms.DialogResult.No;
      this.btn_abort.Location = new System.Drawing.Point(496, 248);
      this.btn_abort.Margin = new System.Windows.Forms.Padding(4);
      this.btn_abort.Name = "btn_abort";
      this.btn_abort.Size = new System.Drawing.Size(147, 46);
      this.btn_abort.TabIndex = 4;
      this.btn_abort.Text = "Abbrechen";
      // 
      // btn_ok
      // 
      this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.Yes;
      this.btn_ok.Location = new System.Drawing.Point(16, 249);
      this.btn_ok.Margin = new System.Windows.Forms.Padding(4);
      this.btn_ok.Name = "btn_ok";
      this.btn_ok.Size = new System.Drawing.Size(147, 46);
      this.btn_ok.TabIndex = 3;
      this.btn_ok.Text = "Anwenden";
      this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
      // 
      // txt_query
      // 
      this.txt_query.Location = new System.Drawing.Point(16, 37);
      this.txt_query.Margin = new System.Windows.Forms.Padding(4);
      this.txt_query.Name = "txt_query";
      this.txt_query.Size = new System.Drawing.Size(627, 37);
      this.txt_query.TabIndex = 5;
      // 
      // txt_replace
      // 
      this.txt_replace.Location = new System.Drawing.Point(17, 119);
      this.txt_replace.Margin = new System.Windows.Forms.Padding(4);
      this.txt_replace.Name = "txt_replace";
      this.txt_replace.Size = new System.Drawing.Size(625, 37);
      this.txt_replace.TabIndex = 6;
      // 
      // radLabel1
      // 
      this.radLabel1.Location = new System.Drawing.Point(17, 7);
      this.radLabel1.Margin = new System.Windows.Forms.Padding(4);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(189, 23);
      this.radLabel1.TabIndex = 7;
      this.radLabel1.Text = "Suche folgenden Ausdruck:";
      // 
      // radLabel2
      // 
      this.radLabel2.Location = new System.Drawing.Point(17, 84);
      this.radLabel2.Margin = new System.Windows.Forms.Padding(4);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Size = new System.Drawing.Size(163, 23);
      this.radLabel2.TabIndex = 8;
      this.radLabel2.Text = "Und ersetze diesen mit:";
      // 
      // radLabel3
      // 
      this.radLabel3.Location = new System.Drawing.Point(17, 166);
      this.radLabel3.Margin = new System.Windows.Forms.Padding(4);
      this.radLabel3.Name = "radLabel3";
      this.radLabel3.Size = new System.Drawing.Size(148, 23);
      this.radLabel3.TabIndex = 9;
      this.radLabel3.Text = "Suche und Ersetze in:";
      // 
      // chk_in_text
      // 
      this.chk_in_text.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chk_in_text.Location = new System.Drawing.Point(17, 197);
      this.chk_in_text.Name = "chk_in_text";
      this.chk_in_text.Size = new System.Drawing.Size(93, 32);
      this.chk_in_text.TabIndex = 10;
      this.chk_in_text.Text = "Volltext";
      this.chk_in_text.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
      // 
      // chk_in_meta
      // 
      this.chk_in_meta.Location = new System.Drawing.Point(124, 197);
      this.chk_in_meta.Name = "chk_in_meta";
      this.chk_in_meta.Size = new System.Drawing.Size(115, 32);
      this.chk_in_meta.TabIndex = 11;
      this.chk_in_meta.Text = "Metadaten";
      // 
      // chk_regex
      // 
      this.chk_regex.Location = new System.Drawing.Point(324, 3);
      this.chk_regex.Name = "chk_regex";
      this.chk_regex.Size = new System.Drawing.Size(319, 32);
      this.chk_regex.TabIndex = 12;
      this.chk_regex.Text = "Suchausdruck ist ein \'Regulärer Ausdruck\'";
      // 
      // chk_in_corpus
      // 
      this.chk_in_corpus.Location = new System.Drawing.Point(399, 197);
      this.chk_in_corpus.Name = "chk_in_corpus";
      this.chk_in_corpus.Size = new System.Drawing.Size(244, 32);
      this.chk_in_corpus.TabIndex = 12;
      this.chk_in_corpus.Text = "Für alle Dokumente im Korpus";
      // 
      // TextFindAndReplace
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(665, 308);
      this.Controls.Add(this.chk_in_corpus);
      this.Controls.Add(this.chk_regex);
      this.Controls.Add(this.chk_in_meta);
      this.Controls.Add(this.chk_in_text);
      this.Controls.Add(this.radLabel3);
      this.Controls.Add(this.radLabel2);
      this.Controls.Add(this.radLabel1);
      this.Controls.Add(this.txt_replace);
      this.Controls.Add(this.txt_query);
      this.Controls.Add(this.btn_abort);
      this.Controls.Add(this.btn_ok);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "TextFindAndReplace";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "Suchen und Ersetzen";
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_query)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_replace)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_in_text)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_in_meta)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_regex)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_in_corpus)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadButton btn_abort;
    private Telerik.WinControls.UI.RadButton btn_ok;
    private Telerik.WinControls.UI.RadTextBox txt_query;
    private Telerik.WinControls.UI.RadTextBox txt_replace;
    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadCheckBox chk_in_text;
        private Telerik.WinControls.UI.RadCheckBox chk_in_meta;
        private Telerik.WinControls.UI.RadCheckBox chk_regex;
    private Telerik.WinControls.UI.RadCheckBox chk_in_corpus;
  }
}