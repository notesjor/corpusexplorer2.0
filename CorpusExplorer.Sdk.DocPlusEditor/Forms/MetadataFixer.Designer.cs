using CorpusExplorer.Tool4.DocPlusEditor.Controls;
using CorpusExplorer.Tool4.DocPlusEditor.Properties;

namespace CorpusExplorer.Tool4.DocPlusEditor.Forms
{
  partial class MetadataFixer
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetadataFixer));
      this._headPanel1 = new CorpusExplorer.Tool4.DocPlusEditor.Controls.HeadPanel();
      this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
      this.cmb_1_metaName = new Telerik.WinControls.UI.RadDropDownList();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btn_abort = new Telerik.WinControls.UI.RadButton();
      this.btn_ok = new Telerik.WinControls.UI.RadButton();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.cmb_2_selectAutoFix = new Telerik.WinControls.UI.RadDropDownList();
      this.grp_type = new Telerik.WinControls.UI.RadGroupBox();
      this.cmb_3_convertType = new Telerik.WinControls.UI.RadDropDownList();
      this.grp_options = new Telerik.WinControls.UI.RadGroupBox();
      this.txt_4_options = new Telerik.WinControls.UI.RadTextBox();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
      this.radGroupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cmb_1_metaName)).BeginInit();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cmb_2_selectAutoFix)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grp_type)).BeginInit();
      this.grp_type.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cmb_3_convertType)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grp_options)).BeginInit();
      this.grp_options.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_4_options)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // _headPanel1
      // 
      this._headPanel1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this._headPanel1, "_headPanel1");
      this._headPanel1.HeadPanelDescription = "Fehler in/mit Metadaten bereinigen.";
      this._headPanel1.HeadPanelImage = global::CorpusExplorer.Tool4.DocPlusEditor.Properties.Resources.tag_green1;
      this._headPanel1.HeadPanelTitle = "Meta Auto-Fix";
      this._headPanel1.Name = "_headPanel1";
      this._headPanel1.Tag = "";
      // 
      // radGroupBox2
      // 
      this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add(this.cmb_1_metaName);
      resources.ApplyResources(this.radGroupBox2, "radGroupBox2");
      this.radGroupBox2.Name = "radGroupBox2";
      // 
      // cmb_1_metaName
      // 
      resources.ApplyResources(this.cmb_1_metaName, "cmb_1_metaName");
      this.cmb_1_metaName.DropDownAnimationEnabled = true;
      this.cmb_1_metaName.Name = "cmb_1_metaName";
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
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.cmb_2_selectAutoFix);
      resources.ApplyResources(this.radGroupBox1, "radGroupBox1");
      this.radGroupBox1.Name = "radGroupBox1";
      // 
      // cmb_2_selectAutoFix
      // 
      resources.ApplyResources(this.cmb_2_selectAutoFix, "cmb_2_selectAutoFix");
      this.cmb_2_selectAutoFix.DropDownAnimationEnabled = true;
      this.cmb_2_selectAutoFix.Name = "cmb_2_selectAutoFix";
      this.cmb_2_selectAutoFix.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cmb_fix_SelectedIndexChanged);
      // 
      // grp_type
      // 
      this.grp_type.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.grp_type.Controls.Add(this.cmb_3_convertType);
      resources.ApplyResources(this.grp_type, "grp_type");
      this.grp_type.Name = "grp_type";
      // 
      // cmb_3_convertType
      // 
      resources.ApplyResources(this.cmb_3_convertType, "cmb_3_convertType");
      this.cmb_3_convertType.DropDownAnimationEnabled = true;
      this.cmb_3_convertType.Name = "cmb_3_convertType";
      this.cmb_3_convertType.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cmb_type_SelectedIndexChanged);
      // 
      // grp_options
      // 
      this.grp_options.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.grp_options.Controls.Add(this.txt_4_options);
      resources.ApplyResources(this.grp_options, "grp_options");
      this.grp_options.Name = "grp_options";
      // 
      // txt_4_options
      // 
      resources.ApplyResources(this.txt_4_options, "txt_4_options");
      this.txt_4_options.Name = "txt_4_options";
      // 
      // MetadataFixer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.grp_options);
      this.Controls.Add(this.grp_type);
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.radGroupBox2);
      this.Controls.Add(this._headPanel1);
      this.Name = "MetadataFixer";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
      this.radGroupBox2.ResumeLayout(false);
      this.radGroupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cmb_1_metaName)).EndInit();
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cmb_2_selectAutoFix)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grp_type)).EndInit();
      this.grp_type.ResumeLayout(false);
      this.grp_type.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cmb_3_convertType)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grp_options)).EndInit();
      this.grp_options.ResumeLayout(false);
      this.grp_options.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_4_options)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private HeadPanel _headPanel1;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
    private Telerik.WinControls.UI.RadDropDownList cmb_1_metaName;
    private System.Windows.Forms.Panel panel1;
    private Telerik.WinControls.UI.RadButton btn_abort;
    private Telerik.WinControls.UI.RadButton btn_ok;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadDropDownList cmb_2_selectAutoFix;
    private Telerik.WinControls.UI.RadGroupBox grp_type;
    private Telerik.WinControls.UI.RadDropDownList cmb_3_convertType;
    private Telerik.WinControls.UI.RadGroupBox grp_options;
    private Telerik.WinControls.UI.RadTextBox txt_4_options;
  }
}