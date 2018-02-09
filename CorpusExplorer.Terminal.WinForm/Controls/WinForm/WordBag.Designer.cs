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
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.cmb_layer = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.radAutoCompleteBox1 = new Telerik.WinControls.UI.RadAutoCompleteBox();
      this.btn_go = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radAutoCompleteBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_go)).BeginInit();
      this.SuspendLayout();
      // 
      // radCommandBar1
      // 
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.radCommandBar1.Size = new System.Drawing.Size(413, 69);
      this.radCommandBar1.TabIndex = 6;
      this.radCommandBar1.Text = "radCommandBar1";
      // 
      // commandBarRowElement1
      // 
      this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
      // 
      // commandBarStripElement1
      // 
      this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
      this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarLabel1,
            this.cmb_layer});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // commandBarLabel1
      // 
      this.commandBarLabel1.DisplayName = "commandBarLabel1";
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Text = "Layer:";
      // 
      // cmb_layer
      // 
      this.cmb_layer.DisplayName = "cmb_layer";
      this.cmb_layer.DropDownAnimationEnabled = true;
      this.cmb_layer.MaxDropDownItems = 0;
      this.cmb_layer.MinSize = new System.Drawing.Size(205, 22);
      this.cmb_layer.Name = "cmb_layer";
      this.cmb_layer.NullText = "Bitte auswählen...";
      this.cmb_layer.Text = "";
      this.cmb_layer.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cmb_layer_SelectedIndexChanged);
      // 
      // radAutoCompleteBox1
      // 
      this.radAutoCompleteBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radAutoCompleteBox1.Location = new System.Drawing.Point(0, 69);
      this.radAutoCompleteBox1.Name = "radAutoCompleteBox1";
      this.radAutoCompleteBox1.Size = new System.Drawing.Size(375, 13);
      this.radAutoCompleteBox1.TabIndex = 8;
      // 
      // btn_go
      // 
      this.btn_go.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_go.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_go.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.btn_go.Location = new System.Drawing.Point(375, 69);
      this.btn_go.Name = "btn_go";
      this.btn_go.Size = new System.Drawing.Size(38, 13);
      this.btn_go.TabIndex = 7;
      this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
      // 
      // WordBag
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.radAutoCompleteBox1);
      this.Controls.Add(this.btn_go);
      this.Controls.Add(this.radCommandBar1);
      this.MinimumSize = new System.Drawing.Size(413, 82);
      this.Name = "WordBag";
      this.Size = new System.Drawing.Size(413, 82);
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radAutoCompleteBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_go)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.ToolTip toolTip1;
    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
    private Telerik.WinControls.UI.CommandBarDropDownList cmb_layer;
    private Telerik.WinControls.UI.RadAutoCompleteBox radAutoCompleteBox1;
    private Telerik.WinControls.UI.RadButton btn_go;
  }
}
