namespace CorpusExplorer.Terminal.WinForm.View.Special
{
  partial class Html5DevLab
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Html5DevLab));
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_load = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_save = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator3 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_refresh = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_print = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_export_html = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_export_pdf = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_export_image = new Telerik.WinControls.UI.CommandBarButton();
      this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
      this.btn_help = new Telerik.WinControls.UI.CommandBarButton();
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.radSplitContainer2 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel3 = new Telerik.WinControls.UI.SplitPanel();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.editor_input = new Telerik.WinControls.UI.RadSyntaxEditor();
      this.splitPanel4 = new Telerik.WinControls.UI.SplitPanel();
      this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
      this.editor_output = new Telerik.WinControls.UI.RadSyntaxEditor();
      this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
      this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
      this.webHtml5LaboratoryVisualisation1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.WebBrowserControl();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
      this.radSplitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
      this.splitPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer2)).BeginInit();
      this.radSplitContainer2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel3)).BeginInit();
      this.splitPanel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.editor_input)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel4)).BeginInit();
      this.splitPanel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
      this.radGroupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.editor_output)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
      this.splitPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
      this.radGroupBox3.SuspendLayout();
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
            this.btn_load,
            this.btn_save,
            this.commandBarSeparator3,
            this.btn_refresh,
            this.commandBarSeparator1,
            this.btn_print,
            this.btn_export_html,
            this.btn_export_pdf,
            this.btn_export_image,
            this.commandBarSeparator2,
            this.btn_help});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_load
      // 
      this.btn_load.AutoToolTip = true;
      resources.ApplyResources(this.btn_load, "btn_load");
      this.btn_load.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.folder_open;
      this.btn_load.Name = "btn_load";
      this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
      // 
      // btn_save
      // 
      this.btn_save.AutoToolTip = true;
      resources.ApplyResources(this.btn_save, "btn_save");
      this.btn_save.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save;
      this.btn_save.Name = "btn_save";
      this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
      // 
      // commandBarSeparator3
      // 
      resources.ApplyResources(this.commandBarSeparator3, "commandBarSeparator3");
      this.commandBarSeparator3.Name = "commandBarSeparator3";
      this.commandBarSeparator3.VisibleInOverflowMenu = false;
      // 
      // btn_refresh
      // 
      this.btn_refresh.AutoToolTip = true;
      resources.ApplyResources(this.btn_refresh, "btn_refresh");
      this.btn_refresh.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.refresh;
      this.btn_refresh.Name = "btn_refresh";
      this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
      // 
      // commandBarSeparator1
      // 
      resources.ApplyResources(this.commandBarSeparator1, "commandBarSeparator1");
      this.commandBarSeparator1.Name = "commandBarSeparator1";
      this.commandBarSeparator1.VisibleInOverflowMenu = false;
      // 
      // btn_print
      // 
      this.btn_print.AutoToolTip = true;
      resources.ApplyResources(this.btn_print, "btn_print");
      this.btn_print.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.print;
      this.btn_print.Name = "btn_print";
      this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
      // 
      // btn_export_html
      // 
      this.btn_export_html.AutoToolTip = true;
      resources.ApplyResources(this.btn_export_html, "btn_export_html");
      this.btn_export_html.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_text;
      this.btn_export_html.Name = "btn_export_html";
      // 
      // btn_export_pdf
      // 
      this.btn_export_pdf.AutoToolTip = true;
      resources.ApplyResources(this.btn_export_pdf, "btn_export_pdf");
      this.btn_export_pdf.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.export_pdf;
      this.btn_export_pdf.Name = "btn_export_pdf";
      this.btn_export_pdf.Click += new System.EventHandler(this.btn_export_pdf_Click);
      // 
      // btn_export_image
      // 
      this.btn_export_image.AutoToolTip = true;
      resources.ApplyResources(this.btn_export_image, "btn_export_image");
      this.btn_export_image.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.image_save;
      this.btn_export_image.Name = "btn_export_image";
      this.btn_export_image.Click += new System.EventHandler(this.btn_export_image_Click);
      // 
      // commandBarSeparator2
      // 
      resources.ApplyResources(this.commandBarSeparator2, "commandBarSeparator2");
      this.commandBarSeparator2.Name = "commandBarSeparator2";
      this.commandBarSeparator2.VisibleInOverflowMenu = false;
      // 
      // btn_help
      // 
      this.btn_help.AutoToolTip = true;
      resources.ApplyResources(this.btn_help, "btn_help");
      this.btn_help.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.health;
      this.btn_help.Name = "btn_help";
      this.btn_help.Click += new System.EventHandler(this.btn_help_Click);
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      this.radSplitContainer1.Controls.Add(this.splitPanel2);
      resources.ApplyResources(this.radSplitContainer1, "radSplitContainer1");
      this.radSplitContainer1.Name = "radSplitContainer1";
      // 
      // 
      // 
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer1.TabStop = false;
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.radSplitContainer2);
      resources.ApplyResources(this.splitPanel1, "splitPanel1");
      this.splitPanel1.Name = "splitPanel1";
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.1623711F, 0F);
      this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(-126, 0);
      this.splitPanel1.TabStop = false;
      // 
      // radSplitContainer2
      // 
      this.radSplitContainer2.Controls.Add(this.splitPanel3);
      this.radSplitContainer2.Controls.Add(this.splitPanel4);
      resources.ApplyResources(this.radSplitContainer2, "radSplitContainer2");
      this.radSplitContainer2.Name = "radSplitContainer2";
      // 
      // 
      // 
      this.radSplitContainer2.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer2.TabStop = false;
      // 
      // splitPanel3
      // 
      this.splitPanel3.Controls.Add(this.radGroupBox1);
      resources.ApplyResources(this.splitPanel3, "splitPanel3");
      this.splitPanel3.Name = "splitPanel3";
      // 
      // 
      // 
      this.splitPanel3.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel3.TabStop = false;
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.editor_input);
      resources.ApplyResources(this.radGroupBox1, "radGroupBox1");
      this.radGroupBox1.Name = "radGroupBox1";
      // 
      // editor_input
      // 
      resources.ApplyResources(this.editor_input, "editor_input");
      this.editor_input.Name = "editor_input";
      // 
      // splitPanel4
      // 
      this.splitPanel4.Controls.Add(this.radGroupBox2);
      resources.ApplyResources(this.splitPanel4, "splitPanel4");
      this.splitPanel4.Name = "splitPanel4";
      // 
      // 
      // 
      this.splitPanel4.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel4.TabStop = false;
      // 
      // radGroupBox2
      // 
      this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add(this.editor_output);
      resources.ApplyResources(this.radGroupBox2, "radGroupBox2");
      this.radGroupBox2.Name = "radGroupBox2";
      // 
      // editor_output
      // 
      resources.ApplyResources(this.editor_output, "editor_output");
      this.editor_output.Name = "editor_output";
      // 
      // splitPanel2
      // 
      this.splitPanel2.Controls.Add(this.radGroupBox3);
      resources.ApplyResources(this.splitPanel2, "splitPanel2");
      this.splitPanel2.Name = "splitPanel2";
      // 
      // 
      // 
      this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.1623712F, 0F);
      this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(126, 0);
      this.splitPanel2.TabStop = false;
      // 
      // radGroupBox3
      // 
      this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox3.Controls.Add(this.webHtml5LaboratoryVisualisation1);
      resources.ApplyResources(this.radGroupBox3, "radGroupBox3");
      this.radGroupBox3.Name = "radGroupBox3";
      // 
      // webHtml5LaboratoryVisualisation1
      // 
      this.webHtml5LaboratoryVisualisation1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.webHtml5LaboratoryVisualisation1, "webHtml5LaboratoryVisualisation1");
      this.webHtml5LaboratoryVisualisation1.Name = "webHtml5LaboratoryVisualisation1";
      // 
      // timer1
      // 
      this.timer1.Interval = 5000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // Html5DevLab
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radSplitContainer1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "Html5DevLab";
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
      this.radSplitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
      this.splitPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer2)).EndInit();
      this.radSplitContainer2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel3)).EndInit();
      this.splitPanel3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.editor_input)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel4)).EndInit();
      this.splitPanel4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
      this.radGroupBox2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.editor_output)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
      this.splitPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
      this.radGroupBox3.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarButton btn_load;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
    private Telerik.WinControls.UI.CommandBarButton btn_print;
    private Telerik.WinControls.UI.CommandBarButton btn_export_html;
    private Telerik.WinControls.UI.CommandBarButton btn_export_pdf;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
    private Telerik.WinControls.UI.CommandBarButton btn_help;
    private Telerik.WinControls.UI.CommandBarButton btn_refresh;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
    private Telerik.WinControls.UI.SplitPanel splitPanel1;
    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer2;
    private Telerik.WinControls.UI.SplitPanel splitPanel3;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.SplitPanel splitPanel4;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
    private Telerik.WinControls.UI.SplitPanel splitPanel2;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
    private Controls.WinForm.WebBrowserControl webHtml5LaboratoryVisualisation1;
    private Telerik.WinControls.UI.CommandBarButton btn_save;
    private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator3;
    private Telerik.WinControls.UI.CommandBarButton btn_export_image;
    private System.Windows.Forms.Timer timer1;
        private Telerik.WinControls.UI.RadSyntaxEditor editor_input;
        private Telerik.WinControls.UI.RadSyntaxEditor editor_output;
    }
}
