namespace CorpusExplorer.Terminal.WinForm.View.Special.CecScripterControls
{
  partial class CecScripterInput
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
      Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
      this.drop_mode = new Telerik.WinControls.UI.RadDropDownList();
      this.drop_format = new Telerik.WinControls.UI.RadDropDownList();
      this.btn_file = new Telerik.WinControls.UI.RadButton();
      this.btn_options = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.drop_mode)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.drop_format)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_file)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_options)).BeginInit();
      this.SuspendLayout();
      // 
      // drop_mode
      // 
      radListDataItem1.Text = "import";
      radListDataItem2.Text = "annotate";
      this.drop_mode.Items.Add(radListDataItem1);
      this.drop_mode.Items.Add(radListDataItem2);
      this.drop_mode.Location = new System.Drawing.Point(4, 4);
      this.drop_mode.Name = "drop_mode";
      this.drop_mode.Size = new System.Drawing.Size(117, 32);
      this.drop_mode.TabIndex = 0;
      this.drop_mode.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.drop_mode_SelectedIndexChanged);
      // 
      // drop_format
      // 
      this.drop_format.Location = new System.Drawing.Point(128, 4);
      this.drop_format.Name = "drop_format";
      this.drop_format.Size = new System.Drawing.Size(333, 32);
      this.drop_format.TabIndex = 1;
      // 
      // btn_file
      // 
      this.btn_file.Location = new System.Drawing.Point(591, 4);
      this.btn_file.Name = "btn_file";
      this.btn_file.Size = new System.Drawing.Size(176, 32);
      this.btn_file.TabIndex = 2;
      this.btn_file.Text = "Datei auswählen";
      this.btn_file.Click += new System.EventHandler(this.btn_file_Click);
      // 
      // btn_options
      // 
      this.btn_options.Location = new System.Drawing.Point(467, 4);
      this.btn_options.Name = "btn_options";
      this.btn_options.Size = new System.Drawing.Size(118, 32);
      this.btn_options.TabIndex = 3;
      this.btn_options.Text = "Optionen";
      this.btn_options.Visible = false;
      this.btn_options.Click += new System.EventHandler(this.btn_options_Click);
      // 
      // CecScripterInput
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btn_options);
      this.Controls.Add(this.btn_file);
      this.Controls.Add(this.drop_format);
      this.Controls.Add(this.drop_mode);
      this.Name = "CecScripterInput";
      this.Load += new System.EventHandler(this.CecScripterInput_Load);
      ((System.ComponentModel.ISupportInitialize)(this.drop_mode)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.drop_format)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_file)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_options)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadDropDownList drop_mode;
    private Telerik.WinControls.UI.RadDropDownList drop_format;
    private Telerik.WinControls.UI.RadButton btn_file;
    private Telerik.WinControls.UI.RadButton btn_options;
  }
}
