using CorpusExplorer.Tool4.DocPlusEditor.Controls;
using CorpusExplorer.Tool4.DocPlusEditor.Properties;

namespace CorpusExplorer.Tool4.DocPlusEditor.Forms
{
  partial class MetadataNew
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetadataNew));
      this._headPanel1 = new CorpusExplorer.Tool4.DocPlusEditor.Controls.HeadPanel();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.panel_warn = new System.Windows.Forms.Panel();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.txt_propertyName = new Telerik.WinControls.UI.RadTextBox();
      this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
      this.cmb_type = new Telerik.WinControls.UI.RadDropDownList();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btn_abort = new Telerik.WinControls.UI.RadButton();
      this.btn_ok = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      this.panel_warn.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_propertyName)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
      this.radGroupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cmb_type)).BeginInit();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // _headPanel1
      // 
      this._headPanel1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this._headPanel1, "_headPanel1");
      this._headPanel1.HeadPanelDescription = "Fügen Sie Projektweit eine neue Metaangabe hinzu.";
      this._headPanel1.HeadPanelImage = global::CorpusExplorer.Tool4.DocPlusEditor.Properties.Resources.tag_green1;
      this._headPanel1.HeadPanelTitle = "Neue Metaangabe";
      this._headPanel1.Name = "_headPanel1";
      this._headPanel1.Tag = "";
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.panel_warn);
      this.radGroupBox1.Controls.Add(this.txt_propertyName);
      resources.ApplyResources(this.radGroupBox1, "radGroupBox1");
      this.radGroupBox1.Name = "radGroupBox1";
      // 
      // panel_warn
      // 
      this.panel_warn.Controls.Add(this.radLabel1);
      this.panel_warn.Controls.Add(this.pictureBox1);
      resources.ApplyResources(this.panel_warn, "panel_warn");
      this.panel_warn.Name = "panel_warn";
      // 
      // radLabel1
      // 
      resources.ApplyResources(this.radLabel1, "radLabel1");
      this.radLabel1.Name = "radLabel1";
      // 
      // pictureBox1
      // 
      resources.ApplyResources(this.pictureBox1, "pictureBox1");
      this.pictureBox1.Image = global::CorpusExplorer.Tool4.DocPlusEditor.Properties.Resources.button_rounded_red_delete;
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.TabStop = false;
      // 
      // txt_propertyName
      // 
      resources.ApplyResources(this.txt_propertyName, "txt_propertyName");
      this.txt_propertyName.Name = "txt_propertyName";
      this.txt_propertyName.TextChanged += new System.EventHandler(this.txt_propertyName_TextChanged);
      // 
      // radGroupBox2
      // 
      this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add(this.cmb_type);
      resources.ApplyResources(this.radGroupBox2, "radGroupBox2");
      this.radGroupBox2.Name = "radGroupBox2";
      // 
      // cmb_type
      // 
      resources.ApplyResources(this.cmb_type, "cmb_type");
      this.cmb_type.DropDownAnimationEnabled = true;
      this.cmb_type.DropDownHeight = 133;
      this.cmb_type.ItemHeight = 45;
      this.cmb_type.Name = "cmb_type";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btn_abort);
      this.panel1.Controls.Add(this.btn_ok);
      resources.ApplyResources(this.panel1, "panel1");
      this.panel1.Name = "panel1";
      // 
      // btn_abort
      // 
      resources.ApplyResources(this.btn_abort, "btn_abort");
      this.btn_abort.Name = "btn_abort";
      this.btn_abort.Click += new System.EventHandler(this.btn_abort_Click);
      // 
      // btn_ok
      // 
      resources.ApplyResources(this.btn_ok, "btn_ok");
      this.btn_ok.Name = "btn_ok";
      this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
      // 
      // MetadataNew
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.radGroupBox2);
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this._headPanel1);
      this.Name = "MetadataNew";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      this.panel_warn.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_propertyName)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
      this.radGroupBox2.ResumeLayout(false);
      this.radGroupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cmb_type)).EndInit();
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private HeadPanel _headPanel1;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadTextBox txt_propertyName;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
    private Telerik.WinControls.UI.RadDropDownList cmb_type;
    private System.Windows.Forms.Panel panel1;
    private Telerik.WinControls.UI.RadButton btn_abort;
    private Telerik.WinControls.UI.RadButton btn_ok;
        private System.Windows.Forms.Panel panel_warn;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}