namespace CorpusExplorer.Terminal.WinForm.Forms.RegEx
{
  partial class RegExForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegExForm));
      this.layerSettings1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.LayerSettings();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.txt_regex = new Telerik.WinControls.UI.RadTextBox();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_regex)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // header1
      // 
      this.header1.HeaderDescription = "Wählen Sie aus, auf welche Spalte der Reguläre Ausdruck angewendet werden soll.";
      this.header1.HeaderHead = "Spalte auswählen";
      resources.ApplyResources(this.header1, "header1");
      // 
      // radPanel1
      // 
      resources.ApplyResources(this.radPanel1, "radPanel1");
      // 
      // layerSettings1
      // 
      this.layerSettings1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.layerSettings1, "layerSettings1");
      this.layerSettings1.Header = "Spalte";
      this.layerSettings1.IsLayerOptional = false;
      this.layerSettings1.Name = "layerSettings1";
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.txt_regex);
      resources.ApplyResources(this.radGroupBox1, "radGroupBox1");
      this.radGroupBox1.Name = "radGroupBox1";
      // 
      // txt_regex
      // 
      resources.ApplyResources(this.txt_regex, "txt_regex");
      this.txt_regex.Multiline = true;
      this.txt_regex.Name = "txt_regex";
      // 
      // 
      // 
      this.txt_regex.RootElement.StretchVertically = true;
      // 
      // RegExForm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this.layerSettings1);
      this.DisplayAbort = true;
      this.Name = "RegExForm";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.ButtonOkClick += new System.EventHandler(this.Form_ButtonOkClick);
      this.Controls.SetChildIndex(this.header1, 0);
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.layerSettings1, 0);
      this.Controls.SetChildIndex(this.radGroupBox1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_regex)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.WinForm.LayerSettings layerSettings1;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadTextBox txt_regex;
  }
}