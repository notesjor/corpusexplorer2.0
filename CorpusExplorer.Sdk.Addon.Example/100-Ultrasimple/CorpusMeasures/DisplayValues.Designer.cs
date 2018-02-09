namespace CorpusExplorer.Sdk.Addon.Example.CorpusMeasures
{
  partial class DisplayValues
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
      this.lbl_count_corpora = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lbl_count_documents = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // lbl_count_corpora
      // 
      this.lbl_count_corpora.Font = new System.Drawing.Font("Segoe UI Light", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_count_corpora.Location = new System.Drawing.Point(44, 121);
      this.lbl_count_corpora.Name = "lbl_count_corpora";
      this.lbl_count_corpora.Size = new System.Drawing.Size(234, 65);
      this.lbl_count_corpora.TabIndex = 0;
      this.lbl_count_corpora.Text = "{0}";
      this.lbl_count_corpora.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(128, 186);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(63, 20);
      this.label3.TabIndex = 2;
      this.label3.Text = "Korpora";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(444, 186);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(86, 20);
      this.label2.TabIndex = 4;
      this.label2.Text = "Dokumente";
      // 
      // lbl_count_documents
      // 
      this.lbl_count_documents.Font = new System.Drawing.Font("Segoe UI Light", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_count_documents.Location = new System.Drawing.Point(373, 121);
      this.lbl_count_documents.Name = "lbl_count_documents";
      this.lbl_count_documents.Size = new System.Drawing.Size(234, 65);
      this.lbl_count_documents.TabIndex = 3;
      this.lbl_count_documents.Text = "{0}";
      this.lbl_count_documents.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // DisplayValues
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.Controls.Add(this.label2);
      this.Controls.Add(this.lbl_count_documents);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.lbl_count_corpora);
      this.Name = "DisplayValues";
      this.Size = new System.Drawing.Size(676, 394);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lbl_count_corpora;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lbl_count_documents;
  }
}
