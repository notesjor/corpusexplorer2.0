namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm.Metadata
{
  partial class NewMetadataDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewMetadataDialog));
      this.ihdPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.txt_propertyName = new Telerik.WinControls.UI.RadTextBox();
      this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
      this.cmb_type = new Telerik.WinControls.UI.RadDropDownList();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_propertyName)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
      this.radGroupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cmb_type)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      resources.ApplyResources(this.radPanel1, "radPanel1");
      // 
      // ihdPanel1
      // 
      this.ihdPanel1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.ihdPanel1, "ihdPanel1");
      this.ihdPanel1.IHDDescription = "Fügen Sie Projektweit eine neue Metaangabe hinzu.";
      this.ihdPanel1.IHDHeader = "Neue Metaangabe";
      this.ihdPanel1.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.tag_green1;
      this.ihdPanel1.Name = "ihdPanel1";
      this.ihdPanel1.Tag = "";
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.txt_propertyName);
      resources.ApplyResources(this.radGroupBox1, "radGroupBox1");
      this.radGroupBox1.Name = "radGroupBox1";
      // 
      // txt_propertyName
      // 
      resources.ApplyResources(this.txt_propertyName, "txt_propertyName");
      this.txt_propertyName.Name = "txt_propertyName";
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
      this.cmb_type.Name = "cmb_type";
      // 
      // NewMetadataDialog
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.radGroupBox2);
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this.ihdPanel1);
      this.DisplayAbort = true;
      this.Name = "NewMetadataDialog";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Controls.SetChildIndex(this.ihdPanel1, 0);
      this.Controls.SetChildIndex(this.radGroupBox1, 0);
      this.Controls.SetChildIndex(this.radGroupBox2, 0);
      this.Controls.SetChildIndex(this.radPanel1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_propertyName)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
      this.radGroupBox2.ResumeLayout(false);
      this.radGroupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cmb_type)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private IHDPanel ihdPanel1;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadTextBox txt_propertyName;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
    private Telerik.WinControls.UI.RadDropDownList cmb_type;
  }
}