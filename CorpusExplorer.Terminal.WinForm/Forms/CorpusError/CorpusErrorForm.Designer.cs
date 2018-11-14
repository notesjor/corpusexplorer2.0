namespace CorpusExplorer.Terminal.WinForm.Forms.CorpusError
{
  partial class CorpusErrorForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorpusErrorForm));
      this.ihdPanel1 = new CorpusExplorer.Terminal.WinForm.Controls.WinForm.IHDPanel();
      this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
      this.page_sentenceError = new Telerik.WinControls.UI.RadPageViewPage();
      this.grp_senteceError = new Telerik.WinControls.UI.RadGroupBox();
      this.list_senteceError = new Telerik.WinControls.UI.RadListView();
      this.chk_senteceError = new Telerik.WinControls.UI.RadCheckBox();
      this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
      this.page_diffLayer = new Telerik.WinControls.UI.RadPageViewPage();
      this.grp_DiffLayer = new Telerik.WinControls.UI.RadGroupBox();
      this.list_DiffLayer = new Telerik.WinControls.UI.RadListView();
      this.chk_DiffLayer = new Telerik.WinControls.UI.RadCheckBox();
      this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
      this.page_emptyDocument = new Telerik.WinControls.UI.RadPageViewPage();
      this.grp_emptyDocuments = new Telerik.WinControls.UI.RadGroupBox();
      this.list_emptyDocuments = new Telerik.WinControls.UI.RadListView();
      this.chk_emptyDocuments = new Telerik.WinControls.UI.RadCheckBox();
      this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
      this.radPageView1.SuspendLayout();
      this.page_sentenceError.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grp_senteceError)).BeginInit();
      this.grp_senteceError.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.list_senteceError)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_senteceError)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
      this.page_diffLayer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grp_DiffLayer)).BeginInit();
      this.grp_DiffLayer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.list_DiffLayer)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_DiffLayer)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
      this.page_emptyDocument.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grp_emptyDocuments)).BeginInit();
      this.grp_emptyDocuments.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.list_emptyDocuments)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_emptyDocuments)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // radPanel1
      // 
      this.radPanel1.Location = new System.Drawing.Point(0, 467);
      this.radPanel1.Size = new System.Drawing.Size(528, 38);
      // 
      // ihdPanel1
      // 
      this.ihdPanel1.BackColor = System.Drawing.Color.White;
      this.ihdPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.ihdPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ihdPanel1.IHDDeescribtion = "Im Folgenden werden alle Probleme inkl. Lösungsmöglichkeit aufgelistet.";
      this.ihdPanel1.IHDHeader = "Kein Grund zur Panik...";
      this.ihdPanel1.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.cabinet_warn1;
      this.ihdPanel1.Location = new System.Drawing.Point(0, 0);
      this.ihdPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.ihdPanel1.Name = "ihdPanel1";
      this.ihdPanel1.Size = new System.Drawing.Size(528, 54);
      this.ihdPanel1.TabIndex = 1;
      // 
      // radPageView1
      // 
      this.radPageView1.Controls.Add(this.page_sentenceError);
      this.radPageView1.Controls.Add(this.page_diffLayer);
      this.radPageView1.Controls.Add(this.page_emptyDocument);
      this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.radPageView1.ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
      this.radPageView1.Location = new System.Drawing.Point(0, 54);
      this.radPageView1.Name = "radPageView1";
      this.radPageView1.SelectedPage = this.page_diffLayer;
      this.radPageView1.Size = new System.Drawing.Size(528, 413);
      this.radPageView1.TabIndex = 2;
      this.radPageView1.ViewMode = Telerik.WinControls.UI.PageViewMode.Stack;
      // 
      // page_sentenceError
      // 
      this.page_sentenceError.Controls.Add(this.grp_senteceError);
      this.page_sentenceError.Controls.Add(this.chk_senteceError);
      this.page_sentenceError.Controls.Add(this.radLabel1);
      this.page_sentenceError.ItemSize = new System.Drawing.SizeF(526F, 31F);
      this.page_sentenceError.Location = new System.Drawing.Point(5, 45);
      this.page_sentenceError.Name = "page_sentenceError";
      this.page_sentenceError.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.page_sentenceError.Size = new System.Drawing.Size(518, 270);
      this.page_sentenceError.Text = "Dokumente ohne Satzgrenzen";
      // 
      // grp_senteceError
      // 
      this.grp_senteceError.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.grp_senteceError.Controls.Add(this.list_senteceError);
      this.grp_senteceError.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grp_senteceError.HeaderText = "{0} von {1} Dokumente betroffen";
      this.grp_senteceError.Location = new System.Drawing.Point(3, 77);
      this.grp_senteceError.Name = "grp_senteceError";
      this.grp_senteceError.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.grp_senteceError.Size = new System.Drawing.Size(515, 124);
      this.grp_senteceError.TabIndex = 1;
      this.grp_senteceError.Text = "{0} von {1} Dokumente betroffen";
      // 
      // list_senteceError
      // 
      this.list_senteceError.Dock = System.Windows.Forms.DockStyle.Fill;
      this.list_senteceError.GroupItemSize = new System.Drawing.Size(200, 40);
      this.list_senteceError.ItemSize = new System.Drawing.Size(200, 40);
      this.list_senteceError.Location = new System.Drawing.Point(5, 25);
      this.list_senteceError.Name = "list_senteceError";
      this.list_senteceError.Size = new System.Drawing.Size(505, 94);
      this.list_senteceError.TabIndex = 0;
      // 
      // chk_senteceError
      // 
      this.chk_senteceError.AutoSize = false;
      this.chk_senteceError.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chk_senteceError.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.chk_senteceError.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.chk_senteceError.Location = new System.Drawing.Point(3, 201);
      this.chk_senteceError.Name = "chk_senteceError";
      this.chk_senteceError.Size = new System.Drawing.Size(515, 69);
      this.chk_senteceError.TabIndex = 2;
      this.chk_senteceError.Text = resources.GetString("chk_senteceError.Text");
      this.chk_senteceError.TextWrap = true;
      this.chk_senteceError.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
      ((Telerik.WinControls.UI.RadCheckBoxElement)(this.chk_senteceError.GetChildAt(0))).ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
      ((Telerik.WinControls.UI.RadCheckBoxElement)(this.chk_senteceError.GetChildAt(0))).Text = resources.GetString("resource.Text");
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_senteceError.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).TextWrap = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_senteceError.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_senteceError.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 10F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_senteceError.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // radLabel1
      // 
      this.radLabel1.AutoSize = false;
      this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.radLabel1.Location = new System.Drawing.Point(3, 0);
      this.radLabel1.Name = "radLabel1";
      this.radLabel1.Size = new System.Drawing.Size(515, 77);
      this.radLabel1.TabIndex = 0;
      this.radLabel1.Text = resources.GetString("radLabel1.Text");
      // 
      // page_diffLayer
      // 
      this.page_diffLayer.Controls.Add(this.grp_DiffLayer);
      this.page_diffLayer.Controls.Add(this.chk_DiffLayer);
      this.page_diffLayer.Controls.Add(this.radLabel2);
      this.page_diffLayer.ItemSize = new System.Drawing.SizeF(526F, 31F);
      this.page_diffLayer.Location = new System.Drawing.Point(5, 45);
      this.page_diffLayer.Name = "page_diffLayer";
      this.page_diffLayer.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.page_diffLayer.Size = new System.Drawing.Size(518, 270);
      this.page_diffLayer.Text = "Dokumente mit unterschiedlichen Layern";
      // 
      // grp_DiffLayer
      // 
      this.grp_DiffLayer.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.grp_DiffLayer.Controls.Add(this.list_DiffLayer);
      this.grp_DiffLayer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grp_DiffLayer.HeaderText = "{0} von {1} Dokumente betroffen";
      this.grp_DiffLayer.Location = new System.Drawing.Point(3, 80);
      this.grp_DiffLayer.Name = "grp_DiffLayer";
      this.grp_DiffLayer.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.grp_DiffLayer.Size = new System.Drawing.Size(515, 144);
      this.grp_DiffLayer.TabIndex = 4;
      this.grp_DiffLayer.Text = "{0} von {1} Dokumente betroffen";
      // 
      // list_DiffLayer
      // 
      this.list_DiffLayer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.list_DiffLayer.GroupItemSize = new System.Drawing.Size(200, 40);
      this.list_DiffLayer.ItemSize = new System.Drawing.Size(200, 40);
      this.list_DiffLayer.Location = new System.Drawing.Point(5, 25);
      this.list_DiffLayer.Name = "list_DiffLayer";
      this.list_DiffLayer.Size = new System.Drawing.Size(505, 114);
      this.list_DiffLayer.TabIndex = 0;
      // 
      // chk_DiffLayer
      // 
      this.chk_DiffLayer.AutoSize = false;
      this.chk_DiffLayer.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.chk_DiffLayer.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.chk_DiffLayer.Location = new System.Drawing.Point(3, 224);
      this.chk_DiffLayer.Name = "chk_DiffLayer";
      this.chk_DiffLayer.Size = new System.Drawing.Size(515, 46);
      this.chk_DiffLayer.TabIndex = 5;
      this.chk_DiffLayer.Text = "<html><strong>Automatische Korrektur:</strong> Entfernt die betroffenen Dokumente" +
    ". Es wird jedoch empfohlen, zuerst einmal das Korpus ohne diese Korrektur zu tes" +
    "ten.</html>";
      this.chk_DiffLayer.TextWrap = true;
      ((Telerik.WinControls.UI.RadCheckBoxElement)(this.chk_DiffLayer.GetChildAt(0))).ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
      ((Telerik.WinControls.UI.RadCheckBoxElement)(this.chk_DiffLayer.GetChildAt(0))).Text = "<html><strong>Automatische Korrektur:</strong> Entfernt die betroffenen Dokumente" +
    ". Es wird jedoch empfohlen, zuerst einmal das Korpus ohne diese Korrektur zu tes" +
    "ten.</html>";
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_DiffLayer.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).TextWrap = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_DiffLayer.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_DiffLayer.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 10F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_DiffLayer.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // radLabel2
      // 
      this.radLabel2.AutoSize = false;
      this.radLabel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.radLabel2.Location = new System.Drawing.Point(3, 0);
      this.radLabel2.Name = "radLabel2";
      this.radLabel2.Size = new System.Drawing.Size(515, 80);
      this.radLabel2.TabIndex = 3;
      this.radLabel2.Text = resources.GetString("radLabel2.Text");
      // 
      // page_emptyDocument
      // 
      this.page_emptyDocument.Controls.Add(this.grp_emptyDocuments);
      this.page_emptyDocument.Controls.Add(this.chk_emptyDocuments);
      this.page_emptyDocument.Controls.Add(this.radLabel3);
      this.page_emptyDocument.ItemSize = new System.Drawing.SizeF(526F, 31F);
      this.page_emptyDocument.Location = new System.Drawing.Point(5, 45);
      this.page_emptyDocument.Name = "page_emptyDocument";
      this.page_emptyDocument.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.page_emptyDocument.Size = new System.Drawing.Size(518, 270);
      this.page_emptyDocument.Text = "Leere Dokumente";
      // 
      // grp_emptyDocuments
      // 
      this.grp_emptyDocuments.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.grp_emptyDocuments.Controls.Add(this.list_emptyDocuments);
      this.grp_emptyDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grp_emptyDocuments.HeaderText = "{0} von {1} Dokumente betroffen";
      this.grp_emptyDocuments.Location = new System.Drawing.Point(3, 61);
      this.grp_emptyDocuments.Name = "grp_emptyDocuments";
      this.grp_emptyDocuments.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
      this.grp_emptyDocuments.Size = new System.Drawing.Size(515, 175);
      this.grp_emptyDocuments.TabIndex = 4;
      this.grp_emptyDocuments.Text = "{0} von {1} Dokumente betroffen";
      // 
      // list_emptyDocuments
      // 
      this.list_emptyDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
      this.list_emptyDocuments.GroupItemSize = new System.Drawing.Size(200, 40);
      this.list_emptyDocuments.ItemSize = new System.Drawing.Size(200, 40);
      this.list_emptyDocuments.Location = new System.Drawing.Point(5, 25);
      this.list_emptyDocuments.Name = "list_emptyDocuments";
      this.list_emptyDocuments.Size = new System.Drawing.Size(505, 145);
      this.list_emptyDocuments.TabIndex = 0;
      // 
      // chk_emptyDocuments
      // 
      this.chk_emptyDocuments.AutoSize = false;
      this.chk_emptyDocuments.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chk_emptyDocuments.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.chk_emptyDocuments.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.chk_emptyDocuments.Location = new System.Drawing.Point(3, 236);
      this.chk_emptyDocuments.Name = "chk_emptyDocuments";
      this.chk_emptyDocuments.Size = new System.Drawing.Size(515, 34);
      this.chk_emptyDocuments.TabIndex = 5;
      this.chk_emptyDocuments.Text = "<html><strong>Automatische Korrektur:</strong> Entfernt die betroffenen Dokumente" +
    ".</html>";
      this.chk_emptyDocuments.TextWrap = true;
      this.chk_emptyDocuments.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
      ((Telerik.WinControls.UI.RadCheckBoxElement)(this.chk_emptyDocuments.GetChildAt(0))).ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
      ((Telerik.WinControls.UI.RadCheckBoxElement)(this.chk_emptyDocuments.GetChildAt(0))).Text = "<html><strong>Automatische Korrektur:</strong> Entfernt die betroffenen Dokumente" +
    ".</html>";
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_emptyDocuments.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).TextWrap = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_emptyDocuments.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_emptyDocuments.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 10F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_emptyDocuments.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Alignment = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // radLabel3
      // 
      this.radLabel3.AutoSize = false;
      this.radLabel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.radLabel3.Location = new System.Drawing.Point(3, 0);
      this.radLabel3.Name = "radLabel3";
      this.radLabel3.Size = new System.Drawing.Size(515, 61);
      this.radLabel3.TabIndex = 3;
      this.radLabel3.Text = resources.GetString("radLabel3.Text");
      // 
      // CorpusErrorForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(528, 505);
      this.Controls.Add(this.radPageView1);
      this.Controls.Add(this.ihdPanel1);
      this.DisplayAbort = true;
      this.Name = "CorpusErrorForm";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "Mögliche Korpus-Probleme";
      this.ButtonAbortClick += new System.EventHandler(this.CorpusErrorForm_ButtonAbortClick);
      this.ButtonOkClick += new System.EventHandler(this.CorpusErrorForm_ButtonOkClick);
      this.Controls.SetChildIndex(this.radPanel1, 0);
      this.Controls.SetChildIndex(this.ihdPanel1, 0);
      this.Controls.SetChildIndex(this.radPageView1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
      this.radPageView1.ResumeLayout(false);
      this.page_sentenceError.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.grp_senteceError)).EndInit();
      this.grp_senteceError.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.list_senteceError)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_senteceError)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
      this.page_diffLayer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.grp_DiffLayer)).EndInit();
      this.grp_DiffLayer.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.list_DiffLayer)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_DiffLayer)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
      this.page_emptyDocument.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.grp_emptyDocuments)).EndInit();
      this.grp_emptyDocuments.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.list_emptyDocuments)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.chk_emptyDocuments)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.WinForm.IHDPanel ihdPanel1;
    private Telerik.WinControls.UI.RadPageView radPageView1;
    private Telerik.WinControls.UI.RadPageViewPage page_sentenceError;
    private Telerik.WinControls.UI.RadPageViewPage page_diffLayer;
    private Telerik.WinControls.UI.RadPageViewPage page_emptyDocument;
    private Telerik.WinControls.UI.RadCheckBox chk_senteceError;
    private Telerik.WinControls.UI.RadGroupBox grp_senteceError;
    private Telerik.WinControls.UI.RadListView list_senteceError;
    private Telerik.WinControls.UI.RadLabel radLabel1;
    private Telerik.WinControls.UI.RadCheckBox chk_DiffLayer;
    private Telerik.WinControls.UI.RadGroupBox grp_DiffLayer;
    private Telerik.WinControls.UI.RadListView list_DiffLayer;
    private Telerik.WinControls.UI.RadLabel radLabel2;
    private Telerik.WinControls.UI.RadCheckBox chk_emptyDocuments;
    private Telerik.WinControls.UI.RadGroupBox grp_emptyDocuments;
    private Telerik.WinControls.UI.RadListView list_emptyDocuments;
    private Telerik.WinControls.UI.RadLabel radLabel3;
  }
}