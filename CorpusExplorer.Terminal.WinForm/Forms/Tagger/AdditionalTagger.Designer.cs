namespace CorpusExplorer.Terminal.WinForm.Forms.Tagger
{
  partial class AdditionalTagger
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdditionalTagger));
      this.ihdPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.combo_tagger = new Telerik.WinControls.UI.RadDropDownList();
      this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
      this.lbl_destination = new System.Windows.Forms.Label();
      this.btn_destination = new Telerik.WinControls.UI.RadButton();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.combo_tagger)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
      this.radGroupBox3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.btn_destination)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Location = new System.Drawing.Point(0, 296);
      this.radPanel1.Size = new System.Drawing.Size(583, 38);
      // 
      // ihdPanel1
      // 
      this.ihdPanel1.BackColor = System.Drawing.Color.White;
      this.ihdPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihdPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihdPanel1.IHDDeescribtion = "Wählen Sie einen Tagger und konfigurieren Sie ihn für die automatische Annotation" +
    "";
      this.ihdPanel1.IHDHeader = "Tagger-Optionen";
      this.ihdPanel1.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.tag_green1;
      this.ihdPanel1.Location = new System.Drawing.Point(0, 0);
      this.ihdPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.ihdPanel1.Name = "ihdPanel1";
      this.ihdPanel1.Size = new System.Drawing.Size(583, 55);
      this.ihdPanel1.TabIndex = 3;
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.combo_tagger);
      this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox1.HeaderText = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.VerfügbareTaggerKonfigurationen;
      this.radGroupBox1.Location = new System.Drawing.Point(0, 55);
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Padding = new System.Windows.Forms.Padding(7, 25, 7, 7);
      this.radGroupBox1.Size = new System.Drawing.Size(583, 65);
      this.radGroupBox1.TabIndex = 4;
      this.radGroupBox1.Text = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.VerfügbareTaggerKonfigurationen;
      // 
      // combo_tagger
      // 
      this.combo_tagger.Dock = System.Windows.Forms.DockStyle.Fill;
      this.combo_tagger.Location = new System.Drawing.Point(7, 25);
      this.combo_tagger.Name = "combo_tagger";
      this.combo_tagger.Size = new System.Drawing.Size(569, 33);
      this.combo_tagger.TabIndex = 0;
      // 
      // radGroupBox3
      // 
      this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox3.Controls.Add(this.lbl_destination);
      this.radGroupBox3.Controls.Add(this.btn_destination);
      this.radGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox3.HeaderText = "Model:";
      this.radGroupBox3.Location = new System.Drawing.Point(0, 120);
      this.radGroupBox3.Name = "radGroupBox3";
      this.radGroupBox3.Padding = new System.Windows.Forms.Padding(7, 25, 7, 7);
      this.radGroupBox3.Size = new System.Drawing.Size(583, 62);
      this.radGroupBox3.TabIndex = 5;
      this.radGroupBox3.Text = "Model:";
      // 
      // lbl_destination
      // 
      this.lbl_destination.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbl_destination.Location = new System.Drawing.Point(7, 25);
      this.lbl_destination.Name = "lbl_destination";
      this.lbl_destination.Size = new System.Drawing.Size(459, 30);
      this.lbl_destination.TabIndex = 1;
      this.lbl_destination.Text = "(Bitte wählen Sie eine Datei aus)";
      this.lbl_destination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btn_destination
      // 
      this.btn_destination.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_destination.Location = new System.Drawing.Point(466, 25);
      this.btn_destination.Name = "btn_destination";
      this.btn_destination.Size = new System.Drawing.Size(110, 30);
      this.btn_destination.TabIndex = 0;
      this.btn_destination.Text = "Auswählen";
      this.btn_destination.Click += new System.EventHandler(this.btn_destination_Click);
      // 
      // radLabel1
      // 
      this.radLabel1.AutoSize = false;
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.radLabel1.Location = new System.Drawing.Point(0, 182);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(583, 114);
      this.radLabel1.TabIndex = 6;
      this.radLabel1.Text = resources.GetString("radLabel1.Text");
      this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
      // 
      // AdditionalTagger
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(583, 334);
      this.Controls.Add(this.radLabel1);
      this.Controls.Add(this.radGroupBox3);
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this.ihdPanel1);
      this.DisplayAbort = true;
      this.Name = "AdditionalTagger";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "Zusätzliche Annotation";
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.ihdPanel1, 0);
      this.Controls.SetChildIndex(this.radGroupBox1, 0);
      this.Controls.SetChildIndex(this.radGroupBox3, 0);
      this.Controls.SetChildIndex(this.radLabel1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.combo_tagger)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
      this.radGroupBox3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.btn_destination)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.WinForm.IHDPanel ihdPanel1;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadDropDownList combo_tagger;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
    private System.Windows.Forms.Label lbl_destination;
    private Telerik.WinControls.UI.RadButton btn_destination;
    private Telerik.WinControls.UI.RadLabel radLabel1;
  }
}