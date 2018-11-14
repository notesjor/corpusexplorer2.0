namespace CorpusExplorer.Terminal.WinForm.Controls.WinForm
{
  partial class MapSwitch
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
      this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
      this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
      this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
      this.elementHost3 = new System.Windows.Forms.Integration.ElementHost();
      ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
      this.radPageView1.SuspendLayout();
      this.radPageViewPage1.SuspendLayout();
      this.radPageViewPage2.SuspendLayout();
      this.SuspendLayout();
      // 
      // radPageView1
      // 
      this.radPageView1.Controls.Add(this.radPageViewPage1);
      this.radPageView1.Controls.Add(this.radPageViewPage2);
      this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radPageView1.Location = new System.Drawing.Point(0, 0);
      this.radPageView1.Name = "radPageView1";
      this.radPageView1.SelectedPage = this.radPageViewPage1;
      this.radPageView1.Size = new System.Drawing.Size(681, 343);
      this.radPageView1.TabIndex = 0;
      // 
      // radPageViewPage1
      // 
      this.radPageViewPage1.Controls.Add(this.elementHost1);
      this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(141F, 29F);
      this.radPageViewPage1.Location = new System.Drawing.Point(5, 40);
      this.radPageViewPage1.Name = "radPageViewPage1";
      this.radPageViewPage1.Size = new System.Drawing.Size(671, 298);
      this.radPageViewPage1.Text = "radPageViewPage1";
      // 
      // elementHost1
      // 
      this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.elementHost1.Location = new System.Drawing.Point(0, 0);
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Size = new System.Drawing.Size(671, 298);
      this.elementHost1.TabIndex = 0;
      this.elementHost1.Text = "elementHost1";
      this.elementHost1.Child = null;
      // 
      // radPageViewPage2
      // 
      this.radPageViewPage2.Controls.Add(this.elementHost2);
      this.radPageViewPage2.ItemSize = new System.Drawing.SizeF(141F, 29F);
      this.radPageViewPage2.Location = new System.Drawing.Point(5, 40);
      this.radPageViewPage2.Name = "radPageViewPage2";
      this.radPageViewPage2.Size = new System.Drawing.Size(671, 343);
      this.radPageViewPage2.Text = "radPageViewPage2";
      // 
      // elementHost2
      // 
      this.elementHost2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.elementHost2.Location = new System.Drawing.Point(0, 0);
      this.elementHost2.Name = "elementHost2";
      this.elementHost2.Size = new System.Drawing.Size(671, 343);
      this.elementHost2.TabIndex = 0;
      this.elementHost2.Text = "elementHost2";
      this.elementHost2.Child = null;
      // 
      // elementHost3
      // 
      this.elementHost3.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.elementHost3.Location = new System.Drawing.Point(0, 343);
      this.elementHost3.Name = "elementHost3";
      this.elementHost3.Size = new System.Drawing.Size(681, 45);
      this.elementHost3.TabIndex = 1;
      this.elementHost3.Text = "elementHost3";
      this.elementHost3.Child = null;
      // 
      // MapSwitch
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.Controls.Add(this.radPageView1);
      this.Controls.Add(this.elementHost3);
      this.Name = "MapSwitch";
      ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
      this.radPageView1.ResumeLayout(false);
      this.radPageViewPage1.ResumeLayout(false);
      this.radPageViewPage2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadPageView radPageView1;
    private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
    private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
    private System.Windows.Forms.Integration.ElementHost elementHost1;
    private System.Windows.Forms.Integration.ElementHost elementHost2;
    private System.Windows.Forms.Integration.ElementHost elementHost3;
  }
}
