namespace CorpusExplorer.Terminal.WinForm.View.Special
{
  partial class CecScripter
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
      this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
      this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
      this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
      this.btn_menu_new = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_menu_load = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_menu_save = new Telerik.WinControls.UI.CommandBarButton();
      this.btn_menu_saveas = new Telerik.WinControls.UI.CommandBarButton();
      this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
      this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
      this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
      this.radListView1 = new Telerik.WinControls.UI.RadListView();
      this.radPageViewPage3 = new Telerik.WinControls.UI.RadPageViewPage();
      this.radPageViewPage4 = new Telerik.WinControls.UI.RadPageViewPage();
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
      this.radPageView1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radListView1)).BeginInit();
      this.SuspendLayout();
      // 
      // radCommandBar1
      // 
      this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
      this.radCommandBar1.Name = "radCommandBar1";
      this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
      this.radCommandBar1.Size = new System.Drawing.Size(780, 44);
      this.radCommandBar1.TabIndex = 0;
      this.radCommandBar1.Text = "radCommandBar1";
      // 
      // commandBarRowElement1
      // 
      this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
      this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
      // 
      // commandBarStripElement1
      // 
      this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
      this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btn_menu_new,
            this.btn_menu_load,
            this.btn_menu_save,
            this.btn_menu_saveas});
      this.commandBarStripElement1.Name = "commandBarStripElement1";
      // 
      // btn_menu_new
      // 
      this.btn_menu_new.DisplayName = "commandBarButton1";
      this.btn_menu_new.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.document;
      this.btn_menu_new.Name = "btn_menu_new";
      this.btn_menu_new.Text = "Neues Skript erstellen";
      // 
      // btn_menu_load
      // 
      this.btn_menu_load.DisplayName = "commandBarButton2";
      this.btn_menu_load.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.folder_open;
      this.btn_menu_load.Name = "btn_menu_load";
      this.btn_menu_load.Text = "Skript laden";
      // 
      // btn_menu_save
      // 
      this.btn_menu_save.DisplayName = "commandBarButton3";
      this.btn_menu_save.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save;
      this.btn_menu_save.Name = "btn_menu_save";
      this.btn_menu_save.Text = "Skript speichern";
      // 
      // btn_menu_saveas
      // 
      this.btn_menu_saveas.DisplayName = "commandBarButton4";
      this.btn_menu_saveas.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.save_all;
      this.btn_menu_saveas.Name = "btn_menu_saveas";
      this.btn_menu_saveas.Text = "Skript speichern unter";
      // 
      // radPageView1
      // 
      this.radPageView1.Controls.Add(this.radPageViewPage1);
      this.radPageView1.Controls.Add(this.radPageViewPage2);
      this.radPageView1.Controls.Add(this.radPageViewPage3);
      this.radPageView1.Controls.Add(this.radPageViewPage4);
      this.radPageView1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.radPageView1.Location = new System.Drawing.Point(0, 200);
      this.radPageView1.Name = "radPageView1";
      this.radPageView1.SelectedPage = this.radPageViewPage1;
      this.radPageView1.Size = new System.Drawing.Size(780, 200);
      this.radPageView1.TabIndex = 1;
      this.radPageView1.Text = "radPageView1";
      // 
      // radPageViewPage1
      // 
      this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(116F, 29F);
      this.radPageViewPage1.Location = new System.Drawing.Point(5, 40);
      this.radPageViewPage1.Name = "radPageViewPage1";
      this.radPageViewPage1.Size = new System.Drawing.Size(770, 155);
      this.radPageViewPage1.Text = "INPUT OUTPUT";
      // 
      // radPageViewPage2
      // 
      this.radPageViewPage2.ItemSize = new System.Drawing.SizeF(167F, 29F);
      this.radPageViewPage2.Location = new System.Drawing.Point(5, 40);
      this.radPageViewPage2.Name = "radPageViewPage2";
      this.radPageViewPage2.Size = new System.Drawing.Size(770, 155);
      this.radPageViewPage2.Text = "INPUT QUERY OUTPUT";
      // 
      // radListView1
      // 
      this.radListView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radListView1.GroupItemSize = new System.Drawing.Size(200, 40);
      this.radListView1.ItemSize = new System.Drawing.Size(200, 40);
      this.radListView1.Location = new System.Drawing.Point(0, 44);
      this.radListView1.Name = "radListView1";
      this.radListView1.Size = new System.Drawing.Size(780, 156);
      this.radListView1.TabIndex = 2;
      this.radListView1.Text = "radListView1";
      // 
      // radPageViewPage3
      // 
      this.radPageViewPage3.ItemSize = new System.Drawing.SizeF(94F, 29F);
      this.radPageViewPage3.Location = new System.Drawing.Point(0, 0);
      this.radPageViewPage3.Name = "radPageViewPage3";
      this.radPageViewPage3.Size = new System.Drawing.Size(200, 100);
      this.radPageViewPage3.Text = "INPUT TASK";
      // 
      // radPageViewPage4
      // 
      this.radPageViewPage4.ItemSize = new System.Drawing.SizeF(60F, 29F);
      this.radPageViewPage4.Location = new System.Drawing.Point(0, 0);
      this.radPageViewPage4.Name = "radPageViewPage4";
      this.radPageViewPage4.Size = new System.Drawing.Size(200, 100);
      this.radPageViewPage4.Text = "SCRIPT";
      // 
      // CecScripter
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.radListView1);
      this.Controls.Add(this.radPageView1);
      this.Controls.Add(this.radCommandBar1);
      this.Name = "CecScripter";
      ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
      this.radPageView1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.radListView1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
    private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
    private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
    private Telerik.WinControls.UI.CommandBarButton btn_menu_new;
    private Telerik.WinControls.UI.CommandBarButton btn_menu_load;
    private Telerik.WinControls.UI.CommandBarButton btn_menu_save;
    private Telerik.WinControls.UI.CommandBarButton btn_menu_saveas;
    private Telerik.WinControls.UI.RadPageView radPageView1;
    private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
    private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
    private Telerik.WinControls.UI.RadListView radListView1;
    private Telerik.WinControls.UI.RadPageViewPage radPageViewPage3;
    private Telerik.WinControls.UI.RadPageViewPage radPageViewPage4;
  }
}
