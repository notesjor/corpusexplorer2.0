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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterListFunction));
      Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
      this.ihdPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
      this.radTextBox1 = new Telerik.WinControls.UI.RadTextBox();
      this.drop_case = new Telerik.WinControls.UI.RadDropDownList();
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.radRadioButton1 = new Telerik.WinControls.UI.RadRadioButton();
      this.radRadioButton2 = new Telerik.WinControls.UI.RadRadioButton();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.drop_case)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      resources.ApplyResources(this.radPanel1, "radPanel1");
      // 
      // ihdPanel1
      // 
      this.ihdPanel1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.ihdPanel1, "ihdPanel1");
      this.ihdPanel1.IHDDescription = "Geben Sie pro Zeile nur einen Begriff ein. Bestätigen Sie dann mit OK. ";
      this.ihdPanel1.IHDHeader = "Sehen Sie nur das, was Sie sehen wollen...";
      this.ihdPanel1.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.filter_list1;
      this.ihdPanel1.Name = "ihdPanel1";
      // 
      // radTextBox1
      // 
      this.radTextBox1.AcceptsReturn = true;
      resources.ApplyResources(this.radTextBox1, "radTextBox1");
      this.radTextBox1.Multiline = true;
      this.radTextBox1.Name = "radTextBox1";
      // 
      // drop_case
      // 
      resources.ApplyResources(this.drop_case, "drop_case");
      radListDataItem1.Text = "Es werden nur diese Elemente angezeigt";
      radListDataItem2.Text = "Diese Elemente werden alle ausgeblendet";
      this.drop_case.Items.Add(radListDataItem1);
      this.drop_case.Items.Add(radListDataItem2);
      this.drop_case.Name = "drop_case";
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.radRadioButton2);
      this.radGroupBox1.Controls.Add(this.radRadioButton1);
      resources.ApplyResources(this.radGroupBox1, "radGroupBox1");
      this.radGroupBox1.Name = "radGroupBox1";
      // 
      // radRadioButton1
      // 
      this.radRadioButton1.CheckState = System.Windows.Forms.CheckState.Checked;
      resources.ApplyResources(this.radRadioButton1, "radRadioButton1");
      this.radRadioButton1.Name = "radRadioButton1";
      this.radRadioButton1.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
      // 
      // radRadioButton2
      // 
      resources.ApplyResources(this.radRadioButton2, "radRadioButton2");
      this.radRadioButton2.Name = "radRadioButton2";
      this.radRadioButton2.TabStop = false;
      // 
      // FilterListFunction
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.radTextBox1);
      this.Controls.Add(this.radGroupBox1);
      this.Controls.Add(this.drop_case);
      this.Controls.Add(this.ihdPanel1);
      this.DisplayAbort = true;
      this.Name = "FilterListFunction";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.ButtonOkClick += new System.EventHandler(this.FilterListFunction_ButtonOkClick);
      this.Load += new System.EventHandler(this.FilterListFunction_Load);
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.ihdPanel1, 0);
      this.Controls.SetChildIndex(this.drop_case, 0);
      this.Controls.SetChildIndex(this.radGroupBox1, 0);
      this.Controls.SetChildIndex(this.radTextBox1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.drop_case)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Controls.WinForm.IHDPanel ihdPanel1;
    private Telerik.WinControls.UI.RadTextBox radTextBox1;
    private Telerik.WinControls.UI.RadDropDownList drop_case;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadRadioButton radRadioButton2;
    private Telerik.WinControls.UI.RadRadioButton radRadioButton1;
  }
}