﻿namespace CorpusExplorer.Terminal.WinForm.Forms.Bridge
{
  partial class BridgeForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BridgeForm));
      this.radListView1 = new Telerik.WinControls.UI.RadListView();
      this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
      this.btn_serviceRestart = new Telerik.WinControls.UI.RadButton();
      this.panel1 = new System.Windows.Forms.Panel();
      this.lbl_status = new Telerik.WinControls.UI.RadLabel();
      this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
      this.txt_port = new Telerik.WinControls.UI.RadMaskedEditBox();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.txt_ip = new Telerik.WinControls.UI.RadMaskedEditBox();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.panel_load = new Telerik.WinControls.UI.RadPanel();
      this.btn_loadUrl = new Telerik.WinControls.UI.RadButton();
      this.panel4 = new System.Windows.Forms.Panel();
      this.btn_corpusAdd = new Telerik.WinControls.UI.RadButton();
      this.lbl_load = new Telerik.WinControls.UI.RadLabel();
      this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.radDropDownButton1 = new Telerik.WinControls.UI.RadDropDownButton();
      this.btn_new = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_load = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_save = new Telerik.WinControls.UI.RadMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.radListView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      this.radPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_serviceRestart)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_status)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_port)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_ip)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panel_load)).BeginInit();
      this.panel_load.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_loadUrl)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_corpusAdd)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_load)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
      this.radPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radDropDownButton1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radListView1
      // 
      this.radListView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radListView1.GroupItemSize = new System.Drawing.Size(200, 24);
      this.radListView1.ItemSize = new System.Drawing.Size(200, 24);
      this.radListView1.Location = new System.Drawing.Point(0, 35);
      this.radListView1.Name = "radListView1";
      this.radListView1.Size = new System.Drawing.Size(798, 393);
      this.radListView1.TabIndex = 4;
      // 
      // radPanel1
      // 
      this.radPanel1.Controls.Add(this.btn_serviceRestart);
      this.radPanel1.Controls.Add(this.panel1);
      this.radPanel1.Controls.Add(this.lbl_status);
      this.radPanel1.Controls.Add(this.radLabel3);
      this.radPanel1.Controls.Add(this.txt_port);
      this.radPanel1.Controls.Add(this.radLabel2);
      this.radPanel1.Controls.Add(this.txt_ip);
      this.radPanel1.Controls.Add(this.radLabel1);
      this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.radPanel1.Location = new System.Drawing.Point(0, 428);
      this.radPanel1.Name = "radPanel1";
      this.radPanel1.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
      this.radPanel1.Size = new System.Drawing.Size(798, 40);
      this.radPanel1.TabIndex = 0;
      // 
      // btn_serviceRestart
      // 
      this.btn_serviceRestart.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_serviceRestart.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.refresh;
      this.btn_serviceRestart.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.btn_serviceRestart.Location = new System.Drawing.Point(538, 4);
      this.btn_serviceRestart.MaximumSize = new System.Drawing.Size(200, 31);
      this.btn_serviceRestart.Name = "btn_serviceRestart";
      // 
      // 
      // 
      this.btn_serviceRestart.RootElement.MaxSize = new System.Drawing.Size(200, 31);
      this.btn_serviceRestart.Size = new System.Drawing.Size(200, 31);
      this.btn_serviceRestart.TabIndex = 8;
      this.btn_serviceRestart.Text = "BRIGE neu starten";
      this.btn_serviceRestart.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.btn_serviceRestart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btn_serviceRestart.Click += new System.EventHandler(this.btn_serviceRestart_Click);
      // 
      // panel1
      // 
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(511, 4);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(27, 34);
      this.panel1.TabIndex = 7;
      // 
      // lbl_status
      // 
      this.lbl_status.Dock = System.Windows.Forms.DockStyle.Left;
      this.lbl_status.ForeColor = System.Drawing.Color.Red;
      this.lbl_status.Location = new System.Drawing.Point(442, 4);
      this.lbl_status.Name = "lbl_status";
      this.lbl_status.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
      this.lbl_status.Size = new System.Drawing.Size(69, 34);
      this.lbl_status.TabIndex = 6;
      this.lbl_status.Text = "Gestoppt";
      // 
      // radLabel3
      // 
      this.radLabel3.Dock = System.Windows.Forms.DockStyle.Left;
      this.radLabel3.Location = new System.Drawing.Point(385, 4);
      this.radLabel3.Name = "radLabel3";
      this.radLabel3.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
      this.radLabel3.Size = new System.Drawing.Size(57, 34);
      this.radLabel3.TabIndex = 5;
      this.radLabel3.Text = "Status:";
      // 
      // txt_port
      // 
      this.txt_port.Dock = System.Windows.Forms.DockStyle.Left;
      this.txt_port.Location = new System.Drawing.Point(311, 4);
      this.txt_port.Mask = "#####";
      this.txt_port.MaskType = Telerik.WinControls.UI.MaskType.Standard;
      this.txt_port.Name = "txt_port";
      this.txt_port.Size = new System.Drawing.Size(74, 34);
      this.txt_port.TabIndex = 4;
      this.txt_port.TabStop = false;
      this.txt_port.Text = "27081";
      this.txt_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // radLabel2
      // 
      this.radLabel2.Dock = System.Windows.Forms.DockStyle.Left;
      this.radLabel2.Location = new System.Drawing.Point(202, 4);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Padding = new System.Windows.Forms.Padding(5, 4, 0, 0);
      this.radLabel2.Size = new System.Drawing.Size(109, 34);
      this.radLabel2.TabIndex = 3;
      this.radLabel2.Text = "BRIDGE-PORT:";
      // 
      // txt_ip
      // 
      this.txt_ip.Dock = System.Windows.Forms.DockStyle.Left;
      this.txt_ip.Location = new System.Drawing.Point(81, 4);
      this.txt_ip.MaskType = Telerik.WinControls.UI.MaskType.IP;
      this.txt_ip.Name = "txt_ip";
      this.txt_ip.Size = new System.Drawing.Size(121, 34);
      this.txt_ip.TabIndex = 2;
      this.txt_ip.TabStop = false;
      this.txt_ip.Text = "127. 0 . 0 . 1 ";
      this.txt_ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // radLabel1
      // 
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.radLabel1.Location = new System.Drawing.Point(2, 4);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
      this.radLabel1.Size = new System.Drawing.Size(79, 34);
      this.radLabel1.TabIndex = 0;
      this.radLabel1.Text = "BRDIGE-IP:";
      // 
      // panel_load
      // 
      this.panel_load.Controls.Add(this.btn_loadUrl);
      this.panel_load.Controls.Add(this.panel4);
      this.panel_load.Controls.Add(this.btn_corpusAdd);
      this.panel_load.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel_load.Location = new System.Drawing.Point(2, 2);
      this.panel_load.Name = "panel_load";
      this.panel_load.Size = new System.Drawing.Size(383, 31);
      this.panel_load.TabIndex = 0;
      // 
      // btn_loadUrl
      // 
      this.btn_loadUrl.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_loadUrl.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.cloud_data_storage;
      this.btn_loadUrl.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.btn_loadUrl.Location = new System.Drawing.Point(193, 0);
      this.btn_loadUrl.Name = "btn_loadUrl";
      // 
      // 
      // 
      this.btn_loadUrl.RootElement.MaxSize = new System.Drawing.Size(0, 0);
      this.btn_loadUrl.Size = new System.Drawing.Size(190, 31);
      this.btn_loadUrl.TabIndex = 4;
      this.btn_loadUrl.Text = "Online-Korpus";
      this.btn_loadUrl.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.btn_loadUrl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btn_loadUrl.Click += new System.EventHandler(this.btn_loadUrl_Click);
      // 
      // panel4
      // 
      this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel4.Location = new System.Drawing.Point(190, 0);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(3, 31);
      this.panel4.TabIndex = 6;
      // 
      // btn_corpusAdd
      // 
      this.btn_corpusAdd.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_corpusAdd.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.cabinet1;
      this.btn_corpusAdd.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.btn_corpusAdd.Location = new System.Drawing.Point(0, 0);
      this.btn_corpusAdd.Name = "btn_corpusAdd";
      // 
      // 
      // 
      this.btn_corpusAdd.RootElement.MaxSize = new System.Drawing.Size(0, 0);
      this.btn_corpusAdd.Size = new System.Drawing.Size(190, 31);
      this.btn_corpusAdd.TabIndex = 3;
      this.btn_corpusAdd.Text = "Korpus hinzufügen";
      this.btn_corpusAdd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.btn_corpusAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btn_corpusAdd.Click += new System.EventHandler(this.btn_corpusAdd_Click);
      // 
      // lbl_load
      // 
      this.lbl_load.AutoSize = false;
      this.lbl_load.Dock = System.Windows.Forms.DockStyle.Left;
      this.lbl_load.Location = new System.Drawing.Point(388, 2);
      this.lbl_load.Name = "lbl_load";
      this.lbl_load.Size = new System.Drawing.Size(223, 31);
      this.lbl_load.TabIndex = 9;
      this.lbl_load.Text = "Korpora werden geladen ...";
      this.lbl_load.Visible = false;
      // 
      // radPanel2
      // 
      this.radPanel2.Controls.Add(this.lbl_load);
      this.radPanel2.Controls.Add(this.panel2);
      this.radPanel2.Controls.Add(this.radDropDownButton1);
      this.radPanel2.Controls.Add(this.panel_load);
      this.radPanel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.radPanel2.Location = new System.Drawing.Point(0, 0);
      this.radPanel2.Name = "radPanel2";
      this.radPanel2.Padding = new System.Windows.Forms.Padding(2);
      this.radPanel2.Size = new System.Drawing.Size(798, 35);
      this.radPanel2.TabIndex = 9;
      // 
      // panel2
      // 
      this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel2.Location = new System.Drawing.Point(385, 2);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(3, 31);
      this.panel2.TabIndex = 11;
      // 
      // radDropDownButton1
      // 
      this.radDropDownButton1.Dock = System.Windows.Forms.DockStyle.Right;
      this.radDropDownButton1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.list;
      this.radDropDownButton1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btn_new,
            this.btn_load,
            this.btn_save});
      this.radDropDownButton1.Location = new System.Drawing.Point(747, 2);
      this.radDropDownButton1.Name = "radDropDownButton1";
      this.radDropDownButton1.Size = new System.Drawing.Size(49, 31);
      this.radDropDownButton1.TabIndex = 10;
      // 
      // btn_new
      // 
      this.btn_new.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.document;
      this.btn_new.Name = "btn_new";
      this.btn_new.Text = "Neue Liste";
      this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
      // 
      // btn_load
      // 
      this.btn_load.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.folder_open;
      this.btn_load.Name = "btn_load";
      this.btn_load.Text = "Liste Laden";
      this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
      // 
      // btn_save
      // 
      this.btn_save.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save;
      this.btn_save.Name = "btn_save";
      this.btn_save.Text = "Liste speichern";
      this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
      // 
      // BridgeForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(798, 468);
      this.Controls.Add(this.radListView1);
      this.Controls.Add(this.radPanel1);
      this.Controls.Add(this.radPanel2);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(800, 503);
      this.Name = "BridgeForm";
      this.Text = "CorpusExplorer BRIDGE";
      ((System.ComponentModel.ISupportInitialize)(this.radListView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      this.radPanel1.ResumeLayout(false);
      this.radPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_serviceRestart)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_status)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_port)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_ip)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panel_load)).EndInit();
      this.panel_load.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_loadUrl)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_corpusAdd)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lbl_load)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
      this.radPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radDropDownButton1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    private Telerik.WinControls.UI.RadListView radListView1;
    private Telerik.WinControls.UI.RadPanel radPanel1;
    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.RadMaskedEditBox txt_ip;
    private Telerik.WinControls.UI.RadMaskedEditBox txt_port;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private Telerik.WinControls.UI.RadLabel lbl_status;
    private Telerik.WinControls.UI.RadLabel radLabel3;
    private Telerik.WinControls.UI.RadButton btn_serviceRestart;
    private System.Windows.Forms.Panel panel1;
    private Telerik.WinControls.UI.RadPanel panel_load;
    private Telerik.WinControls.UI.RadButton btn_loadUrl;
    private System.Windows.Forms.Panel panel4;
    private Telerik.WinControls.UI.RadButton btn_corpusAdd;
    private Telerik.WinControls.UI.RadLabel lbl_load;
    private Telerik.WinControls.UI.RadPanel radPanel2;
    private Telerik.WinControls.UI.RadDropDownButton radDropDownButton1;
    private Telerik.WinControls.UI.RadMenuItem btn_new;
    private Telerik.WinControls.UI.RadMenuItem btn_load;
    private Telerik.WinControls.UI.RadMenuItem btn_save;
    private System.Windows.Forms.Panel panel2;
  }
}