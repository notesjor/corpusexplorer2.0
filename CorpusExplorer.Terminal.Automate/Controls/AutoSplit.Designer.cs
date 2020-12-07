
namespace CorpusExplorer.Terminal.Automate.Controls
{
  partial class AutoSplit
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
      Telerik.WinControls.UI.RadListDataItem radListDataItem14 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem15 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem16 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem17 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem18 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem19 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem20 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem21 = new Telerik.WinControls.UI.RadListDataItem();
      Telerik.WinControls.UI.RadListDataItem radListDataItem22 = new Telerik.WinControls.UI.RadListDataItem();
      this.panel_size = new Telerik.WinControls.UI.RadGroupBox();
      this.txt_size = new Telerik.WinControls.UI.RadTextBox();
      this.radGroupBox9 = new Telerik.WinControls.UI.RadGroupBox();
      this.drop_type = new Telerik.WinControls.UI.RadDropDownList();
      this.radGroupBox11 = new Telerik.WinControls.UI.RadGroupBox();
      this.txt_meta = new Telerik.WinControls.UI.RadTextBox();
      this.panle_date = new Telerik.WinControls.UI.RadGroupBox();
      this.drop_date = new Telerik.WinControls.UI.RadDropDownList();
      ((System.ComponentModel.ISupportInitialize)(this.panel_size)).BeginInit();
      this.panel_size.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_size)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox9)).BeginInit();
      this.radGroupBox9.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.drop_type)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox11)).BeginInit();
      this.radGroupBox11.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_meta)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panle_date)).BeginInit();
      this.panle_date.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.drop_date)).BeginInit();
      this.SuspendLayout();
      // 
      // panel_size
      // 
      this.panel_size.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.panel_size.Controls.Add(this.txt_size);
      this.panel_size.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel_size.HeaderText = "Cluster-Größe";
      this.panel_size.Location = new System.Drawing.Point(0, 210);
      this.panel_size.Name = "panel_size";
      this.panel_size.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.panel_size.Size = new System.Drawing.Size(670, 70);
      this.panel_size.TabIndex = 4;
      this.panel_size.Text = "Cluster-Größe";
      // 
      // txt_size
      // 
      this.txt_size.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_size.Location = new System.Drawing.Point(5, 25);
      this.txt_size.Name = "txt_size";
      this.txt_size.NullText = "Wieviele Cluster sollen erstellt werden?...";
      this.txt_size.Size = new System.Drawing.Size(660, 40);
      this.txt_size.TabIndex = 2;
      this.txt_size.TextChanged += new System.EventHandler(this.datachange_textbox);
      // 
      // radGroupBox9
      // 
      this.radGroupBox9.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox9.Controls.Add(this.drop_type);
      this.radGroupBox9.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox9.HeaderText = "Datentyp";
      this.radGroupBox9.Location = new System.Drawing.Point(0, 70);
      this.radGroupBox9.Name = "radGroupBox9";
      this.radGroupBox9.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox9.Size = new System.Drawing.Size(670, 70);
      this.radGroupBox9.TabIndex = 3;
      this.radGroupBox9.Text = "Datentyp";
      // 
      // drop_type
      // 
      this.drop_type.Dock = System.Windows.Forms.DockStyle.Top;
      radListDataItem14.Text = "TEXT = Text (jeder Wert separat)";
      radListDataItem15.Text = "INT = Ganzzahl";
      radListDataItem16.Text = "FLOAT = Kommazahl";
      radListDataItem17.Text = "DATE = Datum (erweiterte Optionen)";
      this.drop_type.Items.Add(radListDataItem14);
      this.drop_type.Items.Add(radListDataItem15);
      this.drop_type.Items.Add(radListDataItem16);
      this.drop_type.Items.Add(radListDataItem17);
      this.drop_type.Location = new System.Drawing.Point(5, 25);
      this.drop_type.Name = "drop_type";
      this.drop_type.NullText = "Bitte geben Sie an, wie die Meta-Angabe behandelt werden soll...";
      this.drop_type.Size = new System.Drawing.Size(660, 32);
      this.drop_type.TabIndex = 0;
      this.drop_type.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.drop_type_SelectedIndexChanged);
      // 
      // radGroupBox11
      // 
      this.radGroupBox11.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.radGroupBox11.Controls.Add(this.txt_meta);
      this.radGroupBox11.Dock = System.Windows.Forms.DockStyle.Top;
      this.radGroupBox11.HeaderText = "Meta-Angabe";
      this.radGroupBox11.Location = new System.Drawing.Point(0, 0);
      this.radGroupBox11.Name = "radGroupBox11";
      this.radGroupBox11.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.radGroupBox11.Size = new System.Drawing.Size(670, 70);
      this.radGroupBox11.TabIndex = 5;
      this.radGroupBox11.Text = "Meta-Angabe";
      // 
      // txt_meta
      // 
      this.txt_meta.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txt_meta.Location = new System.Drawing.Point(5, 25);
      this.txt_meta.Name = "txt_meta";
      this.txt_meta.NullText = "Hier bitte den Namen der Meta-Angabe eintragen...";
      this.txt_meta.Size = new System.Drawing.Size(660, 40);
      this.txt_meta.TabIndex = 2;
      this.txt_meta.TextChanged += new System.EventHandler(this.datachange_textbox);
      // 
      // panle_date
      // 
      this.panle_date.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.panle_date.Controls.Add(this.drop_date);
      this.panle_date.Dock = System.Windows.Forms.DockStyle.Top;
      this.panle_date.HeaderText = "Datums-Cluster Optionen";
      this.panle_date.Location = new System.Drawing.Point(0, 140);
      this.panle_date.Name = "panle_date";
      this.panle_date.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.panle_date.Size = new System.Drawing.Size(670, 70);
      this.panle_date.TabIndex = 6;
      this.panle_date.Text = "Datums-Cluster Optionen";
      // 
      // drop_date
      // 
      this.drop_date.Dock = System.Windows.Forms.DockStyle.Top;
      radListDataItem1.Text = "DATE;C = Datums-Cluster (gleich große Zeitspanne)";
      radListDataItem2.Text = "DATE;CEN = Cluster nach Jahrhunderten (23.12.1985 > 19)";
      radListDataItem3.Text = "DATE;DEC = Cluster nach Jahrzehnten (23.12.1985 > 198)";
      radListDataItem4.Text = "DATE;Y = Cluster nach Jahren";
      radListDataItem18.Text = "DATE;YM = Cluster nach Jahr/Monat";
      radListDataItem19.Text = "DATE;YMD = Cluster nach Jahr/Monat/Tag";
      radListDataItem20.Text = "DATE;YMDH = Cluster nach Jahr/Monat/Tag/Stunde";
      radListDataItem21.Text = "DATE;YMDHM = Cluster nach Jahr/Monat/Tag/Stunde/Minute";
      radListDataItem22.Text = "DATE;ALL = Cluster nach exakter Zeitangabe (Millisekunde)";
      this.drop_date.Items.Add(radListDataItem1);
      this.drop_date.Items.Add(radListDataItem2);
      this.drop_date.Items.Add(radListDataItem3);
      this.drop_date.Items.Add(radListDataItem4);
      this.drop_date.Items.Add(radListDataItem18);
      this.drop_date.Items.Add(radListDataItem19);
      this.drop_date.Items.Add(radListDataItem20);
      this.drop_date.Items.Add(radListDataItem21);
      this.drop_date.Items.Add(radListDataItem22);
      this.drop_date.Location = new System.Drawing.Point(5, 25);
      this.drop_date.Name = "drop_date";
      this.drop_date.NullText = "Wie sollen die Datumswerte verarbeitet werden?...";
      this.drop_date.Size = new System.Drawing.Size(660, 32);
      this.drop_date.TabIndex = 0;
      this.drop_date.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.drop_date_SelectedIndexChanged);
      // 
      // AutoSplit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panel_size);
      this.Controls.Add(this.panle_date);
      this.Controls.Add(this.radGroupBox9);
      this.Controls.Add(this.radGroupBox11);
      this.Name = "AutoSplit";
      this.Size = new System.Drawing.Size(670, 458);
      ((System.ComponentModel.ISupportInitialize)(this.panel_size)).EndInit();
      this.panel_size.ResumeLayout(false);
      this.panel_size.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_size)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox9)).EndInit();
      this.radGroupBox9.ResumeLayout(false);
      this.radGroupBox9.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.drop_type)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radGroupBox11)).EndInit();
      this.radGroupBox11.ResumeLayout(false);
      this.radGroupBox11.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txt_meta)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panle_date)).EndInit();
      this.panle_date.ResumeLayout(false);
      this.panle_date.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.drop_date)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadGroupBox panel_size;
    private Telerik.WinControls.UI.RadTextBox txt_size;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox9;
    private Telerik.WinControls.UI.RadDropDownList drop_type;
    private Telerik.WinControls.UI.RadGroupBox radGroupBox11;
    private Telerik.WinControls.UI.RadTextBox txt_meta;
    private Telerik.WinControls.UI.RadGroupBox panle_date;
    private Telerik.WinControls.UI.RadDropDownList drop_date;
  }
}
