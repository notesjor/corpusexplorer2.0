namespace CorpusExplorer.Installer.Sdk.View
{
  partial class ErrorReport
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorReport));
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.button2 = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.btn_abort = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.linkLabel1 = new System.Windows.Forms.LinkLabel();
      this.treeView1 = new System.Windows.Forms.TreeView();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.panel2);
      this.panel1.Controls.Add(this.button1);
      this.panel1.Controls.Add(this.btn_abort);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 420);
      this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(668, 132);
      this.panel1.TabIndex = 0;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.button2);
      this.panel2.Controls.Add(this.label2);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 79);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(668, 53);
      this.panel2.TabIndex = 11;
      // 
      // button2
      // 
      this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.button2.Location = new System.Drawing.Point(0, 24);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(668, 29);
      this.button2.TabIndex = 11;
      this.button2.Text = "Klicken Sie hier, um den CorpusExplorer neu zu konfigurieren";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // label2
      // 
      this.label2.AutoEllipsis = true;
      this.label2.Dock = System.Windows.Forms.DockStyle.Top;
      this.label2.Location = new System.Drawing.Point(0, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(668, 28);
      this.label2.TabIndex = 2;
      this.label2.Text = "NUR FÜR NOTFÄLLE: Sollte der CorpusExplorer nicht (mehr) starten, dann:";
      this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(3, 3);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(226, 29);
      this.button1.TabIndex = 10;
      this.button1.Text = "Fehlerbericht speichern";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // btn_abort
      // 
      this.btn_abort.Location = new System.Drawing.Point(440, 6);
      this.btn_abort.Name = "btn_abort";
      this.btn_abort.Size = new System.Drawing.Size(225, 29);
      this.btn_abort.TabIndex = 9;
      this.btn_abort.Text = "Dieses Fenster schließen";
      this.btn_abort.UseVisualStyleBackColor = true;
      this.btn_abort.Click += new System.EventHandler(this.btn_abort_Click);
      // 
      // label1
      // 
      this.label1.AutoEllipsis = true;
      this.label1.Dock = System.Windows.Forms.DockStyle.Top;
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(668, 64);
      this.label1.TabIndex = 1;
      this.label1.Text = resources.GetString("label1.Text");
      // 
      // linkLabel1
      // 
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.linkLabel1.Location = new System.Drawing.Point(0, 64);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new System.Drawing.Size(193, 20);
      this.linkLabel1.TabIndex = 2;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "support@corpusexplorer.de";
      this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      // 
      // treeView1
      // 
      this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.treeView1.Location = new System.Drawing.Point(0, 84);
      this.treeView1.Name = "treeView1";
      this.treeView1.Size = new System.Drawing.Size(668, 336);
      this.treeView1.TabIndex = 3;
      // 
      // ErrorReport
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(668, 552);
      this.Controls.Add(this.treeView1);
      this.Controls.Add(this.linkLabel1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.panel1);
      this.Font = new System.Drawing.Font("Segoe UI", 11.25F);
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "ErrorReport";
      this.Text = "CorpusExplorer - Fehlerbericht!";
      this.Load += new System.EventHandler(this.ErrorReport_Load);
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btn_abort;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.LinkLabel linkLabel1;
    private System.Windows.Forms.TreeView treeView1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Label label2;
  }
}