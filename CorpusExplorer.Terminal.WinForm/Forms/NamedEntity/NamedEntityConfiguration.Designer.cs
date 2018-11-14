namespace CorpusExplorer.Terminal.WinForm.Forms.NamedEntity
{
  partial class NamedEntityConfiguration
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
      Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
      Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
      Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
      this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
      this.btn_open = new Telerik.WinControls.UI.RadButton();
      this.btn_save = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      this.radPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_open)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_save)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Controls.Add(this.btn_save);
      this.radPanel1.Controls.Add(this.btn_open);
      this.radPanel1.Location = new System.Drawing.Point(0, 335);
      this.radPanel1.Size = new System.Drawing.Size(640, 38);
      this.radPanel1.Controls.SetChildIndex(this.btn_open, 0);
      this.radPanel1.Controls.SetChildIndex(this.btn_save, 0);
      // 
      // radGridView1
      // 
      this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radGridView1.Location = new System.Drawing.Point(0, 0);
      // 
      // 
      // 
      this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
      gridViewTextBoxColumn1.HeaderText = "Entität";
      gridViewTextBoxColumn1.Name = "entity";
      gridViewTextBoxColumn1.Width = 123;
      gridViewTextBoxColumn2.HeaderText = "Vorname";
      gridViewTextBoxColumn2.Name = "name";
      gridViewTextBoxColumn2.Width = 165;
      gridViewTextBoxColumn3.HeaderText = "Nachname";
      gridViewTextBoxColumn3.Name = "surname";
      gridViewTextBoxColumn3.Width = 192;
      gridViewTextBoxColumn4.HeaderText = "Kontext";
      gridViewTextBoxColumn4.Name = "context";
      gridViewTextBoxColumn4.Width = 142;
      this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
      this.radGridView1.MasterTemplate.EnableFiltering = true;
      this.radGridView1.MasterTemplate.EnableGrouping = false;
      this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
      this.radGridView1.Name = "radGridView1";
      this.radGridView1.Size = new System.Drawing.Size(640, 335);
      this.radGridView1.TabIndex = 1;
      // 
      // btn_open
      // 
      this.btn_open.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_open.Location = new System.Drawing.Point(3, 3);
      this.btn_open.Name = "btn_open";
      this.btn_open.Size = new System.Drawing.Size(110, 32);
      this.btn_open.TabIndex = 3;
      this.btn_open.Text = "Importieren";
      this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
      // 
      // btn_save
      // 
      this.btn_save.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_save.Location = new System.Drawing.Point(113, 3);
      this.btn_save.Name = "btn_save";
      this.btn_save.Size = new System.Drawing.Size(110, 32);
      this.btn_save.TabIndex = 4;
      this.btn_save.Text = "Exportieren";
      this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
      // 
      // NamedEntityConfiguration
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(640, 373);
      this.Controls.Add(this.radGridView1);
      this.DisplayAbort = true;
      this.Name = "NamedEntityConfiguration";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "Karten-Zuordnung";
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.radGridView1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      this.radPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_open)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_save)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadGridView radGridView1;
    private Telerik.WinControls.UI.RadButton btn_save;
    private Telerik.WinControls.UI.RadButton btn_open;
  }
}