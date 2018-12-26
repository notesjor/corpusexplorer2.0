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
      resources.ApplyResources(this.radPanel1, "radPanel1");
      // 
      // ihdPanel1
      // 
      this.ihdPanel1.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.ihdPanel1, "ihdPanel1");
      this.ihdPanel1.IHDDescription = "Im Folgenden werden alle Probleme inkl. Lösungsmöglichkeit aufgelistet.";
      this.ihdPanel1.IHDHeader = "Kein Grund zur Panik...";
      this.ihdPanel1.IHDImage = global::CorpusExplorer.Terminal.WinForm.Properties.Resources.cabinet_warn1;
      this.ihdPanel1.Name = "ihdPanel1";
      // 
      // radPageView1
      // 
      this.radPageView1.Controls.Add(this.page_sentenceError);
      this.radPageView1.Controls.Add(this.page_diffLayer);
      this.radPageView1.Controls.Add(this.page_emptyDocument);
      resources.ApplyResources(this.radPageView1, "radPageView1");
      this.radPageView1.ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
      this.radPageView1.Name = "radPageView1";
      this.radPageView1.SelectedPage = this.page_diffLayer;
      this.radPageView1.ViewMode = Telerik.WinControls.UI.PageViewMode.Stack;
      // 
      // page_sentenceError
      // 
      this.page_sentenceError.Controls.Add(this.grp_senteceError);
      this.page_sentenceError.Controls.Add(this.chk_senteceError);
      this.page_sentenceError.Controls.Add(this.radLabel1);
      this.page_sentenceError.ItemSize = new System.Drawing.SizeF(526F, 31F);
      resources.ApplyResources(this.page_sentenceError, "page_sentenceError");
      this.page_sentenceError.Name = "page_sentenceError";
      // 
      // grp_senteceError
      // 
      this.grp_senteceError.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.grp_senteceError.Controls.Add(this.list_senteceError);
      resources.ApplyResources(this.grp_senteceError, "grp_senteceError");
      this.grp_senteceError.Name = "grp_senteceError";
      // 
      // list_senteceError
      // 
      resources.ApplyResources(this.list_senteceError, "list_senteceError");
      this.list_senteceError.GroupItemSize = new System.Drawing.Size(200, 40);
      this.list_senteceError.ItemSize = new System.Drawing.Size(200, 40);
      this.list_senteceError.Name = "list_senteceError";
      // 
      // chk_senteceError
      // 
      resources.ApplyResources(this.chk_senteceError, "chk_senteceError");
      this.chk_senteceError.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chk_senteceError.Name = "chk_senteceError";
      this.chk_senteceError.TextWrap = true;
      this.chk_senteceError.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
      ((Telerik.WinControls.UI.RadCheckBoxElement)(this.chk_senteceError.GetChildAt(0))).ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
      ((Telerik.WinControls.UI.RadCheckBoxElement)(this.chk_senteceError.GetChildAt(0))).Text = resources.GetString("resource.Text");
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_senteceError.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).TextWrap = ((bool)(resources.GetObject("resource.TextWrap")));
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_senteceError.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_senteceError.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 10F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_senteceError.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment")));
      // 
      // radLabel1
      // 
      resources.ApplyResources(this.radLabel1, "radLabel1");
      this.radLabel1.Name = "radLabel1";
      // 
      // page_diffLayer
      // 
      this.page_diffLayer.Controls.Add(this.grp_DiffLayer);
      this.page_diffLayer.Controls.Add(this.chk_DiffLayer);
      this.page_diffLayer.Controls.Add(this.radLabel2);
      this.page_diffLayer.ItemSize = new System.Drawing.SizeF(526F, 31F);
      resources.ApplyResources(this.page_diffLayer, "page_diffLayer");
      this.page_diffLayer.Name = "page_diffLayer";
      // 
      // grp_DiffLayer
      // 
      this.grp_DiffLayer.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.grp_DiffLayer.Controls.Add(this.list_DiffLayer);
      resources.ApplyResources(this.grp_DiffLayer, "grp_DiffLayer");
      this.grp_DiffLayer.Name = "grp_DiffLayer";
      // 
      // list_DiffLayer
      // 
      resources.ApplyResources(this.list_DiffLayer, "list_DiffLayer");
      this.list_DiffLayer.GroupItemSize = new System.Drawing.Size(200, 40);
      this.list_DiffLayer.ItemSize = new System.Drawing.Size(200, 40);
      this.list_DiffLayer.Name = "list_DiffLayer";
      // 
      // chk_DiffLayer
      // 
      resources.ApplyResources(this.chk_DiffLayer, "chk_DiffLayer");
      this.chk_DiffLayer.Name = "chk_DiffLayer";
      this.chk_DiffLayer.TextWrap = true;
      ((Telerik.WinControls.UI.RadCheckBoxElement)(this.chk_DiffLayer.GetChildAt(0))).Text = resources.GetString("resource.Text1");
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_DiffLayer.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).TextWrap = ((bool)(resources.GetObject("resource.TextWrap1")));
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_DiffLayer.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_DiffLayer.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 10F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_DiffLayer.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment1")));
      // 
      // radLabel2
      // 
      resources.ApplyResources(this.radLabel2, "radLabel2");
      this.radLabel2.Name = "radLabel2";
      // 
      // page_emptyDocument
      // 
      this.page_emptyDocument.Controls.Add(this.grp_emptyDocuments);
      this.page_emptyDocument.Controls.Add(this.chk_emptyDocuments);
      this.page_emptyDocument.Controls.Add(this.radLabel3);
      this.page_emptyDocument.ItemSize = new System.Drawing.SizeF(526F, 31F);
      resources.ApplyResources(this.page_emptyDocument, "page_emptyDocument");
      this.page_emptyDocument.Name = "page_emptyDocument";
      // 
      // grp_emptyDocuments
      // 
      this.grp_emptyDocuments.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
      this.grp_emptyDocuments.Controls.Add(this.list_emptyDocuments);
      resources.ApplyResources(this.grp_emptyDocuments, "grp_emptyDocuments");
      this.grp_emptyDocuments.Name = "grp_emptyDocuments";
      // 
      // list_emptyDocuments
      // 
      resources.ApplyResources(this.list_emptyDocuments, "list_emptyDocuments");
      this.list_emptyDocuments.GroupItemSize = new System.Drawing.Size(200, 40);
      this.list_emptyDocuments.ItemSize = new System.Drawing.Size(200, 40);
      this.list_emptyDocuments.Name = "list_emptyDocuments";
      // 
      // chk_emptyDocuments
      // 
      resources.ApplyResources(this.chk_emptyDocuments, "chk_emptyDocuments");
      this.chk_emptyDocuments.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chk_emptyDocuments.Name = "chk_emptyDocuments";
      this.chk_emptyDocuments.TextWrap = true;
      this.chk_emptyDocuments.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
      ((Telerik.WinControls.UI.RadCheckBoxElement)(this.chk_emptyDocuments.GetChildAt(0))).ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
      ((Telerik.WinControls.UI.RadCheckBoxElement)(this.chk_emptyDocuments.GetChildAt(0))).Text = resources.GetString("resource.Text2");
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_emptyDocuments.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).TextWrap = ((bool)(resources.GetObject("resource.TextWrap2")));
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_emptyDocuments.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).LineLimit = true;
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_emptyDocuments.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 10F);
      ((Telerik.WinControls.Primitives.TextPrimitive)(this.chk_emptyDocuments.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment2")));
      // 
      // radLabel3
      // 
      resources.ApplyResources(this.radLabel3, "radLabel3");
      this.radLabel3.Name = "radLabel3";
      // 
      // CorpusErrorForm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.radPageView1);
      this.Controls.Add(this.ihdPanel1);
      this.DisplayAbort = true;
      this.Name = "CorpusErrorForm";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
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