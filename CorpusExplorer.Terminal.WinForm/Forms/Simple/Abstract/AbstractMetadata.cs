#region

using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Terminal.WinForm.Controls.WinForm;
using CorpusExplorer.Terminal.WinForm.Forms.Abstract;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Forms.Simple.Abstract
{
  public partial class AbstractMetadata : AbstractDialog
  {
    private MetadataEditor _editor;

    protected AbstractMetadata()
    {
      InitializeComponent();
    }

    protected AbstractMetadata(Project project) : base(project)
    {
      InitializeComponent();
      _editor.NewProperty += MetadataEditor1_NewProperty;
      ButtonOkClick += MetadataSingle_ButtonOkClick;
    }

    protected AbstractMetadata(Dictionary<string, object> documentMetadata, Project project = null) : this(project)
    {
      RefreshMetadata(documentMetadata);
    }

    protected void RefreshMetadata(Dictionary<string, object> documentMetadata)
    {
      _editor.Metadata = DocumentMetadata;
      DocumentMetadata = documentMetadata;
    }

    public Dictionary<string, object> DocumentMetadata { get; set; }

    private void MetadataEditor1_NewProperty(object sender, EventArgs e)
    {
      if (NewProperty == null)
        return;

      NewProperty(sender, null);
      _editor.Metadata = DocumentMetadata;
    }

    private void MetadataSingle_ButtonOkClick(object sender, EventArgs e) { DocumentMetadata = _editor.Metadata; }
    
    public event EventHandler NewProperty;

    protected void RegisterMetadataEditor(MetadataEditor editor) { _editor = editor; }
  }
}