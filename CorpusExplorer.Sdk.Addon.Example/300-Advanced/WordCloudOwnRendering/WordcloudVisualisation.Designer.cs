namespace CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering
{
  using CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering.Wordcloud;
  using CorpusExplorer.Sdk.Addon.Example.WordCloudOwnRendering.Wordcloud.Layout;

  partial class WordcloudVisualisation
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
      if (disposing && (this.components != null))
      {
        this.components.Dispose();
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
      this.cloudControl1 = new CloudControl();
      this.panel1 = new System.Windows.Forms.Panel();
      this.txt_query = new System.Windows.Forms.TextBox();
      this.btn_start = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // cloudControl1
      // 
      this.cloudControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.cloudControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cloudControl1.Items = null;
      this.cloudControl1.LayoutType = LayoutType.Spiral;
      this.cloudControl1.Location = new System.Drawing.Point(0, 36);
      this.cloudControl1.MaxFontSize = 68;
      this.cloudControl1.MinFontSize = 6;
      this.cloudControl1.Name = "cloudControl1";
      this.cloudControl1.Palette = new System.Drawing.Color[] {
        System.Drawing.Color.DarkRed,
        System.Drawing.Color.DarkBlue,
        System.Drawing.Color.DarkGreen,
        System.Drawing.Color.Navy,
        System.Drawing.Color.DarkCyan,
        System.Drawing.Color.DarkOrange,
        System.Drawing.Color.DarkGoldenrod,
        System.Drawing.Color.DarkKhaki,
        System.Drawing.Color.Blue,
        System.Drawing.Color.Red,
        System.Drawing.Color.Green};
      this.cloudControl1.Size = new System.Drawing.Size(600, 414);
      this.cloudControl1.TabIndex = 1;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.txt_query);
      this.panel1.Controls.Add(this.btn_start);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(600, 36);
      this.panel1.TabIndex = 3;
      // 
      // txt_query
      // 
      this.txt_query.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_query.Location = new System.Drawing.Point(0, 0);
      this.txt_query.Multiline = true;
      this.txt_query.Name = "txt_query";
      this.txt_query.Size = new System.Drawing.Size(525, 36);
      this.txt_query.TabIndex = 1;
      // 
      // btn_start
      // 
      this.btn_start.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_start.Location = new System.Drawing.Point(525, 0);
      this.btn_start.Name = "btn_start";
      this.btn_start.Size = new System.Drawing.Size(75, 36);
      this.btn_start.TabIndex = 0;
      this.btn_start.Text = "START";
      this.btn_start.UseVisualStyleBackColor = true;
      // 
      // WordcloudVisualisation
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.cloudControl1);
      this.Controls.Add(this.panel1);
      this.Name = "WordcloudVisualisation";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private CloudControl cloudControl1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TextBox txt_query;
    private System.Windows.Forms.Button btn_start;
  }
}
