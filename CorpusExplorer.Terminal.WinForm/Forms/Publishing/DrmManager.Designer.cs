namespace CorpusExplorer.Terminal.WinForm.Forms.Publishing
{
  partial class DrmManager
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
      Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
      Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrmManager));
      this.headPanel1 = new CorpusExplorer.Tool4.DocPlusEditor.Controls.HeadPanel();
      this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
      this.txt_token = new Telerik.WinControls.UI.RadTextBox();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.btn_abort = new Telerik.WinControls.UI.RadButton();
      this.btn_ok = new Telerik.WinControls.UI.RadButton();
      this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
      this.grid_userPasswordCombinations = new Telerik.WinControls.UI.RadGridView();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
      this.radGroupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_token)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
      this.radGroupBox3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grid_userPasswordCombinations)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grid_userPasswordCombinations.MasterTemplate)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // headPanel1
      // 
      this.headPanel1.BackColor = System.Drawing.Color.White;
      this.headPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.headPanel1.Font = new System.Drawing.Font("Segoe UI", 12F);
      this.headPanel1.HeadPanelDescription = "Verwalten Sie Nutzer*innen, die exklusiven Zugriff auf das Korpus haben.";
      this.headPanel1.HeadPanelImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.archive_download_48px;
      this.headPanel1.HeadPanelTitle = "Zugriff verwalten";
      this.headPanel1.Location = new System.Drawing.Point(0, 0);
      this.headPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.headPanel1.Name = "headPanel1";
      this.headPanel1.Size = new System.Drawing.Size(800, 55);
      this.headPanel1.TabIndex = 1;
      // 
      // radGroupBox2
      // 
      this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add(this.txt_token);
      this.radGroupBox2.Controls.Add(this.radLabel2);
      this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox2.HeaderText = "2. Exklusiver Security-Token";
      this.radGroupBox2.Location = new System.Drawing.Point(0, 55);
      this.radGroupBox2.Name = "radGroupBox2";
      this.radGroupBox2.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox2.Size = new System.Drawing.Size(800, 87);
      this.radGroupBox2.TabIndex = 3;
      this.radGroupBox2.Text = "2. Exklusiver Security-Token";
      // 
      // txt_token
      // 
      this.txt_token.Dock = System.Windows.Forms.DockStyle.Top;
      this.txt_token.Location = new System.Drawing.Point(5, 48);
      this.txt_token.Name = "txt_token";
      this.txt_token.ReadOnly = true;
      this.txt_token.Size = new System.Drawing.Size(790, 32);
      this.txt_token.TabIndex = 1;
      this.txt_token.Text = "abc";
      this.txt_token.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // radLabel2
      // 
      this.radLabel2.AutoSize = false;
      this.radLabel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel2.Location = new System.Drawing.Point(5, 25);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Size = new System.Drawing.Size(790, 23);
      this.radLabel2.TabIndex = 0;
      this.radLabel2.Text = "<html>Geben Sie dieses Token nicht weiter - <u>sichern Sie das Token</u>, um spät" +
    "er weitere Nutzer hinzufügen zu können.</html>";
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.btn_abort);
      this.clearPanel1.Controls.Add(this.btn_ok);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.clearPanel1.Location = new System.Drawing.Point(0, 408);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Padding = new System.Windows.Forms.Padding(10);
      this.clearPanel1.Size = new System.Drawing.Size(800, 42);
      this.clearPanel1.TabIndex = 4;
      // 
      // btn_abort
      // 
      this.btn_abort.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_abort.Location = new System.Drawing.Point(10, 10);
      this.btn_abort.Name = "btn_abort";
      this.btn_abort.Size = new System.Drawing.Size(110, 22);
      this.btn_abort.TabIndex = 1;
      this.btn_abort.Text = "Abbrechen";
      this.btn_abort.Click += new System.EventHandler(this.btn_abort_Click);
      // 
      // btn_ok
      // 
      this.btn_ok.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_ok.Location = new System.Drawing.Point(597, 10);
      this.btn_ok.Name = "btn_ok";
      this.btn_ok.Size = new System.Drawing.Size(193, 22);
      this.btn_ok.TabIndex = 0;
      this.btn_ok.Text = "Zugangsdaten speichern";
      this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
      // 
      // radGroupBox3
      // 
      this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox3.Controls.Add(this.grid_userPasswordCombinations);
      this.radGroupBox3.Controls.Add(this.radLabel1);
      this.radGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radGroupBox3.HeaderText = "3. Nutzer verwalten";
      this.radGroupBox3.Location = new System.Drawing.Point(0, 142);
      this.radGroupBox3.Name = "radGroupBox3";
      this.radGroupBox3.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox3.Size = new System.Drawing.Size(800, 266);
      this.radGroupBox3.TabIndex = 5;
      this.radGroupBox3.Text = "3. Nutzer verwalten";
      // 
      // grid_userPasswordCombinations
      // 
      this.grid_userPasswordCombinations.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grid_userPasswordCombinations.EnableGestures = false;
      this.grid_userPasswordCombinations.Location = new System.Drawing.Point(5, 25);
      // 
      // 
      // 
      this.grid_userPasswordCombinations.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
      this.grid_userPasswordCombinations.MasterTemplate.AllowDragToGroup = false;
      this.grid_userPasswordCombinations.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
      gridViewTextBoxColumn1.HeaderText = "E-Mail";
      gridViewTextBoxColumn1.Name = "Name";
      gridViewTextBoxColumn1.Width = 385;
      gridViewTextBoxColumn2.HeaderText = "Passwort";
      gridViewTextBoxColumn2.Name = "Password";
      gridViewTextBoxColumn2.Width = 385;
      this.grid_userPasswordCombinations.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
      this.grid_userPasswordCombinations.MasterTemplate.EnableGrouping = false;
      this.grid_userPasswordCombinations.MasterTemplate.ViewDefinition = tableViewDefinition1;
      this.grid_userPasswordCombinations.Name = "grid_userPasswordCombinations";
      this.grid_userPasswordCombinations.Size = new System.Drawing.Size(790, 185);
      this.grid_userPasswordCombinations.TabIndex = 0;
      // 
      // radLabel1
      // 
      this.radLabel1.AutoSize = false;
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel1.Location = new System.Drawing.Point(5, 210);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(790, 51);
      this.radLabel1.TabIndex = 1;
      this.radLabel1.Text = resources.GetString("radLabel1.Text");
      // 
      // DrmManager
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.radGroupBox3);
      this.Controls.Add(this.clearPanel1);
      this.Controls.Add(this.radGroupBox2);
      this.Controls.Add(this.headPanel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DrmManager";
      this.Text = "CorpusExplorer - Digital Rights Management";
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
      this.radGroupBox2.ResumeLayout(false);
      this.radGroupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_token)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
      this.radGroupBox3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.grid_userPasswordCombinations.MasterTemplate)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grid_userPasswordCombinations)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Tool4.DocPlusEditor.Controls.HeadPanel headPanel1;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private Telerik.WinControls.UI.RadTextBox txt_token;
    private Controls.WinForm.ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadButton btn_ok;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
    private Telerik.WinControls.UI.RadGridView grid_userPasswordCombinations;
    private Telerik.WinControls.UI.RadButton btn_abort;
    private Telerik.WinControls.UI.RadLabel radLabel1;
  }
}