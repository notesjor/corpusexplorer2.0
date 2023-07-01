namespace CorpusExplorer.Terminal.WinForm.Forms.Publishing
{
  partial class DrmManagerReopen
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
      this.txt_token = new Telerik.WinControls.UI.RadTextBox();
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).BeginInit();
      this.clearPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_token)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // clearPanel1
      // 
      this.clearPanel1.Controls.Add(this.btn_abort);
      this.clearPanel1.Controls.Add(this.btn_ok);
      this.clearPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.clearPanel1.Location = new System.Drawing.Point(0, 97);
      this.clearPanel1.Name = "clearPanel1";
      this.clearPanel1.Padding = new System.Windows.Forms.Padding(10);
      this.clearPanel1.Size = new System.Drawing.Size(457, 42);
      this.clearPanel1.TabIndex = 5;
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
      this.btn_ok.Location = new System.Drawing.Point(337, 10);
      this.btn_ok.Name = "btn_ok";
      this.btn_ok.Size = new System.Drawing.Size(110, 22);
      this.btn_ok.TabIndex = 0;
      this.btn_ok.Text = "Anmelden";
      this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
      // 
      // headPanel1
      // 
      this.headPanel1.BackColor = System.Drawing.Color.White;
      this.headPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.headPanel1.Font = new System.Drawing.Font("Segoe UI", 12F);
      this.headPanel1.HeadPanelDescription = "Geben Sie bitte die Daten zur Korpusverwaltung ein:";
      this.headPanel1.HeadPanelImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.archive_download_48px;
      this.headPanel1.HeadPanelTitle = "Zugriff bestätigen";
      this.headPanel1.Location = new System.Drawing.Point(0, 0);
      this.headPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.headPanel1.Name = "headPanel1";
      this.headPanel1.Size = new System.Drawing.Size(457, 55);
      this.headPanel1.TabIndex = 6;
      // 
      // txt_token
      // 
      this.txt_token.Dock = System.Windows.Forms.DockStyle.Top;
      this.txt_token.Location = new System.Drawing.Point(0, 55);
      this.txt_token.Name = "txt_token";
      this.txt_token.NullText = "Sicherheits-Token";
      this.txt_token.Size = new System.Drawing.Size(457, 32);
      this.txt_token.TabIndex = 7;
      // 
      // DrmManagerReopen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(457, 139);
      this.Controls.Add(this.txt_token);
      this.Controls.Add(this.headPanel1);
      this.Controls.Add(this.clearPanel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DrmManagerReopen";
      this.Text = "Korpus-Verwaltung";
      ((System.ComponentModel.ISupportInitialize)(this.clearPanel1)).EndInit();
      this.clearPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txt_token)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Controls.WinForm.ClearPanel clearPanel1;
    private Telerik.WinControls.UI.RadButton btn_abort;
    private Telerik.WinControls.UI.RadButton btn_ok;
    private Tool4.DocPlusEditor.Controls.HeadPanel headPanel1;
    private Telerik.WinControls.UI.RadTextBox txt_token;
  }
}