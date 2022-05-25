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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatView));
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
      resources.ApplyResources(this.radCommandBar1, "radCommandBar1");
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      // 
      // commandBarRowElement1
      // 
      this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement1.Name = "commandBarRowElement1";
      this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
      // 
      // commandBarStripElement1
      // 
      resources.ApplyResources(this.commandBarStripElement1, "commandBarStripElement1");
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
      resources.ApplyResources(this.commandBarLabel1, "commandBarLabel1");
      this.commandBarLabel1.Name = "commandBarLabel1";
      this.commandBarLabel1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.ÄußerungsID;
      // 
      // combo_utteranche
      // 
      resources.ApplyResources(this.combo_utteranche, "combo_utteranche");
      this.combo_utteranche.DropDownAnimationEnabled = true;
      this.combo_utteranche.MaxDropDownItems = 0;
      this.combo_utteranche.MinSize = new System.Drawing.Size(200, 22);
      this.combo_utteranche.Name = "combo_utteranche";
      // 
      // commandBarLabel2
      // 
      resources.ApplyResources(this.commandBarLabel2, "commandBarLabel2");
      this.commandBarLabel2.Name = "commandBarLabel2";
      this.commandBarLabel2.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.SprecherID;
      // 
      // combo_speaker
      // 
      resources.ApplyResources(this.combo_speaker, "combo_speaker");
      this.combo_speaker.DropDownAnimationEnabled = true;
      this.combo_speaker.MaxDropDownItems = 0;
      this.combo_speaker.MinSize = new System.Drawing.Size(200, 22);
      this.combo_speaker.Name = "combo_speaker";
      // 
      // btn_go
      // 
      this.btn_go.AutoToolTip = true;
      resources.ApplyResources(this.btn_go, "btn_go");
      this.btn_go.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_go.Name = "btn_go";
      this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
      // 
      // commandBarSeparator1
      // 
      resources.ApplyResources(this.commandBarSeparator1, "commandBarSeparator1");
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // commandBarButton1
      // 
      this.commandBarButton1.AutoToolTip = true;
      resources.ApplyResources(this.commandBarButton1, "commandBarButton1");
      this.commandBarButton1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.camera_add;
      this.commandBarButton1.Name = "commandBarButton1";
      this.commandBarButton1.Click += new System.EventHandler(this.radButton1_Click);
      // 
      // radListView1
      // 
      resources.ApplyResources(this.radListView1, "radListView1");
      this.radListView1.GroupItemSize = new System.Drawing.Size(200, 40);
      this.radListView1.HorizontalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
      this.radListView1.ItemSize = new System.Drawing.Size(200, 40);
      this.radListView1.Name = "radListView1";
      this.radListView1.ShowCheckBoxes = true;
      this.radListView1.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
      // 
      // txt_filter
      // 
      resources.ApplyResources(this.txt_filter, "txt_filter");
      this.txt_filter.Name = "txt_filter";
      this.txt_filter.TextChanged += new System.EventHandler(this.txt_filter_TextChanged);
      // 
      // ChatView
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
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
