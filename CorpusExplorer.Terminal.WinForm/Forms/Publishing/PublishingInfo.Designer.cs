namespace CorpusExplorer.Terminal.WinForm.Forms.Publishing
{
  partial class PublishingInfo
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
      this.headPanel1 = new CorpusExplorer.Tool4.DocPlusEditor.Controls.HeadPanel();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.txt_corpusName = new Telerik.WinControls.UI.RadTextBox();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.txt_corpusInfo = new Telerik.WinControls.UI.RadTextBox();
      this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
      this.txt_licenceHolder = new Telerik.WinControls.UI.RadTextBox();
      this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
      this.txt_licenceName = new Telerik.WinControls.UI.RadTextBox();
      this.link_licence = new System.Windows.Forms.LinkLabel();
      this.link_info = new System.Windows.Forms.LinkLabel();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.btn_ok = new Telerik.WinControls.UI.RadButton();
      this.btn_abort = new Telerik.WinControls.UI.RadButton();
      this.txt_version = new Telerik.WinControls.UI.RadTextBox();
      this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_corpusName)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_corpusInfo)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_licenceHolder)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_licenceName)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_version)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // headPanel1
      // 
      this.headPanel1.BackColor = System.Drawing.Color.White;
      this.headPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.headPanel1.Font = new System.Drawing.Font("Segoe UI", 12F);
      this.headPanel1.HeadPanelDescription = "Folgende Anmerkungen wurden hinterlegt:";
      this.headPanel1.HeadPanelImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.archive_download_48px;
      this.headPanel1.HeadPanelTitle = "Informationen zum Korpus";
      this.headPanel1.Location = new System.Drawing.Point(0, 0);
      this.headPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.headPanel1.Name = "headPanel1";
      this.headPanel1.Size = new System.Drawing.Size(513, 55);
      this.headPanel1.TabIndex = 2;
      // 
      // radLabel1
      // 
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.radLabel1.Location = new System.Drawing.Point(0, 55);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
      this.radLabel1.Size = new System.Drawing.Size(86, 31);
      this.radLabel1.TabIndex = 3;
      this.radLabel1.Text = "Korpusname:";
      // 
      // txt_corpusName
      // 
      this.txt_corpusName.Dock = System.Windows.Forms.DockStyle.Top;
      this.txt_corpusName.Location = new System.Drawing.Point(0, 86);
      this.txt_corpusName.Name = "txt_corpusName";
      this.txt_corpusName.NullText = "Kein Korpusnamen eingetragen";
      this.txt_corpusName.ReadOnly = true;
      this.txt_corpusName.Size = new System.Drawing.Size(513, 32);
      this.txt_corpusName.TabIndex = 4;
      // 
      // radLabel2
      // 
      this.radLabel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.radLabel2.Location = new System.Drawing.Point(0, 181);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
      this.radLabel2.Size = new System.Drawing.Size(135, 31);
      this.radLabel2.TabIndex = 5;
      this.radLabel2.Text = "Korpusbeschreibung:";
      // 
      // txt_corpusInfo
      // 
      this.txt_corpusInfo.Dock = System.Windows.Forms.DockStyle.Top;
      this.txt_corpusInfo.Location = new System.Drawing.Point(0, 212);
      this.txt_corpusInfo.Multiline = true;
      this.txt_corpusInfo.Name = "txt_corpusInfo";
      this.txt_corpusInfo.NullText = "Keine Korpusbeschreibung vorhanden";
      this.txt_corpusInfo.ReadOnly = true;
      // 
      // 
      // 
      this.txt_corpusInfo.RootElement.StretchVertically = true;
      this.txt_corpusInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txt_corpusInfo.Size = new System.Drawing.Size(513, 136);
      this.txt_corpusInfo.TabIndex = 6;
      // 
      // radLabel3
      // 
      this.radLabel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.radLabel3.Location = new System.Drawing.Point(0, 367);
      this.radLabel3.Name = "radLabel3";
      this.radLabel3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
      this.radLabel3.Size = new System.Drawing.Size(99, 31);
      this.radLabel3.TabIndex = 7;
      this.radLabel3.Text = "Lizenzgeber*in:";
      // 
      // txt_licenceHolder
      // 
      this.txt_licenceHolder.Dock = System.Windows.Forms.DockStyle.Top;
      this.txt_licenceHolder.Location = new System.Drawing.Point(0, 398);
      this.txt_licenceHolder.Name = "txt_licenceHolder";
      this.txt_licenceHolder.NullText = "Keine Lizenzgeber*in eingetragen";
      this.txt_licenceHolder.ReadOnly = true;
      this.txt_licenceHolder.Size = new System.Drawing.Size(513, 32);
      this.txt_licenceHolder.TabIndex = 8;
      // 
      // radLabel4
      // 
      this.radLabel4.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.radLabel4.Location = new System.Drawing.Point(0, 430);
      this.radLabel4.Name = "radLabel4";
      this.radLabel4.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
      this.radLabel4.Size = new System.Drawing.Size(47, 31);
      this.radLabel4.TabIndex = 9;
      this.radLabel4.Text = "Lizenz:";
      // 
      // txt_licenceName
      // 
      this.txt_licenceName.Dock = System.Windows.Forms.DockStyle.Top;
      this.txt_licenceName.Location = new System.Drawing.Point(0, 461);
      this.txt_licenceName.Name = "txt_licenceName";
      this.txt_licenceName.NullText = "Keine Lizenz - siehe ggf. Link \'Vollständiger Lizenztext\'";
      this.txt_licenceName.ReadOnly = true;
      this.txt_licenceName.Size = new System.Drawing.Size(513, 32);
      this.txt_licenceName.TabIndex = 10;
      // 
      // link_licence
      // 
      this.link_licence.AutoSize = true;
      this.link_licence.Dock = System.Windows.Forms.DockStyle.Top;
      this.link_licence.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.link_licence.Location = new System.Drawing.Point(0, 493);
      this.link_licence.Name = "link_licence";
      this.link_licence.Size = new System.Drawing.Size(160, 19);
      this.link_licence.TabIndex = 11;
      this.link_licence.TabStop = true;
      this.link_licence.Text = "[Vollständiger Lizenztext]";
      this.link_licence.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_licence_LinkClicked);
      // 
      // link_info
      // 
      this.link_info.AutoSize = true;
      this.link_info.Dock = System.Windows.Forms.DockStyle.Top;
      this.link_info.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.link_info.Location = new System.Drawing.Point(0, 348);
      this.link_info.Name = "link_info";
      this.link_info.Size = new System.Drawing.Size(202, 19);
      this.link_info.TabIndex = 12;
      this.link_info.TabStop = true;
      this.link_info.Text = "[Weiterführende Informationen]";
      this.link_info.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_info_LinkClicked);
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.btn_ok);
      this.clearPanel1.Controls.Add(this.btn_abort);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.clearPanel1.Location = new System.Drawing.Point(0, 536);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Padding = new System.Windows.Forms.Padding(10);
      this.clearPanel1.Size = new System.Drawing.Size(513, 53);
      this.clearPanel1.TabIndex = 13;
      // 
      // btn_ok
      // 
      this.btn_ok.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_ok.Location = new System.Drawing.Point(293, 10);
      this.btn_ok.Name = "btn_ok";
      this.btn_ok.Size = new System.Drawing.Size(210, 33);
      this.btn_ok.TabIndex = 1;
      this.btn_ok.Text = "Lizenz akzeptieren";
      this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
      // 
      // btn_abort
      // 
      this.btn_abort.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_abort.Location = new System.Drawing.Point(10, 10);
      this.btn_abort.Name = "btn_abort";
      this.btn_abort.Size = new System.Drawing.Size(210, 33);
      this.btn_abort.TabIndex = 0;
      this.btn_abort.Text = "Abbrechen (nicht laden)";
      this.btn_abort.Click += new System.EventHandler(this.btn_abort_Click);
      // 
      // txt_version
      // 
      this.txt_version.Dock = System.Windows.Forms.DockStyle.Top;
      this.txt_version.Location = new System.Drawing.Point(0, 149);
      this.txt_version.Name = "txt_version";
      this.txt_version.NullText = "Keine Version oder Veröffentlichungsdatum angegeben";
      this.txt_version.ReadOnly = true;
      this.txt_version.Size = new System.Drawing.Size(513, 32);
      this.txt_version.TabIndex = 15;
      // 
      // radLabel5
      // 
      this.radLabel5.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.radLabel5.Location = new System.Drawing.Point(0, 118);
      this.radLabel5.Name = "radLabel5";
      this.radLabel5.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
      this.radLabel5.Size = new System.Drawing.Size(215, 31);
      this.radLabel5.TabIndex = 14;
      this.radLabel5.Text = "Version / Veröffentlichungsdatum:";
      // 
      // PublishingInfo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(513, 589);
      this.Controls.Add(this.clearPanel1);
      this.Controls.Add(this.link_licence);
      this.Controls.Add(this.txt_licenceName);
      this.Controls.Add(this.radLabel4);
      this.Controls.Add(this.txt_licenceHolder);
      this.Controls.Add(this.radLabel3);
      this.Controls.Add(this.link_info);
      this.Controls.Add(this.txt_corpusInfo);
      this.Controls.Add(this.radLabel2);
      this.Controls.Add(this.txt_version);
      this.Controls.Add(this.radLabel5);
      this.Controls.Add(this.txt_corpusName);
      this.Controls.Add(this.radLabel1);
      this.Controls.Add(this.headPanel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "PublishingInfo";
      this.Text = "Informationen zum Korpus";
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_corpusName)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_corpusInfo)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_licenceHolder)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_licenceName)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_version)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Tool4.DocPlusEditor.Controls.HeadPanel headPanel1;
    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.RadTextBox txt_corpusName;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private Telerik.WinControls.UI.RadTextBox txt_corpusInfo;
    private Telerik.WinControls.UI.RadLabel radLabel3;
    private Telerik.WinControls.UI.RadTextBox txt_licenceHolder;
    private Telerik.WinControls.UI.RadLabel radLabel4;
    private Telerik.WinControls.UI.RadTextBox txt_licenceName;
    private System.Windows.Forms.LinkLabel link_licence;
    private System.Windows.Forms.LinkLabel link_info;
    private Controls.WinForm.ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadButton btn_ok;
    private Telerik.WinControls.UI.RadButton btn_abort;
    private Telerik.WinControls.UI.RadTextBox txt_version;
    private Telerik.WinControls.UI.RadLabel radLabel5;
  }
}