namespace CorpusExplorer.Terminal.WinForm.View.Sentiment
{
  partial class SentimentGrid
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
      Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
      Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
      Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
      Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarButton1 = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarButton2 = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarButton4 = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarButton3 = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
      this.SuspendLayout();
      // 
      // radCommandBar1
      // 
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.radCommandBar1.Size = new System.Drawing.Size(780, 44);
      this.radCommandBar1.TabIndex = 0;
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
            this.commandBarButton1,
            this.commandBarButton2,
            this.commandBarButton4,
            this.commandBarButton3,
            this.commandBarSeparator1,
            this.commandBarLabel1});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // commandBarButton1
      // 
      this.commandBarButton1.DisplayName = "commandBarButton1";
      this.commandBarButton1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.document;
      this.commandBarButton1.Name = "commandBarButton1";
      this.commandBarButton1.Text = "Neu";
      // 
      // commandBarButton2
      // 
      this.commandBarButton2.DisplayName = "commandBarButton2";
      this.commandBarButton2.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.folder_open;
      this.commandBarButton2.Name = "commandBarButton2";
      this.commandBarButton2.Text = "Laden";
      // 
      // commandBarButton4
      // 
      this.commandBarButton4.DisplayName = "commandBarButton4";
      this.commandBarButton4.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.folder_action_open;
      this.commandBarButton4.Name = "commandBarButton4";
      this.commandBarButton4.Text = "Importieren";
      // 
      // commandBarButton3
      // 
      this.commandBarButton3.DisplayName = "commandBarButton3";
      this.commandBarButton3.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save;
      this.commandBarButton3.Name = "commandBarButton3";
      this.commandBarButton3.Text = "Speichern";
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // commandBarLabel1
      // 
      this.commandBarLabel1.DisplayName = "commandBarLabel1";
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Text = "Das Model ist: LEER";
      // 
      // radGridView1
      // 
      this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radGridView1.Location = new System.Drawing.Point(0, 44);
      // 
      // 
      // 
      this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
      gridViewTextBoxColumn1.HeaderText = "Quelle";
      gridViewTextBoxColumn1.Name = "col_source";
      gridViewTextBoxColumn1.Width = 303;
      gridViewTextBoxColumn2.HeaderText = "Text";
      gridViewTextBoxColumn2.Name = "col_label";
      gridViewTextBoxColumn2.Width = 217;
      gridViewDecimalColumn1.HeaderText = "Wert";
      gridViewDecimalColumn1.Name = "col_value";
      gridViewDecimalColumn1.Width = 241;
      this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewDecimalColumn1});
      this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
      this.radGridView1.Name = "radGridView1";
      this.radGridView1.Size = new System.Drawing.Size(780, 356);
      this.radGridView1.TabIndex = 1;
      this.radGridView1.Text = "radGridView1";
      // 
      // SentimentGrid
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.radGridView1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "SentimentGrid";
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton1;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton2;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton3;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
    private Telerik.WinControls.UI.RadGridView radGridView1;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton4;
  }
}
