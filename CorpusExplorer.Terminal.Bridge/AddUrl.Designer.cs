namespace CorpusExplorer.Terminal.Bridge
{
  partial class AddUrl
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
      this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
      this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
      this.btn_ok = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      this.radPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Controls.Add(this.btn_ok);
      this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.radPanel1.Location = new System.Drawing.Point(0, 291);
      this.radPanel1.Name = "radPanel1";
      this.radPanel1.Padding = new System.Windows.Forms.Padding(10);
      this.radPanel1.Size = new System.Drawing.Size(462, 53);
      this.radPanel1.TabIndex = 1;
      // 
      // radTextBox1
      // 
      this.radTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radTextBox1.Location = new System.Drawing.Point(0, 0);
      this.radTextBox1.Multiline = true;
      this.radTextBox1.Name = "radTextBox1";
      this.radTextBox1.NullText = "Korpus-URLs hier eintragen (pro Zeile ein Korpus)";
      // 
      // 
      // 
      this.radTextBox1.RootElement.StretchVertically = true;
      this.radTextBox1.Size = new System.Drawing.Size(462, 291);
      this.radTextBox1.TabIndex = 2;
      // 
      // btn_ok
      // 
      this.btn_ok.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_ok.Image = global::CorpusExplorer.Terminal.Bridge.Properties.Resources.button_ok;
      this.btn_ok.Location = new System.Drawing.Point(304, 10);
      this.btn_ok.Name = "btn_ok";
      this.btn_ok.Size = new System.Drawing.Size(148, 33);
      this.btn_ok.TabIndex = 0;
      this.btn_ok.Text = "Bestätigen";
      this.btn_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
      // 
      // AddUrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(462, 344);
      this.Controls.Add(this.radTextBox1);
      this.Controls.Add(this.radPanel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AddUrl";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Online-Korpora nutzen...";
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      this.radPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private Telerik.WinControls.UI.RadPanel radPanel1;
    private Telerik.WinControls.UI.RadTextBox radTextBox1;
    private Telerik.WinControls.UI.RadButton btn_ok;
  }
}