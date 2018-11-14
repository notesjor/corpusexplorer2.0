namespace CorpusExplorer.Terminal.WinForm.Forms.Colorizer
{
  partial class ColorizerForm
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
      this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
      this.ihdPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
      this.radDropDownList1 = new Telerik.WinControls.UI.RadDropDownList();
      this.radCheckBox1 = new Telerik.WinControls.UI.RadCheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radDropDownList1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Location = new System.Drawing.Point(0, 193);
      this.radPanel1.Size = new System.Drawing.Size(694, 38);
      // 
      // elementHost1
      // 
      this.elementHost1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.elementHost1.Location = new System.Drawing.Point(0, 143);
      this.elementHost1.Name = "elementHost1";
      this.elementHost1.Size = new System.Drawing.Size(694, 50);
      this.elementHost1.TabIndex = 1;
      this.elementHost1.Text = "elementHost1";
      this.elementHost1.Child = null;
      // 
      // ihdPanel1
      // 
      this.ihdPanel1.BackColor = System.Drawing.Color.White;
      this.ihdPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihdPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihdPanel1.IHDDeescribtion = "\"Grau, teurer Freund, ist alle Theorie\" - J. W. v. Goethe";
      this.ihdPanel1.IHDHeader = "Wählen Sie den gewünschten Farbverlauf aus...";
      this.ihdPanel1.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.color_fill1;
      this.ihdPanel1.Location = new System.Drawing.Point(0, 0);
      this.ihdPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.ihdPanel1.Name = "ihdPanel1";
      this.ihdPanel1.Size = new System.Drawing.Size(694, 64);
      this.ihdPanel1.TabIndex = 2;
      // 
      // radDropDownList1
      // 
      this.radDropDownList1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radDropDownList1.Location = new System.Drawing.Point(0, 64);
      this.radDropDownList1.Name = "radDropDownList1";
      this.radDropDownList1.NullText = "Bitte auswählen...";
      this.radDropDownList1.Size = new System.Drawing.Size(694, 32);
      this.radDropDownList1.TabIndex = 3;
      this.radDropDownList1.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.radDropDownList1_SelectedIndexChanged);
      // 
      // radCheckBox1
      // 
      this.radCheckBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radCheckBox1.Location = new System.Drawing.Point(0, 96);
      this.radCheckBox1.Name = "radCheckBox1";
      this.radCheckBox1.Size = new System.Drawing.Size(159, 32);
      this.radCheckBox1.TabIndex = 4;
      this.radCheckBox1.Text = "Farben umkehren";
      this.radCheckBox1.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox1_ToggleStateChanged);
      // 
      // ColorizerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(694, 231);
      this.Controls.Add(this.radCheckBox1);
      this.Controls.Add(this.radDropDownList1);
      this.Controls.Add(this.ihdPanel1);
      this.Controls.Add(this.elementHost1);
      this.DisplayAbort = true;
      this.Name = "ColorizerForm";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "Farbverlaufs-Editor";
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.elementHost1, 0);
      this.Controls.SetChildIndex(this.ihdPanel1, 0);
      this.Controls.SetChildIndex(this.radDropDownList1, 0);
      this.Controls.SetChildIndex(this.radCheckBox1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radDropDownList1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Integration.ElementHost elementHost1;
    private Controls.WinForm.IHDPanel ihdPanel1;
    private Telerik.WinControls.UI.RadDropDownList radDropDownList1;
    private Telerik.WinControls.UI.RadCheckBox radCheckBox1;
  }
}