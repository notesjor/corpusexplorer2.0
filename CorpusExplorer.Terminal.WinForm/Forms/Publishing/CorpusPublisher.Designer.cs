namespace CorpusExplorer.Terminal.WinForm.Forms.Publishing
{
  partial class CorpusPublisher
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorpusPublisher));
      this.headPanel1 = new CorpusExplorer.Tool4.DocPlusEditor.Controls.HeadPanel();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.btn_publish = new Telerik.WinControls.UI.RadButton();
      this.btn_abort = new Telerik.WinControls.UI.RadButton();
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.pages_protectionMode = new Telerik.WinControls.UI.RadPageView();
      this.page_green = new Telerik.WinControls.UI.RadPageViewPage();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.page_yellow = new Telerik.WinControls.UI.RadPageViewPage();
      this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
      this.page_read = new Telerik.WinControls.UI.RadPageViewPage();
      this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
      this.chk_accecptLicenceText = new Telerik.WinControls.UI.RadCheckBox();
      this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
      this.txt_licenceInfo = new Telerik.WinControls.UI.RadTextBox();
      this.txt_licenceName = new Telerik.WinControls.UI.RadTextBox();
      this.txt_licenceHolder = new Telerik.WinControls.UI.RadTextBox();
      this.txt_additionalInfo = new Telerik.WinControls.UI.RadTextBox();
      this.txt_corpusInfo = new Telerik.WinControls.UI.RadTextBox();
      this.txt_publishingVersion = new Telerik.WinControls.UI.RadTextBox();
      this.txt_corpusName = new Telerik.WinControls.UI.RadTextBox();
      this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_publish)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
      this.radSplitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
      this.splitPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pages_protectionMode)).BeginInit();
      this.pages_protectionMode.SuspendLayout();
      this.page_green.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      this.page_yellow.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
      this.page_read.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
      this.splitPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chk_accecptLicenceText)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_licenceInfo)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_licenceName)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_licenceHolder)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_additionalInfo)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_corpusInfo)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_publishingVersion)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_corpusName)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // headPanel1
      // 
      this.headPanel1.BackColor = System.Drawing.Color.White;
      this.headPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.headPanel1.Font = new System.Drawing.Font("Segoe UI", 12F);
      this.headPanel1.HeadPanelDescription = "1...2...3... Publizieren Sie ein Korpus sicher, transparent und einfach.";
      this.headPanel1.HeadPanelImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.archive_download_48px;
      this.headPanel1.HeadPanelTitle = "Korpus für die Veröffentlichung erstellen";
      this.headPanel1.Location = new System.Drawing.Point(0, 0);
      this.headPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.headPanel1.Name = "headPanel1";
      this.headPanel1.Size = new System.Drawing.Size(800, 55);
      this.headPanel1.TabIndex = 0;
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.btn_publish);
      this.clearPanel1.Controls.Add(this.btn_abort);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.clearPanel1.Location = new System.Drawing.Point(0, 537);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Padding = new System.Windows.Forms.Padding(10);
      this.clearPanel1.Size = new System.Drawing.Size(800, 48);
      this.clearPanel1.TabIndex = 1;
      // 
      // btn_publish
      // 
      this.btn_publish.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_publish.Location = new System.Drawing.Point(655, 10);
      this.btn_publish.Name = "btn_publish";
      this.btn_publish.Size = new System.Drawing.Size(135, 28);
      this.btn_publish.TabIndex = 1;
      this.btn_publish.Text = "3. Publizieren";
      this.btn_publish.Click += new System.EventHandler(this.btn_publish_Click);
      // 
      // btn_abort
      // 
      this.btn_abort.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_abort.Location = new System.Drawing.Point(10, 10);
      this.btn_abort.Name = "btn_abort";
      this.btn_abort.Size = new System.Drawing.Size(110, 28);
      this.btn_abort.TabIndex = 0;
      this.btn_abort.Text = "Abbrechen";
      this.btn_abort.Click += new System.EventHandler(this.btn_abort_Click);
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      this.radSplitContainer1.Controls.Add(this.splitPanel2);
      this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radSplitContainer1.Location = new System.Drawing.Point(0, 55);
      this.radSplitContainer1.Name = "radSplitContainer1";
      // 
      // 
      // 
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
      this.radSplitContainer1.Size = new System.Drawing.Size(800, 482);
      this.radSplitContainer1.TabIndex = 2;
      this.radSplitContainer1.TabStop = false;
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.pages_protectionMode);
      this.splitPanel1.Controls.Add(this.radLabel1);
      this.splitPanel1.Location = new System.Drawing.Point(0, 0);
      this.splitPanel1.Name = "splitPanel1";
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(25, 25);
      this.splitPanel1.Size = new System.Drawing.Size(405, 482);
      this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.00879395F, 0F);
      this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(7, 0);
      this.splitPanel1.TabIndex = 0;
      this.splitPanel1.TabStop = false;
      this.splitPanel1.Text = "splitPanel1";
      // 
      // pages_protectionMode
      // 
      this.pages_protectionMode.Controls.Add(this.page_green);
      this.pages_protectionMode.Controls.Add(this.page_yellow);
      this.pages_protectionMode.Controls.Add(this.page_read);
      this.pages_protectionMode.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pages_protectionMode.ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth;
      this.pages_protectionMode.Location = new System.Drawing.Point(0, 29);
      this.pages_protectionMode.Name = "pages_protectionMode";
      this.pages_protectionMode.SelectedPage = this.page_green;
      this.pages_protectionMode.Size = new System.Drawing.Size(405, 453);
      this.pages_protectionMode.TabIndex = 1;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_protectionMode.GetChildAt(0))).ShowItemPinButton = false;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_protectionMode.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_protectionMode.GetChildAt(0))).ItemAlignment = Telerik.WinControls.UI.StripViewItemAlignment.Near;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_protectionMode.GetChildAt(0))).ItemFitMode = Telerik.WinControls.UI.StripViewItemFitMode.Fill;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_protectionMode.GetChildAt(0))).ShowItemCloseButton = false;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_protectionMode.GetChildAt(0))).ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pages_protectionMode.GetChildAt(0))).ItemContentOrientation = Telerik.WinControls.UI.PageViewContentOrientation.Auto;
      // 
      // page_green
      // 
      this.page_green.Controls.Add(this.radLabel2);
      this.page_green.ItemSize = new System.Drawing.SizeF(135F, 29F);
      this.page_green.Location = new System.Drawing.Point(5, 35);
      this.page_green.Name = "page_green";
      this.page_green.Size = new System.Drawing.Size(395, 413);
      this.page_green.Tag = "0";
      this.page_green.Text = "GRÜN";
      // 
      // radLabel2
      // 
      this.radLabel2.AutoSize = false;
      this.radLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.radLabel2.Location = new System.Drawing.Point(0, 0);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Size = new System.Drawing.Size(395, 413);
      this.radLabel2.TabIndex = 0;
      this.radLabel2.Text = resources.GetString("radLabel2.Text");
      this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
      // 
      // page_yellow
      // 
      this.page_yellow.Controls.Add(this.radLabel3);
      this.page_yellow.ItemSize = new System.Drawing.SizeF(135F, 29F);
      this.page_yellow.Location = new System.Drawing.Point(5, 35);
      this.page_yellow.Name = "page_yellow";
      this.page_yellow.Size = new System.Drawing.Size(395, 413);
      this.page_yellow.Tag = "1";
      this.page_yellow.Text = "GELB";
      // 
      // radLabel3
      // 
      this.radLabel3.AutoSize = false;
      this.radLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.radLabel3.Location = new System.Drawing.Point(0, 0);
      this.radLabel3.Name = "radLabel3";
      this.radLabel3.Size = new System.Drawing.Size(395, 413);
      this.radLabel3.TabIndex = 1;
      this.radLabel3.Text = resources.GetString("radLabel3.Text");
      this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
      // 
      // page_read
      // 
      this.page_read.Controls.Add(this.radLabel4);
      this.page_read.ItemSize = new System.Drawing.SizeF(135F, 29F);
      this.page_read.Location = new System.Drawing.Point(5, 35);
      this.page_read.Name = "page_read";
      this.page_read.Size = new System.Drawing.Size(395, 413);
      this.page_read.Tag = "2";
      this.page_read.Text = "ROT";
      // 
      // radLabel4
      // 
      this.radLabel4.AutoSize = false;
      this.radLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.radLabel4.Location = new System.Drawing.Point(0, 0);
      this.radLabel4.Name = "radLabel4";
      this.radLabel4.Size = new System.Drawing.Size(395, 413);
      this.radLabel4.TabIndex = 2;
      this.radLabel4.Text = resources.GetString("radLabel4.Text");
      this.radLabel4.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
      // 
      // radLabel1
      // 
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel1.Location = new System.Drawing.Point(0, 0);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
      this.radLabel1.Size = new System.Drawing.Size(405, 29);
      this.radLabel1.TabIndex = 0;
      this.radLabel1.Text = "1. Bitte Publikationstyp (grün/gelb/rot) wählen:";
      // 
      // splitPanel2
      // 
      this.splitPanel2.Controls.Add(this.chk_accecptLicenceText);
      this.splitPanel2.Controls.Add(this.radLabel6);
      this.splitPanel2.Controls.Add(this.txt_licenceInfo);
      this.splitPanel2.Controls.Add(this.txt_licenceName);
      this.splitPanel2.Controls.Add(this.txt_licenceHolder);
      this.splitPanel2.Controls.Add(this.txt_additionalInfo);
      this.splitPanel2.Controls.Add(this.txt_corpusInfo);
      this.splitPanel2.Controls.Add(this.txt_publishingVersion);
      this.splitPanel2.Controls.Add(this.txt_corpusName);
      this.splitPanel2.Controls.Add(this.radLabel5);
      this.splitPanel2.Location = new System.Drawing.Point(409, 0);
      this.splitPanel2.Name = "splitPanel2";
      // 
      // 
      // 
      this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(25, 25);
      this.splitPanel2.Size = new System.Drawing.Size(391, 482);
      this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.00879398F, 0F);
      this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(-7, 0);
      this.splitPanel2.TabIndex = 1;
      this.splitPanel2.TabStop = false;
      this.splitPanel2.Text = "splitPanel2";
      // 
      // chk_accecptLicenceText
      // 
      this.chk_accecptLicenceText.AutoSize = false;
      this.chk_accecptLicenceText.CheckAlignment = System.Drawing.ContentAlignment.TopLeft;
      this.chk_accecptLicenceText.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chk_accecptLicenceText.Dock = System.Windows.Forms.DockStyle.Top;
      this.chk_accecptLicenceText.Location = new System.Drawing.Point(0, 370);
      this.chk_accecptLicenceText.Name = "chk_accecptLicenceText";
      this.chk_accecptLicenceText.Size = new System.Drawing.Size(391, 106);
      this.chk_accecptLicenceText.TabIndex = 9;
      this.chk_accecptLicenceText.Text = resources.GetString("chk_accecptLicenceText.Text");
      this.chk_accecptLicenceText.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
      this.chk_accecptLicenceText.TextWrap = true;
      this.chk_accecptLicenceText.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
      // 
      // radLabel6
      // 
      this.radLabel6.AutoSize = false;
      this.radLabel6.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel6.Location = new System.Drawing.Point(0, 300);
      this.radLabel6.Name = "radLabel6";
      this.radLabel6.Size = new System.Drawing.Size(391, 70);
      this.radLabel6.TabIndex = 8;
      this.radLabel6.Text = resources.GetString("radLabel6.Text");
      this.radLabel6.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
      // 
      // txt_licenceInfo
      // 
      this.txt_licenceInfo.Dock = System.Windows.Forms.DockStyle.Top;
      this.txt_licenceInfo.Location = new System.Drawing.Point(0, 268);
      this.txt_licenceInfo.Name = "txt_licenceInfo";
      this.txt_licenceInfo.NullText = "URL zum Lizenztext";
      this.txt_licenceInfo.Size = new System.Drawing.Size(391, 32);
      this.txt_licenceInfo.TabIndex = 8;
      // 
      // txt_licenceName
      // 
      this.txt_licenceName.Dock = System.Windows.Forms.DockStyle.Top;
      this.txt_licenceName.Location = new System.Drawing.Point(0, 236);
      this.txt_licenceName.Name = "txt_licenceName";
      this.txt_licenceName.NullText = "(*) Name der Lizenz - z. B. CC-BY-SA 4.0";
      this.txt_licenceName.Size = new System.Drawing.Size(391, 32);
      this.txt_licenceName.TabIndex = 7;
      // 
      // txt_licenceHolder
      // 
      this.txt_licenceHolder.Dock = System.Windows.Forms.DockStyle.Top;
      this.txt_licenceHolder.Location = new System.Drawing.Point(0, 204);
      this.txt_licenceHolder.Name = "txt_licenceHolder";
      this.txt_licenceHolder.NullText = "(*) Name Lizenzgeber*in - z. B. Universität XY";
      this.txt_licenceHolder.Size = new System.Drawing.Size(391, 32);
      this.txt_licenceHolder.TabIndex = 6;
      // 
      // txt_additionalInfo
      // 
      this.txt_additionalInfo.Dock = System.Windows.Forms.DockStyle.Top;
      this.txt_additionalInfo.Location = new System.Drawing.Point(0, 172);
      this.txt_additionalInfo.Name = "txt_additionalInfo";
      this.txt_additionalInfo.NullText = "URL zu weiterführenden Informationen";
      this.txt_additionalInfo.Size = new System.Drawing.Size(391, 32);
      this.txt_additionalInfo.TabIndex = 5;
      // 
      // txt_corpusInfo
      // 
      this.txt_corpusInfo.Dock = System.Windows.Forms.DockStyle.Top;
      this.txt_corpusInfo.Location = new System.Drawing.Point(0, 93);
      this.txt_corpusInfo.Multiline = true;
      this.txt_corpusInfo.Name = "txt_corpusInfo";
      this.txt_corpusInfo.NullText = "Korpusbeschreibung hier eintragen ";
      // 
      // 
      // 
      this.txt_corpusInfo.RootElement.StretchVertically = true;
      this.txt_corpusInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txt_corpusInfo.Size = new System.Drawing.Size(391, 79);
      this.txt_corpusInfo.TabIndex = 4;
      // 
      // txt_publishingVersion
      // 
      this.txt_publishingVersion.Dock = System.Windows.Forms.DockStyle.Top;
      this.txt_publishingVersion.Location = new System.Drawing.Point(0, 61);
      this.txt_publishingVersion.Name = "txt_publishingVersion";
      this.txt_publishingVersion.NullText = "(*) Version oder Veröffentlichungsdatum";
      this.txt_publishingVersion.Size = new System.Drawing.Size(391, 32);
      this.txt_publishingVersion.TabIndex = 3;
      // 
      // txt_corpusName
      // 
      this.txt_corpusName.Dock = System.Windows.Forms.DockStyle.Top;
      this.txt_corpusName.Location = new System.Drawing.Point(0, 29);
      this.txt_corpusName.Name = "txt_corpusName";
      this.txt_corpusName.NullText = "(*) Korpusname (*) hier eintragen";
      this.txt_corpusName.Size = new System.Drawing.Size(391, 32);
      this.txt_corpusName.TabIndex = 2;
      // 
      // radLabel5
      // 
      this.radLabel5.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel5.Location = new System.Drawing.Point(0, 0);
      this.radLabel5.Name = "radLabel5";
      this.radLabel5.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
      this.radLabel5.Size = new System.Drawing.Size(391, 29);
      this.radLabel5.TabIndex = 1;
      this.radLabel5.Text = "2. Lizenzinfos (* = Empfohlene Angaben):";
      // 
      // CorpusPublisher
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 585);
      this.Controls.Add(this.radSplitContainer1);
      this.Controls.Add(this.headPanel1);
      this.Controls.Add(this.clearPanel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "CorpusPublisher";
      this.Text = "CorpusExplorer - Korpus publizieren";
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_publish)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
      this.radSplitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
      this.splitPanel1.ResumeLayout(false);
      this.splitPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pages_protectionMode)).EndInit();
      this.pages_protectionMode.ResumeLayout(false);
      this.page_green.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      this.page_yellow.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
      this.page_read.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
      this.splitPanel2.ResumeLayout(false);
      this.splitPanel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chk_accecptLicenceText)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_licenceInfo)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_licenceName)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_licenceHolder)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_additionalInfo)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_corpusInfo)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_publishingVersion)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_corpusName)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Tool4.DocPlusEditor.Controls.HeadPanel headPanel1;
    private Controls.WinForm.ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
    private Telerik.WinControls.UI.SplitPanel splitPanel1;
    private Telerik.WinControls.UI.RadPageView pages_protectionMode;
    private Telerik.WinControls.UI.RadPageViewPage page_green;
    private Telerik.WinControls.UI.RadPageViewPage page_yellow;
    private Telerik.WinControls.UI.RadPageViewPage page_read;
    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.SplitPanel splitPanel2;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private Telerik.WinControls.UI.RadLabel radLabel3;
    private Telerik.WinControls.UI.RadLabel radLabel4;
    private Telerik.WinControls.UI.RadButton btn_publish;
    private Telerik.WinControls.UI.RadButton btn_abort;
    private Telerik.WinControls.UI.RadLabel radLabel5;
    private Telerik.WinControls.UI.RadTextBox txt_licenceHolder;
    private Telerik.WinControls.UI.RadTextBox txt_corpusInfo;
    private Telerik.WinControls.UI.RadTextBox txt_corpusName;
    private Telerik.WinControls.UI.RadTextBox txt_licenceName;
    private Telerik.WinControls.UI.RadTextBox txt_licenceInfo;
    private Telerik.WinControls.UI.RadLabel radLabel6;
    private Telerik.WinControls.UI.RadTextBox txt_additionalInfo;
    private Telerik.WinControls.UI.RadCheckBox chk_accecptLicenceText;
    private Telerik.WinControls.UI.RadTextBox txt_publishingVersion;
  }
}