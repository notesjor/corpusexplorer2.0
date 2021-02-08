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
      this._headPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HeadPanel();
      this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
      this.page_FREQU = new Telerik.WinControls.UI.RadPageViewPage();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this._headPanel2 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HeadPanel();
      this.page_CFREQ = new Telerik.WinControls.UI.RadPageViewPage();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this._headPanel3 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HeadPanel();
      this.page_COOCC = new Telerik.WinControls.UI.RadPageViewPage();
      this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
      this._headPanel4 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HeadPanel();
      this.page_METAD = new Telerik.WinControls.UI.RadPageViewPage();
      this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
      this._headPanel5 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HeadPanel();
      this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
      this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
      this._headPanel6 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.HeadPanel();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
      this.radPageView1.SuspendLayout();
      this.page_FREQU.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      this.page_CFREQ.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      this.page_COOCC.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
      this.page_METAD.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
      this.radPageViewPage1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      resources.ApplyResources(this.radPanel1, "radPanel1");
      // 
      // _headPanel1
      // 
      this._headPanel1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this._headPanel1, "_headPanel1");
      this._headPanel1.HeadPanelDescription = "Das HTML5-Labor erlaubt es eigene Visualisierungen ganz schnell und einfach mit C" +
    "orpusExplorer-Daten zu füllen. Diese Hilfe zeigt, welche Datenquellen verfügbar " +
    "sind:";
      this._headPanel1.HeadPanelTitle = "Experimentierfreudig?";
      this._headPanel1.HeadPanelImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.html_page_gear1;
      this._headPanel1.Name = "_headPanel1";
      // 
      // radPageView1
      // 
      this.radPageView1.Controls.Add(this.page_FREQU);
      this.radPageView1.Controls.Add(this.page_CFREQ);
      this.radPageView1.Controls.Add(this.page_COOCC);
      this.radPageView1.Controls.Add(this.page_METAD);
      this.radPageView1.Controls.Add(this.radPageViewPage1);
      resources.ApplyResources(this.radPageView1, "radPageView1");
      this.radPageView1.Name = "radPageView1";
      this.radPageView1.SelectedPage = this.page_FREQU;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
      // 
      // page_FREQU
      // 
      this.page_FREQU.Controls.Add(this.radLabel1);
      this.page_FREQU.Controls.Add(this._headPanel2);
      this.page_FREQU.ItemSize = new System.Drawing.SizeF(68F, 29F);
      resources.ApplyResources(this.page_FREQU, "page_FREQU");
      this.page_FREQU.Name = "page_FREQU";
      // 
      // radLabel1
      // 
      resources.ApplyResources(this.radLabel1, "radLabel1");
      this.radLabel1.Name = "radLabel1";
      // 
      // _headPanel2
      // 
      this._headPanel2.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this._headPanel2, "_headPanel2");
      this._headPanel2.HeadPanelDescription = "Bindet die Frequenz-Tabelle als JSON-Array ein. Die Tabelle hat folgende Spalten:" +
    " POS, Lemma, Wort und Frequenz";
      this._headPanel2.HeadPanelTitle = "#FREQU";
      this._headPanel2.HeadPanelImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.table_1;
      this._headPanel2.Name = "_headPanel2";
      // 
      // page_CFREQ
      // 
      this.page_CFREQ.Controls.Add(this.radLabel2);
      this.page_CFREQ.Controls.Add(this._headPanel3);
      this.page_CFREQ.ItemSize = new System.Drawing.SizeF(67F, 29F);
      resources.ApplyResources(this.page_CFREQ, "page_CFREQ");
      this.page_CFREQ.Name = "page_CFREQ";
      // 
      // radLabel2
      // 
      resources.ApplyResources(this.radLabel2, "radLabel2");
      this.radLabel2.Name = "radLabel2";
      // 
      // _headPanel3
      // 
      this._headPanel3.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this._headPanel3, "_headPanel3");
      this._headPanel3.HeadPanelDescription = "Bindet die Kreuz-Frequenz-Tabelle als JSON-Array ein. Die Tabelle hat folgende Sp" +
    "alten: Wort, Partner und Frequenz";
      this._headPanel3.HeadPanelTitle = "#CFREQ";
      this._headPanel3.HeadPanelImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.table_1;
      this._headPanel3.Name = "_headPanel3";
      // 
      // page_COOCC
      // 
      this.page_COOCC.Controls.Add(this.radLabel3);
      this.page_COOCC.Controls.Add(this._headPanel4);
      this.page_COOCC.ItemSize = new System.Drawing.SizeF(73F, 29F);
      resources.ApplyResources(this.page_COOCC, "page_COOCC");
      this.page_COOCC.Name = "page_COOCC";
      // 
      // radLabel3
      // 
      resources.ApplyResources(this.radLabel3, "radLabel3");
      this.radLabel3.Name = "radLabel3";
      // 
      // _headPanel4
      // 
      this._headPanel4.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this._headPanel4, "_headPanel4");
      this._headPanel4.HeadPanelDescription = "Bindet die Kookkurrenz-Analyse als JSON-Array ein. Die Tabelle hat folgende Spalt" +
    "en: Zeichenkette, Kookkurrenz, Frequenz und Signifikanz";
      this._headPanel4.HeadPanelTitle = "#COOCC";
      this._headPanel4.HeadPanelImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.table_1;
      this._headPanel4.Name = "_headPanel4";
      // 
      // page_METAD
      // 
      this.page_METAD.Controls.Add(this.radLabel4);
      this.page_METAD.Controls.Add(this._headPanel5);
      this.page_METAD.ItemSize = new System.Drawing.SizeF(72F, 29F);
      resources.ApplyResources(this.page_METAD, "page_METAD");
      this.page_METAD.Name = "page_METAD";
      // 
      // radLabel4
      // 
      resources.ApplyResources(this.radLabel4, "radLabel4");
      this.radLabel4.Name = "radLabel4";
      // 
      // _headPanel5
      // 
      this._headPanel5.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this._headPanel5, "_headPanel5");
      this._headPanel5.HeadPanelDescription = "Bindet einen Vergleich auf der Dokumentmetadaten-Ebene als JSON-Array ein. Verfüg" +
    "bare Daten: Kategorie, Metadaten, Token, Types und Dokumente.";
      this._headPanel5.HeadPanelTitle = "#METAD";
      this._headPanel5.HeadPanelImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.table_1;
      this._headPanel5.Name = "_headPanel5";
      // 
      // radPageViewPage1
      // 
      this.radPageViewPage1.Controls.Add(this.radLabel5);
      this.radPageViewPage1.Controls.Add(this._headPanel6);
      this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(88F, 29F);
      resources.ApplyResources(this.radPageViewPage1, "radPageViewPage1");
      this.radPageViewPage1.Name = "radPageViewPage1";
      // 
      // radLabel5
      // 
      resources.ApplyResources(this.radLabel5, "radLabel5");
      this.radLabel5.Name = "radLabel5";
      // 
      // _headPanel6
      // 
      this._headPanel6.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this._headPanel6, "_headPanel6");
      this._headPanel6.HeadPanelDescription = "Wenn Sie Analysen realisieren möchten, die über die vier Grundfunktionalitäten hi" +
    "nausgehen, dann nutzen Sie die erweiterte Skriptfunktionalität.";
      this._headPanel6.HeadPanelTitle = "Erweiterte Skriptfunktionalität";
      this._headPanel6.HeadPanelImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.script;
      this._headPanel6.Name = "_headPanel6";
      // 
      // Html5DevLabHelp
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.radPageView1);
      this.Controls.Add(this._headPanel1);
      this.DisplayAbort = true;
      this.Name = "Html5DevLabHelp";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this._headPanel1, 0);
      this.Controls.SetChildIndex(this.radPageView1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
      this.radPageView1.ResumeLayout(false);
      this.page_FREQU.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      this.page_CFREQ.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      this.page_COOCC.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
      this.page_METAD.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
      this.radPageViewPage1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.WinForm.HeadPanel _headPanel1;
    private Telerik.WinControls.UI.RadPageView radPageView1;
    private Telerik.WinControls.UI.RadPageViewPage page_FREQU;
    private Telerik.WinControls.UI.RadPageViewPage page_CFREQ;
    private Telerik.WinControls.UI.RadPageViewPage page_COOCC;
    private Telerik.WinControls.UI.RadPageViewPage page_METAD;
    private Controls.WinForm.HeadPanel _headPanel2;
    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private Controls.WinForm.HeadPanel _headPanel3;
    private Telerik.WinControls.UI.RadLabel radLabel3;
    private Controls.WinForm.HeadPanel _headPanel4;
    private Telerik.WinControls.UI.RadLabel radLabel4;
    private Controls.WinForm.HeadPanel _headPanel5;
    private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
    private Controls.WinForm.HeadPanel _headPanel6;
    private Telerik.WinControls.UI.RadLabel radLabel5;
  }
}