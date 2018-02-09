using CorpusExplorer.Terminal.WinForm.Properties;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;

namespace CorpusExplorer.Terminal.WinForm.View.Fulltext
{
  partial class FulltextKwicTree
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FulltextKwicTree));
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.webHtml5Visualisation1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.Webbrowser.WebHtml5Visualisation();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.txt_query = new Telerik.WinControls.UI.RadAutoCompleteBox();
      this.radDropDownButton1 = new Telerik.WinControls.UI.RadDropDownButton();
      this.btn_start_normal = new Telerik.WinControls.UI.RadMenuItem();
      this.btn_start_cooccurrence = new Telerik.WinControls.UI.RadMenuItem();
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      this.wpfDiagram1 = new CorpusExplorer.Terminal.WinForm.Controls.Wpf.Diagram.WpfDiagram();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
      this.radSplitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
      this.splitPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_query)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radDropDownButton1)).BeginInit();
      this.SuspendLayout();
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
      this.radSplitContainer1.Name = "radSplitContainer1";
      this.radSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // 
      // 
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer1.Size = new System.Drawing.Size(780, 400);
      this.radSplitContainer1.TabIndex = 0;
      this.radSplitContainer1.TabStop = false;
      this.radSplitContainer1.Text = "radSplitContainer1";
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.elementHost1);
      this.splitPanel1.Controls.Add(this.webHtml5Visualisation1);
      this.splitPanel1.Controls.Add(this.clearPanel1);
      this.splitPanel1.Location = new System.Drawing.Point(0, 0);
      this.splitPanel1.Name = "splitPanel1";
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel1.Size = new System.Drawing.Size(780, 400);
      this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, -0.3131313F);
      this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, -117);
      this.splitPanel1.TabIndex = 0;
      this.splitPanel1.TabStop = false;
      this.splitPanel1.Text = "splitPanel1";
      // 
      // webHtml5Visualisation1
      // 
      this.webHtml5Visualisation1.BackColor = System.Drawing.Color.White;
      this.webHtml5Visualisation1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.webHtml5Visualisation1.Location = new System.Drawing.Point(0, 35);
      this.webHtml5Visualisation1.MainpageUrl = null;
      this.webHtml5Visualisation1.Name = "webHtml5Visualisation1";
      this.webHtml5Visualisation1.Size = new System.Drawing.Size(780, 365);
      this.webHtml5Visualisation1.TabIndex = 3;
      this.webHtml5Visualisation1.TemplateVars = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("webHtml5Visualisation1.TemplateVars")));
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.txt_query);
      this.clearPanel1.Controls.Add(this.radDropDownButton1);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.clearPanel1.Location = new System.Drawing.Point(0, 0);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
      this.clearPanel1.Size = new System.Drawing.Size(780, 35);
      this.clearPanel1.TabIndex = 0;
      // 
      // txt_query
      // 
      this.txt_query.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_query.Location = new System.Drawing.Point(0, 3);
      this.txt_query.Name = "txt_query";
      this.txt_query.NullText = "Suchbegriff/Phrase hier eingeben...";
      this.txt_query.Size = new System.Drawing.Size(730, 32);
      this.txt_query.TabIndex = 2;
      // 
      // radDropDownButton1
      // 
      this.radDropDownButton1.Dock = System.Windows.Forms.DockStyle.Right;
      this.radDropDownButton1.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.radDropDownButton1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btn_start_normal,
            this.btn_start_cooccurrence});
      this.radDropDownButton1.Location = new System.Drawing.Point(730, 3);
      this.radDropDownButton1.Name = "radDropDownButton1";
      this.radDropDownButton1.Size = new System.Drawing.Size(50, 32);
      this.radDropDownButton1.TabIndex = 0;
      // 
      // btn_start_normal
      // 
      this.btn_start_normal.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_start_normal.Name = "btn_start_normal";
      this.btn_start_normal.Text = "Erzeuge KWIT (KeyWord-In-Tree)";
      this.btn_start_normal.Click += new System.EventHandler(this.btn_start_normal_Click);
      // 
      // btn_start_cooccurrence
      // 
      this.btn_start_cooccurrence.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_start_cooccurrence.Name = "btn_start_cooccurrence";
      this.btn_start_cooccurrence.Text = "Erzeuge KWIT (+ Kokkurrenz)";
      this.btn_start_cooccurrence.Click += new System.EventHandler(this.btn_start_cooccurrence_Click);
      // 
      // elementHost1
      // 
      this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.elementHost1.Location = new System.Drawing.Point(0, 35);
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Size = new System.Drawing.Size(780, 365);
      this.elementHost1.TabIndex = 4;
      this.elementHost1.Text = "elementHost1";
      this.elementHost1.Child = this.wpfDiagram1;
      // 
      // FulltextKwicTree2
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radSplitContainer1);
      this.Name = "FulltextKwicTree";
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
      this.radSplitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
      this.splitPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.txt_query)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radDropDownButton1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
    private Telerik.WinControls.UI.SplitPanel splitPanel1;
    private Telerik.WinControls.UI.RadAutoCompleteBox txt_query;
    private ClearPanel clearPanel1;
    private Controls.WinForm.Webbrowser.WebHtml5Visualisation webHtml5Visualisation1;
    private Telerik.WinControls.UI.RadDropDownButton radDropDownButton1;
    private Telerik.WinControls.UI.RadMenuItem btn_start_normal;
    private Telerik.WinControls.UI.RadMenuItem btn_start_cooccurrence;
    private System.Windows.Forms.Integration.ElementHost elementHost1;
    private Controls.Wpf.Diagram.WpfDiagram wpfDiagram1;
  }
}
