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
      this.btn_go.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_go.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_go.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.btn_go.Location = new System.Drawing.Point(377, 0);
      this.btn_go.Name = "btn_go";
      this.btn_go.Size = new System.Drawing.Size(36, 36);
      this.btn_go.TabIndex = 7;
      this.toolTip1.SetToolTip(this.btn_go, "Aktualisieren");
      this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
      // 
      // btn_selectLayer
      // 
      this.btn_selectLayer.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_selectLayer.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.layers;
      this.btn_selectLayer.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.btn_selectLayer.Location = new System.Drawing.Point(0, 0);
      this.btn_selectLayer.Name = "btn_selectLayer";
      this.btn_selectLayer.Size = new System.Drawing.Size(36, 36);
      this.btn_selectLayer.TabIndex = 8;
      this.toolTip1.SetToolTip(this.btn_selectLayer, "Layer ändern");
      this.btn_selectLayer.Click += new System.EventHandler(this.btn_selectLayer_Click);
      // 
      // cmb_values
      // 
      this.cmb_values.BackColor = System.Drawing.Color.White;
      this.cmb_values.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cmb_values.Font = new System.Drawing.Font("Segoe UI", 11F);
      this.cmb_values.Location = new System.Drawing.Point(36, 0);
      this.cmb_values.Margin = new System.Windows.Forms.Padding(5, 8, 5, 6);
      this.cmb_values.Name = "cmb_values";
      this.cmb_values.SelectedLayerDisplayname = null;
      this.cmb_values.Size = new System.Drawing.Size(341, 36);
      this.cmb_values.TabIndex = 9;
      this.toolTip1.SetToolTip(this.cmb_values, "Geben Sie hier die gewünschten Wert(e)/Abfrage(n) ein.");
      // 
      // WordBag
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.cmb_values);
      this.Controls.Add(this.btn_selectLayer);
      this.Controls.Add(this.btn_go);
      this.Name = "WordBag";
      this.Size = new System.Drawing.Size(413, 36);
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
