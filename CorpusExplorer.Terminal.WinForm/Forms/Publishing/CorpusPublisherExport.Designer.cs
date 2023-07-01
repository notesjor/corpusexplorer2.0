namespace CorpusExplorer.Terminal.WinForm.Forms.Publishing
{
  partial class CorpusPublisherExport
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
      this.clearPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.ClearPanel();
      this.btn_abort = new Telerik.WinControls.UI.RadButton();
      this.btn_ok = new Telerik.WinControls.UI.RadButton();
      this.headPanel1 = new CorpusExplorer.Tool4.DocPlusEditor.Controls.HeadPanel();
      this.radCheckBox1 = new Telerik.WinControls.UI.RadCheckBox();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.list_formats = new Telerik.WinControls.UI.RadCheckedListBox();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.list_formats)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
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
      this.clearPanel1.TabIndex = 6;
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
      this.btn_ok.Text = "Jetzt veröffentlichen";
      this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
      // 
      // headPanel1
      // 
      this.headPanel1.BackColor = System.Drawing.Color.White;
      this.headPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.headPanel1.Font = new System.Drawing.Font("Segoe UI", 12F);
      this.headPanel1.HeadPanelDescription = "Wählen Sie aus, in welche Formate ihr Korpusmaterial exportiert werden soll:";
      this.headPanel1.HeadPanelImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.archive_download_48px;
      this.headPanel1.HeadPanelTitle = "Formate für Veröffentlichung";
      this.headPanel1.Location = new System.Drawing.Point(0, 0);
      this.headPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.headPanel1.Name = "headPanel1";
      this.headPanel1.Size = new System.Drawing.Size(800, 55);
      this.headPanel1.TabIndex = 7;
      // 
      // radCheckBox1
      // 
      this.radCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
      this.radCheckBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCheckBox1.Enabled = false;
      this.radCheckBox1.Location = new System.Drawing.Point(0, 86);
      this.radCheckBox1.Name = "radCheckBox1";
      this.radCheckBox1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
      this.radCheckBox1.ReadOnly = true;
      this.radCheckBox1.Size = new System.Drawing.Size(336, 23);
      this.radCheckBox1.TabIndex = 8;
      this.radCheckBox1.Text = "CorpusExplorer CEC6 (technisch notwendig)";
      this.radCheckBox1.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
      // 
      // radLabel1
      // 
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.radLabel1.Location = new System.Drawing.Point(0, 55);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
      this.radLabel1.Size = new System.Drawing.Size(145, 31);
      this.radLabel1.TabIndex = 9;
      this.radLabel1.Text = "Obligatorischer Export:";
      // 
      // radLabel2
      // 
      this.radLabel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.radLabel2.Location = new System.Drawing.Point(0, 109);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
      this.radLabel2.Size = new System.Drawing.Size(165, 31);
      this.radLabel2.TabIndex = 10;
      this.radLabel2.Text = "Fakultative Exportformate:";
      // 
      // list_formats
      // 
      this.list_formats.Dock = System.Windows.Forms.DockStyle.Fill;
      this.list_formats.GroupItemSize = new System.Drawing.Size(200, 40);
      this.list_formats.ItemSize = new System.Drawing.Size(200, 40);
      this.list_formats.Location = new System.Drawing.Point(0, 140);
      this.list_formats.Name = "list_formats";
      this.list_formats.Size = new System.Drawing.Size(800, 268);
      this.list_formats.TabIndex = 11;
      // 
      // CorpusPublisherExport
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.list_formats);
      this.Controls.Add(this.radLabel2);
      this.Controls.Add(this.radCheckBox1);
      this.Controls.Add(this.radLabel1);
      this.Controls.Add(this.headPanel1);
      this.Controls.Add(this.clearPanel1);
      this.Name = "CorpusPublisherExport";
      this.Text = "CorpusPublisherExport";
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.list_formats)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Controls.WinForm.ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadButton btn_abort;
    private Telerik.WinControls.UI.RadButton btn_ok;
    private Tool4.DocPlusEditor.Controls.HeadPanel headPanel1;
    private Telerik.WinControls.UI.RadCheckBox radCheckBox1;
    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private Telerik.WinControls.UI.RadCheckedListBox list_formats;
  }
}