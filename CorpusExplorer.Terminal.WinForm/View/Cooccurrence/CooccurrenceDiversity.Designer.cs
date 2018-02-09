using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.View.Cooccurrence
{
  partial class CooccurrenceDiversity
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
      this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.txt_queryA = new Telerik.WinControls.UI.CommandBarTextBox();
      this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
      this.txt_queryB = new Telerik.WinControls.UI.CommandBarTextBox();
      this.commandBarButton1 = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_snapshot_create = new Telerik.WinControls.UI.CommandBarButton();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      this.SuspendLayout();
      // 
      // radGridView1
      // 
      this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radGridView1.Location = new System.Drawing.Point(0, 69);
      // 
      // 
      // 
      this.radGridView1.MasterTemplate.AllowAddNewRow = false;
      this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
      this.radGridView1.MasterTemplate.AllowDeleteRow = false;
      this.radGridView1.MasterTemplate.AllowEditRow = false;
      this.radGridView1.MasterTemplate.MultiSelect = true;
      this.radGridView1.Name = "radGridView1";
      this.radGridView1.Size = new System.Drawing.Size(780, 331);
      this.radGridView1.TabIndex = 4;
      this.radGridView1.Text = "radGridView1";
      this.radGridView1.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.radGridView1_RowFormatting);
      // 
      // radCommandBar1
      // 
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.radCommandBar1.Size = new System.Drawing.Size(780, 69);
      this.radCommandBar1.TabIndex = 5;
      this.radCommandBar1.Text = Resources.Html_GreenValues2;
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
            this.txt_queryA,
            this.commandBarLabel2,
            this.txt_queryB,
            this.commandBarButton1,
            this.commandBarSeparator1,
            this.btn_snapshot_create});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // commandBarLabel1
      // 
      this.commandBarLabel1.AccessibleDescription = Resources.Html_GreeValues;
      this.commandBarLabel1.AccessibleName = Resources.Html_GreeValues;
      this.commandBarLabel1.DisplayName = "commandBarLabel1";
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Text = Resources.Html_GreeValues;
      // 
      // txt_queryA
      // 
      this.txt_queryA.DisplayName = "commandBarTextBox1";
      this.txt_queryA.MinSize = new System.Drawing.Size(200, 0);
      this.txt_queryA.Name = "txt_queryA";
      this.txt_queryA.Text = "";
      // 
      // commandBarLabel2
      // 
      this.commandBarLabel2.AccessibleDescription = Resources.Html_RedValues;
      this.commandBarLabel2.AccessibleName = Resources.Html_RedValues;
      this.commandBarLabel2.DisplayName = "commandBarLabel2";
      this.commandBarLabel2.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
      this.commandBarLabel2.Name = "commandBarLabel2";
      this.commandBarLabel2.Text = Resources.Html_RedValues;
      // 
      // txt_queryB
      // 
      this.txt_queryB.DisplayName = "commandBarTextBox2";
      this.txt_queryB.MinSize = new System.Drawing.Size(200, 0);
      this.txt_queryB.Name = "txt_queryB";
      this.txt_queryB.Text = "";
      // 
      // commandBarButton1
      // 
      this.commandBarButton1.AccessibleDescription = "commandBarButton1";
      this.commandBarButton1.AccessibleName = "commandBarButton1";
      this.commandBarButton1.DisplayName = "commandBarButton1";
      this.commandBarButton1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.commandBarButton1.Name = "commandBarButton1";
      this.commandBarButton1.Text = Resources.AuswertungStarten;
      this.commandBarButton1.ToolTipText = Resources.AuswertungStarten;
      this.commandBarButton1.Click += new System.EventHandler(this.btn_startB_Click);
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.AccessibleDescription = "commandBarSeparator1";
      this.commandBarSeparator1.AccessibleName = "commandBarSeparator1";
      this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // btn_snapshot_create
      // 
      this.btn_snapshot_create.AccessibleDescription = "commandBarButton2";
      this.btn_snapshot_create.AccessibleName = "commandBarButton2";
      this.btn_snapshot_create.DisplayName = "commandBarButton2";
      this.btn_snapshot_create.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.camera_add;
      this.btn_snapshot_create.Name = "btn_snapshot_create";
      this.btn_snapshot_create.Text = Resources.SchnappschussErstellen;
      this.btn_snapshot_create.ToolTipText = Resources.SchnappschussErstellen;
      this.btn_snapshot_create.Click += new System.EventHandler(this.btn_snapshot_create_Click);
      // 
      // CooccurrenceDiversity
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.radGridView1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "CooccurrenceDiversity";
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadGridView radGridView1;
    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
    private Telerik.WinControls.UI.CommandBarTextBox txt_queryA;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel2;
    private Telerik.WinControls.UI.CommandBarTextBox txt_queryB;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton1;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarButton btn_snapshot_create;
  }
}
