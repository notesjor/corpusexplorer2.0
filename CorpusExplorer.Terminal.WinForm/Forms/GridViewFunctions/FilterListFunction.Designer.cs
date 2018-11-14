namespace CorpusExplorer.Terminal.WinForm.Forms.GridViewFunctions
{
  partial class FilterListFunction
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
      Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
      this.ihdPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
      this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
      this.drop_case = new Telerik.WinControls.UI.RadDropDownList();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.drop_case)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Location = new System.Drawing.Point(0, 453);
      this.radPanel1.Size = new System.Drawing.Size(450, 38);
      // 
      // ihdPanel1
      // 
      this.ihdPanel1.BackColor = System.Drawing.Color.White;
      this.ihdPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihdPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihdPanel1.IHDDeescribtion = "Geben Sie pro Zeile nur einen Begriff ein. Bestätigen Sie dann mit OK. ";
      this.ihdPanel1.IHDHeader = "Sehen Sie nur das, was Sie sehen wollen...";
      this.ihdPanel1.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.filter_list1;
      this.ihdPanel1.Location = new System.Drawing.Point(0, 0);
      this.ihdPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.ihdPanel1.Name = "ihdPanel1";
      this.ihdPanel1.Size = new System.Drawing.Size(450, 68);
      this.ihdPanel1.TabIndex = 1;
      // 
      // radTextBox1
      // 
      this.radTextBox1.AcceptsReturn = true;
      this.radTextBox1.AutoScroll = true;
      this.radTextBox1.AutoSize = false;
      this.radTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radTextBox1.Location = new System.Drawing.Point(0, 100);
      this.radTextBox1.Multiline = true;
      this.radTextBox1.Name = "radTextBox1";
      this.radTextBox1.Size = new System.Drawing.Size(450, 353);
      this.radTextBox1.TabIndex = 2;
      // 
      // drop_case
      // 
      this.drop_case.Dock = System.Windows.Forms.DockStyle.Top;
      radListDataItem1.Text = "Es werden nur diese Elemente angezeigt";
      radListDataItem2.Text = "Diese Elemente werden alle ausgeblendet";
      this.drop_case.Items.Add(radListDataItem1);
      this.drop_case.Items.Add(radListDataItem2);
      this.drop_case.Location = new System.Drawing.Point(0, 68);
      this.drop_case.Name = "drop_case";
      this.drop_case.Size = new System.Drawing.Size(450, 32);
      this.drop_case.TabIndex = 3;
      this.drop_case.Text = "Es werden nur diese Elemente angezeigt";
      // 
      // FilterListFunction
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(450, 491);
      this.Controls.Add(this.radTextBox1);
      this.Controls.Add(this.drop_case);
      this.Controls.Add(this.ihdPanel1);
      this.DisplayAbort = true;
      this.Name = "FilterListFunction";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "Filterliste definieren...";
      this.ButtonOkClick += new System.EventHandler(this.FilterListFunction_ButtonOkClick);
      this.Load += new System.EventHandler(this.FilterListFunction_Load);
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.ihdPanel1, 0);
      this.Controls.SetChildIndex(this.drop_case, 0);
      this.Controls.SetChildIndex(this.radTextBox1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.drop_case)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Controls.WinForm.IHDPanel ihdPanel1;
    private Telerik.WinControls.UI.RadTextBox radTextBox1;
    private Telerik.WinControls.UI.RadDropDownList drop_case;
  }
}