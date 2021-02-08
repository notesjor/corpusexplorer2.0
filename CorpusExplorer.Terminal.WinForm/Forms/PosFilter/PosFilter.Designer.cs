namespace CorpusExplorer.Terminal.WinForm.Forms.SelectLayer
{
  partial class PosFilter
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PosFilter));
      this.layerSettings1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.LayerSettings();
      this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
      this.txt_results = new Telerik.WinControls.UI.RadAutoCompleteBox();
      this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
      this.txt_query = new Telerik.WinControls.UI.RadTextBox();
      this.btn_go = new Telerik.WinControls.UI.RadButton();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.drop_operator = new Telerik.WinControls.UI.RadDropDownList();
      this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
      this.chk_all = new Telerik.WinControls.UI.RadCheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
      this.radGroupBox3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_results)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
      this.radGroupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_query)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_go)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.drop_operator)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
      this.radGroupBox4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chk_all)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // headPanel1
      // 
      this.headPanel1.HeadPanelDescription = "Nutzen Sie korrespondierende Werte zum Filtern";
      this.headPanel1.HeadPanelImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.filter64;
      this.headPanel1.HeadPanelTitle = "Layer-Filter";
      resources.ApplyResources(this.headPanel1, "headPanel1");
      // 
      // radPanel1
      // 
      resources.ApplyResources(this.radPanel1, "radPanel1");
      // 
      // layerSettings1
      // 
      this.layerSettings1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.layerSettings1, "layerSettings1");
      this.layerSettings1.Header = "1. Layer (korrespondierend)";
      this.layerSettings1.IsLayerOptional = false;
      this.layerSettings1.Name = "layerSettings1";
      this.layerSettings1.SlectedLayerChanged += new System.EventHandler(this.layerSettings1_SlectedLayerChanged);
      // 
      // radGroupBox3
      // 
      this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox3.Controls.Add(this.txt_results);
      resources.ApplyResources(this.radGroupBox3, "radGroupBox3");
      this.radGroupBox3.Name = "radGroupBox3";
      // 
      // txt_results
      // 
      resources.ApplyResources(this.txt_results, "txt_results");
      this.txt_results.Multiline = true;
      this.txt_results.Name = "txt_results";
      this.txt_results.ShowClearButton = true;
      // 
      // radGroupBox2
      // 
      this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add(this.txt_query);
      this.radGroupBox2.Controls.Add(this.btn_go);
      resources.ApplyResources(this.radGroupBox2, "radGroupBox2");
      this.radGroupBox2.Name = "radGroupBox2";
      // 
      // txt_query
      // 
      resources.ApplyResources(this.txt_query, "txt_query");
      this.txt_query.Name = "txt_query";
      // 
      // btn_go
      // 
      resources.ApplyResources(this.btn_go, "btn_go");
      this.btn_go.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_go.Name = "btn_go";
      this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.drop_operator);
      resources.ApplyResources(this.radGroupBox1, "radGroupBox1");
      this.radGroupBox1.Name = "radGroupBox1";
      // 
      // drop_operator
      // 
      resources.ApplyResources(this.drop_operator, "drop_operator");
      this.drop_operator.Name = "drop_operator";
      // 
      // radGroupBox4
      // 
      this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox4.Controls.Add(this.chk_all);
      resources.ApplyResources(this.radGroupBox4, "radGroupBox4");
      this.radGroupBox4.Name = "radGroupBox4";
      // 
      // chk_all
      // 
      resources.ApplyResources(this.chk_all, "chk_all");
      this.chk_all.Name = "chk_all";
      // 
      // PosFilter
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.radGroupBox4);
      this.Controls.Add(this.radGroupBox3);
      this.Controls.Add(this.radGroupBox2);
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this.layerSettings1);
      this.DisplayAbort = true;
      this.Name = "PosFilter";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.ButtonOkClick += new System.EventHandler(this.PosFilter_ButtonOkClick);
      this.Load += new System.EventHandler(this.PosFilter_Load);
      this.Controls.SetChildIndex(this.headPanel1, 0);
      this.Controls.SetChildIndex(this.layerSettings1, 0);
      this.Controls.SetChildIndex(this.radGroupBox1, 0);
      this.Controls.SetChildIndex(this.radGroupBox2, 0);
      this.Controls.SetChildIndex(this.radGroupBox3, 0);
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.radGroupBox4, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
      this.radGroupBox3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.txt_results)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
      this.radGroupBox2.ResumeLayout(false);
      this.radGroupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_query)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_go)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.drop_operator)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
      this.radGroupBox4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.chk_all)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.WinForm.LayerSettings layerSettings1;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
    private Telerik.WinControls.UI.RadAutoCompleteBox txt_results;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
    private Telerik.WinControls.UI.RadTextBox txt_query;
    private Telerik.WinControls.UI.RadButton btn_go;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadDropDownList drop_operator;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
    private Telerik.WinControls.UI.RadCheckBox chk_all;
  }
}