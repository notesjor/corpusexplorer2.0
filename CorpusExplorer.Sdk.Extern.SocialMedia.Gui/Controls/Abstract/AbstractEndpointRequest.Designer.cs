namespace CorpusExplorer.Sdk.Extern.SocialMedia.Gui.Controls.Abstract
{
  partial class AbstractEndpointRequest
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
      this.btn_abort = new Telerik.WinControls.UI.RadButton();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.btn_start = new Telerik.WinControls.UI.RadButton();
      this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
      this.progress = new Telerik.WinControls.UI.RadProgressBar();
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_start)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.progress)).BeginInit();
      this.SuspendLayout();
      // 
      // btn_abort
      // 
      this.btn_abort.Dock = System.Windows.Forms.DockStyle.Left;
      this.btn_abort.Location = new System.Drawing.Point(0, 0);
      this.btn_abort.Name = "btn_abort";
      this.btn_abort.Size = new System.Drawing.Size(200, 32);
      this.btn_abort.TabIndex = 0;
      this.btn_abort.Text = "Erhebung abbrechen";
      this.btn_abort.Visible = false;
      this.btn_abort.Click += new System.EventHandler(this.btn_abort_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.panel2);
      this.panel1.Controls.Add(this.panel3);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 456);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(830, 64);
      this.panel1.TabIndex = 1;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.progress);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Padding = new System.Windows.Forms.Padding(3);
      this.panel2.Size = new System.Drawing.Size(830, 32);
      this.panel2.TabIndex = 1;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.btn_abort);
      this.panel3.Controls.Add(this.btn_start);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel3.Location = new System.Drawing.Point(0, 32);
      this.panel3.MaximumSize = new System.Drawing.Size(0, 32);
      this.panel3.MinimumSize = new System.Drawing.Size(200, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(830, 32);
      this.panel3.TabIndex = 3;
      // 
      // btn_start
      // 
      this.btn_start.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_start.Location = new System.Drawing.Point(630, 0);
      this.btn_start.Name = "btn_start";
      this.btn_start.Size = new System.Drawing.Size(200, 32);
      this.btn_start.TabIndex = 2;
      this.btn_start.Text = "Erhebung starten";
      this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
      // 
      // backgroundWorker
      // 
      this.backgroundWorker.WorkerSupportsCancellation = true;
      this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
      this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
      // 
      // progress
      // 
      this.progress.Dock = System.Windows.Forms.DockStyle.Fill;
      this.progress.Location = new System.Drawing.Point(3, 3);
      this.progress.Name = "progress";
      this.progress.Size = new System.Drawing.Size(824, 26);
      this.progress.TabIndex = 2;
      this.progress.Value1 = 10;
      this.progress.Value2 = 50;
      // 
      // AbstractEndpointRequest
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panel1);
      this.Name = "AbstractEndpointRequest";
      ((System.ComponentModel.ISupportInitialize)(this.btn_abort)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_start)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.progress)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadButton btn_abort;
    private System.Windows.Forms.Panel panel1;
    private Telerik.WinControls.UI.RadButton btn_start;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel3;
    private System.ComponentModel.BackgroundWorker backgroundWorker;
    private Telerik.WinControls.UI.RadProgressBar progress;
  }
}
