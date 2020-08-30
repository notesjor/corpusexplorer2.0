namespace CorpusExplorer.Terminal.WinForm.Forms.WordBag
{
  partial class WordBagBuilder
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
      this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
      this.drop_operator = new Telerik.WinControls.UI.RadDropDownList();
      this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
      this.txt_query = new Telerik.WinControls.UI.RadTextBox();
      this.btn_go = new Telerik.WinControls.UI.RadButton();
      this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
      this.txt_results = new Telerik.WinControls.UI.RadAutoCompleteBox();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
      this.radGroupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.drop_operator)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
      this.radGroupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_query)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_go)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
      this.radGroupBox3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_results)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Location = new System.Drawing.Point(0, 412);
      this.radPanel1.Size = new System.Drawing.Size(800, 38);
      // 
      // radGroupBox1
      // 
      this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox1.Controls.Add(this.drop_operator);
      this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox1.HeaderText = "1. Operator auswählen...";
      this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
      this.radGroupBox1.Name = "radGroupBox1";
      this.radGroupBox1.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox1.Size = new System.Drawing.Size(800, 67);
      this.radGroupBox1.TabIndex = 1;
      this.radGroupBox1.Text = "1. Operator auswählen...";
      // 
      // drop_operator
      // 
      this.drop_operator.Dock = System.Windows.Forms.DockStyle.Top;
      this.drop_operator.Location = new System.Drawing.Point(5, 25);
      this.drop_operator.Name = "drop_operator";
      this.drop_operator.NullText = "Bitte auswählen...";
      this.drop_operator.Size = new System.Drawing.Size(790, 32);
      this.drop_operator.TabIndex = 0;
      // 
      // radGroupBox2
      // 
      this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox2.Controls.Add(this.txt_query);
      this.radGroupBox2.Controls.Add(this.btn_go);
      this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox2.HeaderText = "2. Suchabfrage...";
      this.radGroupBox2.Location = new System.Drawing.Point(0, 67);
      this.radGroupBox2.Name = "radGroupBox2";
      this.radGroupBox2.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox2.Size = new System.Drawing.Size(800, 67);
      this.radGroupBox2.TabIndex = 2;
      this.radGroupBox2.Text = "2. Suchabfrage...";
      // 
      // txt_query
      // 
      this.txt_query.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_query.Location = new System.Drawing.Point(5, 25);
      this.txt_query.Name = "txt_query";
      this.txt_query.NullText = "Suchabfrage hier eingeben";
      this.txt_query.Size = new System.Drawing.Size(753, 37);
      this.txt_query.TabIndex = 0;
      // 
      // btn_go
      // 
      this.btn_go.Dock = System.Windows.Forms.DockStyle.Right;
      this.btn_go.Image = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.button_circle_right;
      this.btn_go.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
      this.btn_go.Location = new System.Drawing.Point(758, 25);
      this.btn_go.Name = "btn_go";
      this.btn_go.Size = new System.Drawing.Size(37, 37);
      this.btn_go.TabIndex = 1;
      this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
      // 
      // radGroupBox3
      // 
      this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox3.Controls.Add(this.txt_results);
      this.radGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radGroupBox3.HeaderText = "3. Ergebnisse kontrollieren...";
      this.radGroupBox3.Location = new System.Drawing.Point(0, 134);
      this.radGroupBox3.Name = "radGroupBox3";
      this.radGroupBox3.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox3.Size = new System.Drawing.Size(800, 278);
      this.radGroupBox3.TabIndex = 3;
      this.radGroupBox3.Text = "3. Ergebnisse kontrollieren...";
      // 
      // txt_results
      // 
      this.txt_results.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_results.Location = new System.Drawing.Point(5, 25);
      this.txt_results.Multiline = true;
      this.txt_results.Name = "txt_results";
      this.txt_results.ShowClearButton = true;
      this.txt_results.Size = new System.Drawing.Size(790, 248);
      this.txt_results.TabIndex = 0;
      // 
      // WordBagBuilder
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.radGroupBox3);
      this.Controls.Add(this.radGroupBox2);
      this.Controls.Add(this.radGroupBox1);
      this.DisplayAbort = true;
      this.Name = "WordBagBuilder";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "Komplexe Abfrage erstellen";
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.radGroupBox1, 0);
      this.Controls.SetChildIndex(this.radGroupBox2, 0);
      this.Controls.SetChildIndex(this.radGroupBox3, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
      this.radGroupBox1.ResumeLayout(false);
      this.radGroupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.drop_operator)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
      this.radGroupBox2.ResumeLayout(false);
      this.radGroupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_query)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.btn_go)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
      this.radGroupBox3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.txt_results)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    private Telerik.WinControls.UI.RadDropDownList drop_operator;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
    private Telerik.WinControls.UI.RadTextBox txt_query;
    private Telerik.WinControls.UI.RadButton btn_go;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
    private Telerik.WinControls.UI.RadAutoCompleteBox txt_results;
  }
}