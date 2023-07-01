namespace CorpusExplorer.Terminal.WinForm.Forms.KorAP
{
  partial class KorAPClient
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KorAPClient));
      this.headPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HeadPanel();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.btn_ok = new Telerik.WinControls.UI.RadButton();
      this.btn_abort = new Telerik.WinControls.UI.RadButton();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.btn_signin = new Telerik.WinControls.UI.RadButton();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.panel_2 = new Telerik.WinControls.UI.RadGroupBox();
      this.clearPanel2 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
      this.txt_sample = new Telerik.WinControls.UI.RadTextBox();
      this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
      this.radio_sample_fisheryates = new Telerik.WinControls.UI.RadRadioButton();
      this.radio_sample_normal = new Telerik.WinControls.UI.RadRadioButton();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.panel_4 = new Telerik.WinControls.UI.RadGroupBox();
      this.txt_queries = new Telerik.WinControls.UI.RadTextBox();
      this.clearPanel3 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.combo_query_language = new Telerik.WinControls.UI.RadDropDownList();
      this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
      this.panel_3 = new Telerik.WinControls.UI.RadGroupBox();
      this.txt_query_corpus = new Telerik.WinControls.UI.RadTextBox();
      this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_signin)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panel_2)).BeginInit();
      this.panel_2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel2)).BeginInit();
      this.clearPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_sample)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_sample_fisheryates)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_sample_normal)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panel_4)).BeginInit();
      this.panel_4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_queries)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel3)).BeginInit();
      this.clearPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.combo_query_language)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panel_3)).BeginInit();
      this.panel_3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_query_corpus)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // headPanel1
      // 
      this.headPanel1.BackColor = System.Drawing.Color.White;
      this.headPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.headPanel1.Font = new System.Drawing.Font("Segoe UI", 12F);
      this.headPanel1.HeadPanelDescription = resources.GetString("headPanel1.HeadPanelDescription");
      this.headPanel1.HeadPanelImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.korap_48;
      this.headPanel1.HeadPanelTitle = "KorAP-API als Belegquelle nutzen";
      this.headPanel1.Location = new System.Drawing.Point(0, 0);
      this.headPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.headPanel1.Name = "headPanel1";
      this.headPanel1.Size = new System.Drawing.Size(604, 86);
      this.headPanel1.TabIndex = 0;
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.btn_ok);
      this.clearPanel1.Controls.Add(this.btn_abort);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.clearPanel1.Location = new System.Drawing.Point(0, 561);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Padding = new System.Windows.Forms.Padding(10);
      this.clearPanel1.Size = new System.Drawing.Size(604, 53);
      this.clearPanel1.TabIndex = 14;
      // 
      // btn_ok
      // 
      this.btn_ok.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_ok.Enabled = false;
      this.btn_ok.Location = new System.Drawing.Point(384, 10);
      this.btn_ok.Name = "btn_ok";
      this.btn_ok.Size = new System.Drawing.Size(210, 33);
      this.btn_ok.TabIndex = 1;
      this.btn_ok.Text = "Daten analysieren";
      this.btn_ok.Visible = false;
      this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
      // 
      // btn_abort
      // 
      this.btn_abort.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_abort.Location = new System.Drawing.Point(10, 10);
      this.btn_abort.Name = "btn_abort";
      this.btn_abort.Size = new System.Drawing.Size(210, 33);
      this.btn_abort.TabIndex = 0;
      this.btn_abort.Text = "Abbrechen";
      this.btn_abort.Click += new System.EventHandler(this.btn_abort_Click);
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.btn_signin);
      this.radGroupBox1.Controls.Add(this.radLabel1);
      this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox1.HeaderText = "1. Authorisieren";
      this.radGroupBox1.Location = new System.Drawing.Point(0, 86);
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox1.Size = new System.Drawing.Size(604, 83);
      this.radGroupBox1.TabIndex = 15;
      this.radGroupBox1.Text = "1. Authorisieren";
      // 
      // btn_signin
      // 
      this.btn_signin.Dock = System.Windows.Forms.DockStyle.Top;
      this.btn_signin.Location = new System.Drawing.Point(5, 47);
      this.btn_signin.Name = "btn_signin";
      this.btn_signin.Size = new System.Drawing.Size(594, 32);
      this.btn_signin.TabIndex = 0;
      this.btn_signin.Text = "Zugang aktivieren (OAuth2)";
      this.btn_signin.Click += new System.EventHandler(this.btn_signin_Click);
      // 
      // radLabel1
      // 
      this.radLabel1.AutoSize = false;
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel1.Location = new System.Drawing.Point(5, 25);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(594, 22);
      this.radLabel1.TabIndex = 0;
      this.radLabel1.Text = "<html>Sie benötigen einen gültigen KorAP-Zugang. <a href=\"https://perso.ids-mannh" +
    "eim.de/registration/\">Diesen Zugang können Sie hier kostenfrei beantragen</a>.</" +
    "html>";
      this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
      // 
      // panel_2
      // 
      this.panel_2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.panel_2.Controls.Add(this.clearPanel2);
      this.panel_2.Controls.Add(this.radio_sample_fisheryates);
      this.panel_2.Controls.Add(this.radio_sample_normal);
      this.panel_2.Controls.Add(this.radLabel2);
      this.panel_2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel_2.HeaderText = "2. Sampling auswählen";
      this.panel_2.Location = new System.Drawing.Point(0, 169);
      this.panel_2.Name = "panel_2";
      this.panel_2.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.panel_2.Size = new System.Drawing.Size(604, 145);
      this.panel_2.TabIndex = 16;
      this.panel_2.Text = "2. Sampling auswählen";
      this.panel_2.Visible = false;
      // 
      // clearPanel2
      // 
      this.clearPanel2.Controls.Add(this.radLabel4);
      this.clearPanel2.Controls.Add(this.txt_sample);
      this.clearPanel2.Controls.Add(this.radLabel3);
      this.clearPanel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.clearPanel2.Location = new System.Drawing.Point(5, 107);
      this.clearPanel2.Name = "clearPanel2";
      this.clearPanel2.Size = new System.Drawing.Size(594, 35);
      this.clearPanel2.TabIndex = 4;
      // 
      // radLabel4
      // 
      this.radLabel4.AutoSize = false;
      this.radLabel4.Dock = System.Windows.Forms.DockStyle.Left;
      this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel4.Location = new System.Drawing.Point(169, 0);
      this.radLabel4.Name = "radLabel4";
      this.radLabel4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
      this.radLabel4.Size = new System.Drawing.Size(183, 35);
      this.radLabel4.TabIndex = 3;
      this.radLabel4.Text = "(Max. 10\'000 - Pro Abfrage)";
      this.radLabel4.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
      // 
      // txt_sample
      // 
      this.txt_sample.Dock = System.Windows.Forms.DockStyle.Left;
      this.txt_sample.Location = new System.Drawing.Point(107, 0);
      this.txt_sample.Name = "txt_sample";
      this.txt_sample.Size = new System.Drawing.Size(62, 35);
      this.txt_sample.TabIndex = 2;
      this.txt_sample.Text = "250";
      // 
      // radLabel3
      // 
      this.radLabel3.AutoSize = false;
      this.radLabel3.Dock = System.Windows.Forms.DockStyle.Left;
      this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel3.Location = new System.Drawing.Point(0, 0);
      this.radLabel3.Name = "radLabel3";
      this.radLabel3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
      this.radLabel3.Size = new System.Drawing.Size(107, 35);
      this.radLabel3.TabIndex = 1;
      this.radLabel3.Text = "Beleg-Maximum:";
      this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopRight;
      // 
      // radio_sample_fisheryates
      // 
      this.radio_sample_fisheryates.Dock = System.Windows.Forms.DockStyle.Top;
      this.radio_sample_fisheryates.Location = new System.Drawing.Point(5, 77);
      this.radio_sample_fisheryates.Name = "radio_sample_fisheryates";
      this.radio_sample_fisheryates.Size = new System.Drawing.Size(594, 30);
      this.radio_sample_fisheryates.TabIndex = 1;
      this.radio_sample_fisheryates.TabStop = false;
      this.radio_sample_fisheryates.Text = "Zufällige Auswahl (mittels Fisher–Yates shuffle) [längere Laufzeit]";
      // 
      // radio_sample_normal
      // 
      this.radio_sample_normal.CheckState = System.Windows.Forms.CheckState.Checked;
      this.radio_sample_normal.Dock = System.Windows.Forms.DockStyle.Top;
      this.radio_sample_normal.Location = new System.Drawing.Point(5, 47);
      this.radio_sample_normal.Name = "radio_sample_normal";
      this.radio_sample_normal.Size = new System.Drawing.Size(594, 30);
      this.radio_sample_normal.TabIndex = 2;
      this.radio_sample_normal.Text = "Die erstbesten Belege";
      this.radio_sample_normal.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
      // 
      // radLabel2
      // 
      this.radLabel2.AutoSize = false;
      this.radLabel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel2.Location = new System.Drawing.Point(5, 25);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Size = new System.Drawing.Size(594, 22);
      this.radLabel2.TabIndex = 0;
      this.radLabel2.Text = "Diese Auswahl entscheidet darüber, wie die Belege zusammengestellt werden:";
      this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
      // 
      // panel_4
      // 
      this.panel_4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.panel_4.Controls.Add(this.txt_queries);
      this.panel_4.Controls.Add(this.clearPanel3);
      this.panel_4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel_4.HeaderText = "4. Abfragen ";
      this.panel_4.Location = new System.Drawing.Point(0, 397);
      this.panel_4.Name = "panel_4";
      this.panel_4.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.panel_4.Size = new System.Drawing.Size(604, 164);
      this.panel_4.TabIndex = 17;
      this.panel_4.Text = "4. Abfragen ";
      this.panel_4.Visible = false;
      // 
      // txt_queries
      // 
      this.txt_queries.AutoSize = false;
      this.txt_queries.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_queries.Location = new System.Drawing.Point(5, 60);
      this.txt_queries.Multiline = true;
      this.txt_queries.Name = "txt_queries";
      this.txt_queries.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txt_queries.Size = new System.Drawing.Size(594, 99);
      this.txt_queries.TabIndex = 1;
      this.txt_queries.TextChanged += new System.EventHandler(this.txt_queries_TextChanged);
      // 
      // clearPanel3
      // 
      this.clearPanel3.Controls.Add(this.combo_query_language);
      this.clearPanel3.Controls.Add(this.radLabel6);
      this.clearPanel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.clearPanel3.Location = new System.Drawing.Point(5, 25);
      this.clearPanel3.Name = "clearPanel3";
      this.clearPanel3.Size = new System.Drawing.Size(594, 35);
      this.clearPanel3.TabIndex = 5;
      // 
      // combo_query_language
      // 
      this.combo_query_language.Dock = System.Windows.Forms.DockStyle.Fill;
      this.combo_query_language.DropDownAnimationEnabled = true;
      this.combo_query_language.Location = new System.Drawing.Point(352, 0);
      this.combo_query_language.Name = "combo_query_language";
      this.combo_query_language.NullText = "Abfragesprach auswählen...";
      this.combo_query_language.Size = new System.Drawing.Size(242, 35);
      this.combo_query_language.TabIndex = 2;
      // 
      // radLabel6
      // 
      this.radLabel6.AutoSize = false;
      this.radLabel6.Dock = System.Windows.Forms.DockStyle.Left;
      this.radLabel6.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel6.Location = new System.Drawing.Point(0, 0);
      this.radLabel6.Name = "radLabel6";
      this.radLabel6.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
      this.radLabel6.Size = new System.Drawing.Size(352, 35);
      this.radLabel6.TabIndex = 1;
      this.radLabel6.Text = "Pro Zeile eine Abfrage. Alle Abfragen sind in der Sprache:";
      this.radLabel6.TextAlignment = System.Drawing.ContentAlignment.TopRight;
      // 
      // panel_3
      // 
      this.panel_3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.panel_3.Controls.Add(this.txt_query_corpus);
      this.panel_3.Controls.Add(this.radLabel8);
      this.panel_3.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel_3.HeaderText = "3. Korpus-Query (optional)";
      this.panel_3.Location = new System.Drawing.Point(0, 314);
      this.panel_3.Name = "panel_3";
      this.panel_3.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.panel_3.Size = new System.Drawing.Size(604, 83);
      this.panel_3.TabIndex = 18;
      this.panel_3.Text = "3. Korpus-Query (optional)";
      this.panel_3.Visible = false;
      // 
      // txt_query_corpus
      // 
      this.txt_query_corpus.Dock = System.Windows.Forms.DockStyle.Top;
      this.txt_query_corpus.Location = new System.Drawing.Point(5, 47);
      this.txt_query_corpus.Name = "txt_query_corpus";
      this.txt_query_corpus.NullText = "Hier ggf. Korpus-Query eingeben (optional)...";
      this.txt_query_corpus.Size = new System.Drawing.Size(594, 32);
      this.txt_query_corpus.TabIndex = 1;
      // 
      // radLabel8
      // 
      this.radLabel8.AutoSize = false;
      this.radLabel8.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel8.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel8.Location = new System.Drawing.Point(5, 25);
      this.radLabel8.Name = "radLabel8";
      this.radLabel8.Size = new System.Drawing.Size(594, 22);
      this.radLabel8.TabIndex = 0;
      this.radLabel8.Text = "Grenzen Sie die Korpussuche ein (z. B.: corpusSigle=GOE oder createionDate since " +
    "1945):";
      this.radLabel8.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
      // 
      // KorAPClient
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(604, 614);
      this.Controls.Add(this.panel_4);
      this.Controls.Add(this.panel_3);
      this.Controls.Add(this.panel_2);
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this.clearPanel1);
      this.Controls.Add(this.headPanel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "KorAPClient";
      this.Text = "KorAP-API";
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_signin)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panel_2)).EndInit();
      this.panel_2.ResumeLayout(false);
      this.panel_2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel2)).EndInit();
      this.clearPanel2.ResumeLayout(false);
      this.clearPanel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_sample)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_sample_fisheryates)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radio_sample_normal)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panel_4)).EndInit();
      this.panel_4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.txt_queries)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel3)).EndInit();
      this.clearPanel3.ResumeLayout(false);
      this.clearPanel3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.combo_query_language)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panel_3)).EndInit();
      this.panel_3.ResumeLayout(false);
      this.panel_3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_query_corpus)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.WinForm.HeadPanel headPanel1;
    private Controls.WinForm.ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadButton btn_ok;
    private Telerik.WinControls.UI.RadButton btn_abort;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.RadButton btn_signin;
    private Telerik.WinControls.UI.RadGroupBox panel_2;
    private Controls.WinForm.ClearPanel clearPanel2;
    private Telerik.WinControls.UI.RadRadioButton radio_sample_normal;
    private Telerik.WinControls.UI.RadRadioButton radio_sample_fisheryates;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private Telerik.WinControls.UI.RadLabel radLabel4;
    private Telerik.WinControls.UI.RadTextBox txt_sample;
    private Telerik.WinControls.UI.RadLabel radLabel3;
    private Telerik.WinControls.UI.RadGroupBox panel_4;
    private Telerik.WinControls.UI.RadTextBox txt_queries;
    private Controls.WinForm.ClearPanel clearPanel3;
    private Telerik.WinControls.UI.RadDropDownList combo_query_language;
    private Telerik.WinControls.UI.RadLabel radLabel6;
    private Telerik.WinControls.UI.RadGroupBox panel_3;
    private Telerik.WinControls.UI.RadLabel radLabel8;
    private Telerik.WinControls.UI.RadTextBox txt_query_corpus;
  }
}