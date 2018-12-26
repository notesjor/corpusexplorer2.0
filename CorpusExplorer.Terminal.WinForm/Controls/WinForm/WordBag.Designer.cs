using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class WordBag
  {
    /// <summary> 
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Komponenten-Designer generierter Code

    /// <summary> 
    /// Erforderliche Methode für die Designerunterstützung. 
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordBag));
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.btn_go = new Telerik.WinControls.UI.RadButton();
      this.btn_selectLayer = new Telerik.WinControls.UI.RadButton();
      this.cmb_values = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.SelectLayerValues.SelectLayerValuesControl();
      ((System.ComponentModel.ISupportInitialize)(this.btn_go)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_selectLayer)).BeginInit();
      this.SuspendLayout();
      // 
      // btn_go
      // 
      resources.ApplyResources(this.btn_go, "btn_go");
      this.btn_go.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_go.Name = "btn_go";
      this.toolTip1.SetToolTip(this.btn_go, resources.GetString("btn_go.ToolTip"));
      this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
      // 
      // btn_selectLayer
      // 
      resources.ApplyResources(this.btn_selectLayer, "btn_selectLayer");
      this.btn_selectLayer.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.layers;
      this.btn_selectLayer.Name = "btn_selectLayer";
      this.toolTip1.SetToolTip(this.btn_selectLayer, resources.GetString("btn_selectLayer.ToolTip"));
      this.btn_selectLayer.Click += new System.EventHandler(this.btn_selectLayer_Click);
      // 
      // cmb_values
      // 
      this.cmb_values.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.cmb_values, "cmb_values");
      this.cmb_values.Name = "cmb_values";
      this.cmb_values.ResultQueries = new string[0];
      this.cmb_values.SelectedLayerDisplayname = null;
      this.toolTip1.SetToolTip(this.cmb_values, resources.GetString("cmb_values.ToolTip"));
      // 
      // WordBag
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.cmb_values);
      this.Controls.Add(this.btn_selectLayer);
      this.Controls.Add(this.btn_go);
      this.Name = "WordBag";
      resources.ApplyResources(this, "$this");
      ((System.ComponentModel.ISupportInitialize)(this.btn_go)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_selectLayer)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.ToolTip toolTip1;
    private Telerik.WinControls.UI.RadButton btn_go;
    private Telerik.WinControls.UI.RadButton btn_selectLayer;
    private SelectLayerValues.SelectLayerValuesControl cmb_values;
  }
}
