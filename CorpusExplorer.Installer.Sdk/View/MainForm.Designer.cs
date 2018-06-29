namespace CorpusExplorer.Installer.Sdk.View
{
  using CorpusExplorer.Installer.Sdk.Properties;

  internal sealed partial class MainForm
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
      if (disposing && (this.components != null))
      {
        this.components.Dispose();
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.txt_licence = new System.Windows.Forms.TextBox();
      this.chk_accept = new System.Windows.Forms.CheckBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btn_install = new System.Windows.Forms.Button();
      this.btn_abort = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI Light", 18F);
      this.label1.Location = new System.Drawing.Point(92, 29);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(167, 32);
      this.label1.TabIndex = 1;
      this.label1.Text = "CorpusExplorer";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.label2.Location = new System.Drawing.Point(97, 59);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(199, 15);
      this.label2.TabIndex = 2;
      this.label2.Text = "Korpuslinguistik war nie so einfach...";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F);
      this.label3.Location = new System.Drawing.Point(17, 99);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(245, 20);
      this.label3.TabIndex = 3;
      this.label3.Text = "Hinweis zu den Lizenzbedingungen:";
      // 
      // txt_licence
      // 
      this.txt_licence.BackColor = System.Drawing.Color.White;
      this.txt_licence.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.txt_licence.Location = new System.Drawing.Point(21, 123);
      this.txt_licence.Multiline = true;
      this.txt_licence.Name = "txt_licence";
      this.txt_licence.ReadOnly = true;
      this.txt_licence.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txt_licence.Size = new System.Drawing.Size(318, 154);
      this.txt_licence.TabIndex = 4;
      this.txt_licence.Text = resources.GetString("txt_licence.Text");
      // 
      // chk_accept
      // 
      this.chk_accept.AutoSize = true;
      this.chk_accept.Location = new System.Drawing.Point(21, 283);
      this.chk_accept.Name = "chk_accept";
      this.chk_accept.Size = new System.Drawing.Size(298, 24);
      this.chk_accept.TabIndex = 5;
      this.chk_accept.Text = global::CorpusExplorer.Installer.Sdk.Properties.Resources.YesIAcceptTheLicence;
      this.chk_accept.UseVisualStyleBackColor = true;
      this.chk_accept.CheckedChanged += new System.EventHandler(this.chk_accept_CheckedChanged);
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.DimGray;
      this.panel1.ForeColor = System.Drawing.Color.DimGray;
      this.panel1.Location = new System.Drawing.Point(357, 24);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(3, 283);
      this.panel1.TabIndex = 6;
      // 
      // btn_install
      // 
      this.btn_install.Enabled = false;
      this.btn_install.Location = new System.Drawing.Point(413, 122);
      this.btn_install.Name = "btn_install";
      this.btn_install.Size = new System.Drawing.Size(153, 40);
      this.btn_install.TabIndex = 7;
      this.btn_install.Text = global::CorpusExplorer.Installer.Sdk.Properties.Resources.Install;
      this.btn_install.UseVisualStyleBackColor = true;
      this.btn_install.Click += new System.EventHandler(this.btn_install_Click);
      // 
      // btn_abort
      // 
      this.btn_abort.Location = new System.Drawing.Point(439, 168);
      this.btn_abort.Name = "btn_abort";
      this.btn_abort.Size = new System.Drawing.Size(100, 29);
      this.btn_abort.TabIndex = 8;
      this.btn_abort.Text = global::CorpusExplorer.Installer.Sdk.Properties.Resources.Abort;
      this.btn_abort.UseVisualStyleBackColor = true;
      this.btn_abort.Click += new System.EventHandler(this.btn_abort_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::CorpusExplorer.Installer.Sdk.Properties.Resources.shipment;
      this.pictureBox1.Location = new System.Drawing.Point(21, 24);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(64, 64);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // MainForm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(619, 324);
      this.Controls.Add(this.btn_abort);
      this.Controls.Add(this.btn_install);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.chk_accept);
      this.Controls.Add(this.txt_licence);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.pictureBox1);
      this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "CorpusExplorer - Installation";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txt_licence;
    private System.Windows.Forms.CheckBox chk_accept;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btn_install;
    private System.Windows.Forms.Button btn_abort;
  }
}