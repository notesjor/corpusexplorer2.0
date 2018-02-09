using CorpusExplorer.Terminal.WinForm.Properties;
namespace CorpusExplorer.Terminal.WinForm.View.Special
{
  partial class ChatView
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
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
      this.combo_utteranche = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
      this.combo_speaker = new Telerik.WinControls.UI.CommandBarDropDownList();
      this.btn_go = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.commandBarButton1 = new Telerik.WinControls.UI.CommandBarButton();
      this.radListView1 = new Telerik.WinControls.UI.RadListView();
      this.txt_filter = new Telerik.WinControls.UI.RadTextBox();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radListView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_filter)).BeginInit();
      this.SuspendLayout();
      // 
      // radCommandBar1
      // 
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.radCommandBar1.Size = new System.Drawing.Size(780, 69);
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
            this.commandBarLabel1,
            this.combo_utteranche,
            this.commandBarLabel2,
            this.combo_speaker,
            this.btn_go,
            this.commandBarSeparator1,
            this.commandBarButton1});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // commandBarLabel1
      // 
      this.commandBarLabel1.DisplayName = "commandBarLabel1";
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.ÄußerungsID;
      // 
      // combo_utteranche
      // 
      this.combo_utteranche.DisplayName = "commandBarDropDownList1";
      this.combo_utteranche.DropDownAnimationEnabled = true;
      this.combo_utteranche.MaxDropDownItems = 0;
      this.combo_utteranche.MinSize = new System.Drawing.Size(200, 22);
      this.combo_utteranche.Name = "combo_utteranche";
      this.combo_utteranche.Text = "";
      // 
      // commandBarLabel2
      // 
      this.commandBarLabel2.DisplayName = "commandBarLabel2";
      this.commandBarLabel2.Name = "commandBarLabel2";
      this.commandBarLabel2.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.SprecherID;
      // 
      // combo_speaker
      // 
      this.combo_speaker.DisplayName = "commandBarDropDownList2";
      this.combo_speaker.DropDownAnimationEnabled = true;
      this.combo_speaker.MaxDropDownItems = 0;
      this.combo_speaker.MinSize = new System.Drawing.Size(200, 22);
      this.combo_speaker.Name = "combo_speaker";
      this.combo_speaker.Text = "";
      // 
      // btn_go
      // 
      this.btn_go.DisplayName = "commandBarButton1";
      this.btn_go.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_go.Name = "btn_go";
      this.btn_go.Text = "commandBarButton1";
      this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
      // 
      // commandBarSeparator1
      // 
      this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // commandBarButton1
      // 
      this.commandBarButton1.DisplayName = "commandBarButton1";
      this.commandBarButton1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.camera_add;
      this.commandBarButton1.Name = "commandBarButton1";
      this.commandBarButton1.Text = "Schnappschuss erstellen";
      this.commandBarButton1.Click += new System.EventHandler(this.radButton1_Click);
      // 
      // radListView1
      // 
      this.radListView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radListView1.GroupItemSize = new System.Drawing.Size(200, 40);
      this.radListView1.ItemSize = new System.Drawing.Size(200, 40);
      this.radListView1.Location = new System.Drawing.Point(0, 101);
      this.radListView1.Name = "radListView1";
      this.radListView1.ShowCheckBoxes = true;
      this.radListView1.Size = new System.Drawing.Size(780, 299);
      this.radListView1.TabIndex = 1;
      this.radListView1.Text = "radListView1";
      // 
      // txt_filter
      // 
      this.txt_filter.Dock = System.Windows.Forms.DockStyle.Top;
      this.txt_filter.Location = new System.Drawing.Point(0, 69);
      this.txt_filter.Name = "txt_filter";
      this.txt_filter.Size = new System.Drawing.Size(780, 32);
      this.txt_filter.TabIndex = 2;
      this.txt_filter.TextChanged += new System.EventHandler(this.txt_filter_TextChanged);
      // 
      // ChatView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.radListView1);
      this.Controls.Add(this.txt_filter);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "ChatView";
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radListView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_filter)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
    private Telerik.WinControls.UI.CommandBarDropDownList combo_utteranche;
    private Telerik.WinControls.UI.CommandBarLabel commandBarLabel2;
    private Telerik.WinControls.UI.CommandBarDropDownList combo_speaker;
    private Telerik.WinControls.UI.CommandBarButton btn_go;
    private Telerik.WinControls.UI.RadListView radListView1;
    private Telerik.WinControls.UI.RadTextBox txt_filter;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarButton commandBarButton1;
  }
}
