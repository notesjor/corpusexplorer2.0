namespace CorpusExplorer.Terminal.WinForm.View.Special.Html5DevLabForms
{
  partial class Html5DevLabHelp
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Html5DevLabHelp));
      this.ihdPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
      this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
      this.page_FREQU = new Telerik.WinControls.UI.RadPageViewPage();
      this.ihdPanel2 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
      this.page_CFREQ = new Telerik.WinControls.UI.RadPageViewPage();
      this.page_COOCC = new Telerik.WinControls.UI.RadPageViewPage();
      this.page_METAD = new Telerik.WinControls.UI.RadPageViewPage();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.ihdPanel3 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
      this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
      this.ihdPanel4 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
      this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
      this.ihdPanel5 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
      this.radPageView1.SuspendLayout();
      this.page_FREQU.SuspendLayout();
      this.page_CFREQ.SuspendLayout();
      this.page_COOCC.SuspendLayout();
      this.page_METAD.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Location = new System.Drawing.Point(0, 392);
      this.radPanel1.Size = new System.Drawing.Size(480, 38);
      // 
      // ihdPanel1
      // 
      this.ihdPanel1.BackColor = System.Drawing.Color.White;
      this.ihdPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihdPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihdPanel1.IHDDeescribtion = "Das HTML5-Labor erlaubt es eigene Visualisierungen ganz schnell und einfach mit C" +
    "orpusExplorer-Daten zu füllen. Diese Hilfe zeigt, welche Datenquellen verfügbar " +
    "sind:";
      this.ihdPanel1.IHDHeader = "Experimentierfreudig?";
      this.ihdPanel1.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.html_page_gear1;
      this.ihdPanel1.Location = new System.Drawing.Point(0, 0);
      this.ihdPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.ihdPanel1.Name = "ihdPanel1";
      this.ihdPanel1.Size = new System.Drawing.Size(480, 87);
      this.ihdPanel1.TabIndex = 1;
      // 
      // radPageView1
      // 
      this.radPageView1.Controls.Add(this.page_FREQU);
      this.radPageView1.Controls.Add(this.page_CFREQ);
      this.radPageView1.Controls.Add(this.page_COOCC);
      this.radPageView1.Controls.Add(this.page_METAD);
      this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radPageView1.Location = new System.Drawing.Point(0, 87);
      this.radPageView1.Name = "radPageView1";
      this.radPageView1.SelectedPage = this.page_FREQU;
      this.radPageView1.Size = new System.Drawing.Size(480, 305);
      this.radPageView1.TabIndex = 2;
      this.radPageView1.Text = "radPageView1";
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
      // 
      // page_FREQU
      // 
      this.page_FREQU.Controls.Add(this.radLabel1);
      this.page_FREQU.Controls.Add(this.ihdPanel2);
      this.page_FREQU.ItemSize = new System.Drawing.SizeF(68F, 29F);
      this.page_FREQU.Location = new System.Drawing.Point(5, 35);
      this.page_FREQU.Name = "page_FREQU";
      this.page_FREQU.Size = new System.Drawing.Size(470, 265);
      this.page_FREQU.Text = "#FREQU";
      // 
      // ihdPanel2
      // 
      this.ihdPanel2.BackColor = System.Drawing.Color.White;
      this.ihdPanel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihdPanel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihdPanel2.IHDDeescribtion = "Bindet die Frequenz-Tabelle als JSON-Array ein. Die Tabelle hat folgende Spalten:" +
    " POS, Lemma, Wort und Frequenz";
      this.ihdPanel2.IHDHeader = "#FREQU";
      this.ihdPanel2.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.table_1;
      this.ihdPanel2.Location = new System.Drawing.Point(0, 0);
      this.ihdPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.ihdPanel2.Name = "ihdPanel2";
      this.ihdPanel2.Size = new System.Drawing.Size(470, 75);
      this.ihdPanel2.TabIndex = 0;
      // 
      // page_CFREQ
      // 
      this.page_CFREQ.Controls.Add(this.radLabel2);
      this.page_CFREQ.Controls.Add(this.ihdPanel3);
      this.page_CFREQ.ItemSize = new System.Drawing.SizeF(67F, 29F);
      this.page_CFREQ.Location = new System.Drawing.Point(5, 35);
      this.page_CFREQ.Name = "page_CFREQ";
      this.page_CFREQ.Size = new System.Drawing.Size(470, 242);
      this.page_CFREQ.Text = "#CFREQ";
      // 
      // page_COOCC
      // 
      this.page_COOCC.Controls.Add(this.radLabel3);
      this.page_COOCC.Controls.Add(this.ihdPanel4);
      this.page_COOCC.ItemSize = new System.Drawing.SizeF(73F, 29F);
      this.page_COOCC.Location = new System.Drawing.Point(5, 35);
      this.page_COOCC.Name = "page_COOCC";
      this.page_COOCC.Size = new System.Drawing.Size(470, 242);
      this.page_COOCC.Text = "#COOCC";
      // 
      // page_METAD
      // 
      this.page_METAD.Controls.Add(this.radLabel4);
      this.page_METAD.Controls.Add(this.ihdPanel5);
      this.page_METAD.ItemSize = new System.Drawing.SizeF(72F, 29F);
      this.page_METAD.Location = new System.Drawing.Point(5, 35);
      this.page_METAD.Name = "page_METAD";
      this.page_METAD.Size = new System.Drawing.Size(470, 265);
      this.page_METAD.Text = "#METAD";
      // 
      // radLabel1
      // 
      this.radLabel1.AutoSize = false;
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radLabel1.Location = new System.Drawing.Point(0, 75);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(470, 190);
      this.radLabel1.TabIndex = 1;
      this.radLabel1.Text = "<html><p><strong>Beispiel:</strong></p><p>[<br />  {<br />  \"POS\": \"NN\",<br />  \"" +
    "Lemma\": \"Berg\",<br />  \"Wort\": \"Berge\",<br />  \"Frequenz\": 20.0<br />  },</p></h" +
    "tml>";
      // 
      // radLabel2
      // 
      this.radLabel2.AutoSize = false;
      this.radLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radLabel2.Location = new System.Drawing.Point(0, 75);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Size = new System.Drawing.Size(470, 167);
      this.radLabel2.TabIndex = 3;
      this.radLabel2.Text = "<html><p><strong>Beispiel:</strong></p><p>[<br />  {<br />  \"Wort\": \"Frauenquote\"" +
    ",<br />  \"Partner\": \"Prozent\",<br />  \"Frequenz\": 40.0<br />  },</p></html>";
      // 
      // ihdPanel3
      // 
      this.ihdPanel3.BackColor = System.Drawing.Color.White;
      this.ihdPanel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihdPanel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihdPanel3.IHDDeescribtion = "Bindet die Kreuz-Frequenz-Tabelle als JSON-Array ein. Die Tabelle hat folgende Sp" +
    "alten: Wort, Partner und Frequenz";
      this.ihdPanel3.IHDHeader = "#CFREQ";
      this.ihdPanel3.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.table_1;
      this.ihdPanel3.Location = new System.Drawing.Point(0, 0);
      this.ihdPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.ihdPanel3.Name = "ihdPanel3";
      this.ihdPanel3.Size = new System.Drawing.Size(470, 75);
      this.ihdPanel3.TabIndex = 2;
      // 
      // radLabel3
      // 
      this.radLabel3.AutoSize = false;
      this.radLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radLabel3.Location = new System.Drawing.Point(0, 75);
      this.radLabel3.Name = "radLabel3";
      this.radLabel3.Size = new System.Drawing.Size(470, 167);
      this.radLabel3.TabIndex = 5;
      this.radLabel3.Text = resources.GetString("radLabel3.Text");
      // 
      // ihdPanel4
      // 
      this.ihdPanel4.BackColor = System.Drawing.Color.White;
      this.ihdPanel4.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihdPanel4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihdPanel4.IHDDeescribtion = "Bindet die Kookkurrenz-Analyse als JSON-Array ein. Die Tabelle hat folgende Spalt" +
    "en: Zeichenkette, Kookkurrenz, Frequenz und Signifikanz";
      this.ihdPanel4.IHDHeader = "#COOCC";
      this.ihdPanel4.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.table_1;
      this.ihdPanel4.Location = new System.Drawing.Point(0, 0);
      this.ihdPanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.ihdPanel4.Name = "ihdPanel4";
      this.ihdPanel4.Size = new System.Drawing.Size(470, 75);
      this.ihdPanel4.TabIndex = 4;
      // 
      // radLabel4
      // 
      this.radLabel4.AutoSize = false;
      this.radLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radLabel4.Location = new System.Drawing.Point(0, 82);
      this.radLabel4.Name = "radLabel4";
      this.radLabel4.Size = new System.Drawing.Size(470, 183);
      this.radLabel4.TabIndex = 5;
      this.radLabel4.Text = resources.GetString("radLabel4.Text");
      // 
      // ihdPanel5
      // 
      this.ihdPanel5.BackColor = System.Drawing.Color.White;
      this.ihdPanel5.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihdPanel5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihdPanel5.IHDDeescribtion = "Bindet einen Vergleich auf der Dokumentmetadaten-Ebene als JSON-Array ein. Verfüg" +
    "bare Daten: Kategorie, Metadaten, Token, Types und Dokumente.";
      this.ihdPanel5.IHDHeader = "#METAD";
      this.ihdPanel5.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.table_1;
      this.ihdPanel5.Location = new System.Drawing.Point(0, 0);
      this.ihdPanel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.ihdPanel5.Name = "ihdPanel5";
      this.ihdPanel5.Size = new System.Drawing.Size(470, 82);
      this.ihdPanel5.TabIndex = 4;
      // 
      // Html5DevLabHelp
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(480, 430);
      this.Controls.Add(this.radPageView1);
      this.Controls.Add(this.ihdPanel1);
      this.DisplayAbort = true;
      this.Name = "Html5DevLabHelp";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "Entwicklerhilfe - HTML5-Labor";
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.ihdPanel1, 0);
      this.Controls.SetChildIndex(this.radPageView1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
      this.radPageView1.ResumeLayout(false);
      this.page_FREQU.ResumeLayout(false);
      this.page_CFREQ.ResumeLayout(false);
      this.page_COOCC.ResumeLayout(false);
      this.page_METAD.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.WinForm.IHDPanel ihdPanel1;
    private Telerik.WinControls.UI.RadPageView radPageView1;
    private Telerik.WinControls.UI.RadPageViewPage page_FREQU;
    private Telerik.WinControls.UI.RadPageViewPage page_CFREQ;
    private Telerik.WinControls.UI.RadPageViewPage page_COOCC;
    private Telerik.WinControls.UI.RadPageViewPage page_METAD;
    private Controls.WinForm.IHDPanel ihdPanel2;
    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private Controls.WinForm.IHDPanel ihdPanel3;
    private Telerik.WinControls.UI.RadLabel radLabel3;
    private Controls.WinForm.IHDPanel ihdPanel4;
    private Telerik.WinControls.UI.RadLabel radLabel4;
    private Controls.WinForm.IHDPanel ihdPanel5;
  }
}