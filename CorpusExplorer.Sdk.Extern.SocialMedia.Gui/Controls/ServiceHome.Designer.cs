namespace CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls
{
  partial class ServiceHome
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceHome));
      this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
      this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
      this.radPropertyGrid1 = new Telerik.WinControls.UI.RadPropertyGrid();
      this.btn_validateAndSave = new Telerik.WinControls.UI.RadButton();
      this.ihdPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
      this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
      this.panel_availableOptions = new System.Windows.Forms.Panel();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.txt_path = new Telerik.WinControls.UI.RadTextBox();
      this.btn_outputPath = new Telerik.WinControls.UI.RadButton();
      this.panel_endpoints = new System.Windows.Forms.FlowLayoutPanel();
      this.ihdPanel2 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
      this.radSplitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
      this.splitPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radPropertyGrid1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_validateAndSave)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
      this.splitPanel2.SuspendLayout();
      this.panel_availableOptions.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_path)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_outputPath)).BeginInit();
      this.SuspendLayout();
      // 
      // radSplitContainer1
      // 
      this.radSplitContainer1.Controls.Add(this.splitPanel1);
      this.radSplitContainer1.Controls.Add(this.splitPanel2);
      this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
      this.radSplitContainer1.Name = "radSplitContainer1";
      // 
      // 
      // 
      this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.radSplitContainer1.Size = new System.Drawing.Size(1107, 603);
      this.radSplitContainer1.TabIndex = 0;
      this.radSplitContainer1.TabStop = false;
      // 
      // splitPanel1
      // 
      this.splitPanel1.Controls.Add(this.radPropertyGrid1);
      this.splitPanel1.Controls.Add(this.btn_validateAndSave);
      this.splitPanel1.Controls.Add(this.ihdPanel1);
      this.splitPanel1.Location = new System.Drawing.Point(0, 0);
      this.splitPanel1.Name = "splitPanel1";
      // 
      // 
      // 
      this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel1.Size = new System.Drawing.Size(552, 603);
      this.splitPanel1.TabIndex = 0;
      this.splitPanel1.TabStop = false;
      this.splitPanel1.Text = "splitPanel1";
      // 
      // radPropertyGrid1
      // 
      this.radPropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radPropertyGrid1.EnableGrouping = false;
      this.radPropertyGrid1.HelpBarHeight = 98.46154F;
      this.radPropertyGrid1.HelpVisible = false;
      this.radPropertyGrid1.ItemHeight = 49;
      this.radPropertyGrid1.ItemIndent = 53;
      this.radPropertyGrid1.Location = new System.Drawing.Point(0, 135);
      this.radPropertyGrid1.Margin = new System.Windows.Forms.Padding(4);
      this.radPropertyGrid1.Name = "radPropertyGrid1";
      this.radPropertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
      this.radPropertyGrid1.Size = new System.Drawing.Size(552, 429);
      this.radPropertyGrid1.SortOrder = System.Windows.Forms.SortOrder.Ascending;
      this.radPropertyGrid1.TabIndex = 6;
      this.radPropertyGrid1.ToolbarVisible = true;
      // 
      // btn_validateAndSave
      // 
      this.btn_validateAndSave.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.btn_validateAndSave.Image = global::CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Properties.Resources.save_ok;
      this.btn_validateAndSave.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
      this.btn_validateAndSave.Location = new System.Drawing.Point(0, 564);
      this.btn_validateAndSave.Margin = new System.Windows.Forms.Padding(4);
      this.btn_validateAndSave.Name = "btn_validateAndSave";
      this.btn_validateAndSave.Size = new System.Drawing.Size(552, 39);
      this.btn_validateAndSave.TabIndex = 5;
      this.btn_validateAndSave.Text = "API-Zugang überprüfen und speichern";
      this.btn_validateAndSave.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      this.btn_validateAndSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btn_validateAndSave.Click += new System.EventHandler(this.btn_validateAndSave_Click);
      // 
      // ihdPanel1
      // 
      this.ihdPanel1.BackColor = System.Drawing.Color.White;
      this.ihdPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihdPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihdPanel1.IHDDeescribtion = resources.GetString("ihdPanel1.IHDDeescribtion");
      this.ihdPanel1.IHDHeader = "Bei {SERVICENAME} anmelden";
      this.ihdPanel1.IHDImage = global::CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Properties.Resources.key1;
      this.ihdPanel1.Location = new System.Drawing.Point(0, 0);
      this.ihdPanel1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.ihdPanel1.Name = "ihdPanel1";
      this.ihdPanel1.Size = new System.Drawing.Size(552, 135);
      this.ihdPanel1.TabIndex = 0;
      // 
      // splitPanel2
      // 
      this.splitPanel2.Controls.Add(this.panel_availableOptions);
      this.splitPanel2.Location = new System.Drawing.Point(556, 0);
      this.splitPanel2.Name = "splitPanel2";
      // 
      // 
      // 
      this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(0, 0);
      this.splitPanel2.Size = new System.Drawing.Size(551, 603);
      this.splitPanel2.TabIndex = 1;
      this.splitPanel2.TabStop = false;
      this.splitPanel2.Text = "splitPanel2";
      // 
      // panel_availableOptions
      // 
      this.panel_availableOptions.Controls.Add(this.radGroupBox1);
      this.panel_availableOptions.Controls.Add(this.panel_endpoints);
      this.panel_availableOptions.Controls.Add(this.ihdPanel2);
      this.panel_availableOptions.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel_availableOptions.Location = new System.Drawing.Point(0, 0);
      this.panel_availableOptions.Margin = new System.Windows.Forms.Padding(4);
      this.panel_availableOptions.Name = "panel_availableOptions";
      this.panel_availableOptions.Size = new System.Drawing.Size(551, 603);
      this.panel_availableOptions.TabIndex = 1;
      this.panel_availableOptions.Visible = false;
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.txt_path);
      this.radGroupBox1.Controls.Add(this.btn_outputPath);
      this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.radGroupBox1.HeaderText = "Ausgabeverzeichnis";
      this.radGroupBox1.Location = new System.Drawing.Point(0, 527);
      this.radGroupBox1.Margin = new System.Windows.Forms.Padding(4);
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Padding = new System.Windows.Forms.Padding(7, 31, 7, 6);
      this.radGroupBox1.Size = new System.Drawing.Size(551, 76);
      this.radGroupBox1.TabIndex = 7;
      this.radGroupBox1.Text = "Ausgabeverzeichnis";
      // 
      // txt_path
      // 
      this.txt_path.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_path.Location = new System.Drawing.Point(7, 31);
      this.txt_path.Margin = new System.Windows.Forms.Padding(4);
      this.txt_path.Name = "txt_path";
      this.txt_path.Size = new System.Drawing.Size(390, 39);
      this.txt_path.TabIndex = 1;
      this.txt_path.TextChanged += new System.EventHandler(this.txt_path_TextChanged);
      // 
      // btn_outputPath
      // 
      this.btn_outputPath.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_outputPath.Image = global::CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Properties.Resources.folder_open;
      this.btn_outputPath.Location = new System.Drawing.Point(397, 31);
      this.btn_outputPath.Margin = new System.Windows.Forms.Padding(4);
      this.btn_outputPath.Name = "btn_outputPath";
      this.btn_outputPath.Size = new System.Drawing.Size(147, 39);
      this.btn_outputPath.TabIndex = 0;
      this.btn_outputPath.Text = "Ändern";
      this.btn_outputPath.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btn_outputPath.Click += new System.EventHandler(this.btn_outputPath_Click);
      // 
      // panel_endpoints
      // 
      this.panel_endpoints.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel_endpoints.Location = new System.Drawing.Point(0, 135);
      this.panel_endpoints.Margin = new System.Windows.Forms.Padding(4);
      this.panel_endpoints.Name = "panel_endpoints";
      this.panel_endpoints.Size = new System.Drawing.Size(551, 318);
      this.panel_endpoints.TabIndex = 6;
      // 
      // ihdPanel2
      // 
      this.ihdPanel2.BackColor = System.Drawing.Color.White;
      this.ihdPanel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihdPanel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihdPanel2.IHDDeescribtion = resources.GetString("ihdPanel2.IHDDeescribtion");
      this.ihdPanel2.IHDHeader = "Verfügbare API-Abfragen";
      this.ihdPanel2.IHDImage = global::CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Properties.Resources.cloud_design;
      this.ihdPanel2.Location = new System.Drawing.Point(0, 0);
      this.ihdPanel2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.ihdPanel2.Name = "ihdPanel2";
      this.ihdPanel2.Size = new System.Drawing.Size(551, 135);
      this.ihdPanel2.TabIndex = 0;
      // 
      // ServiceHome
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radSplitContainer1);
      this.Margin = new System.Windows.Forms.Padding(5);
      this.Name = "ServiceHome";
      this.Size = new System.Drawing.Size(1107, 603);
      ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
      this.radSplitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
      this.splitPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radPropertyGrid1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_validateAndSave)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
      this.splitPanel2.ResumeLayout(false);
      this.panel_availableOptions.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_path)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_outputPath)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
    private Telerik.WinControls.UI.SplitPanel splitPanel1;
    private CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel ihdPanel1;
    private Telerik.WinControls.UI.SplitPanel splitPanel2;
    private CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel ihdPanel2;
    private System.Windows.Forms.Panel panel_availableOptions;
    private Telerik.WinControls.UI.RadButton btn_validateAndSave;
    private Telerik.WinControls.UI.RadPropertyGrid radPropertyGrid1;
    private System.Windows.Forms.FlowLayoutPanel panel_endpoints;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadTextBox txt_path;
    private Telerik.WinControls.UI.RadButton btn_outputPath;
  }
}
