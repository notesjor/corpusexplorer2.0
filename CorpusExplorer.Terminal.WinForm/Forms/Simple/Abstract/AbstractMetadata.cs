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
      ButtonOkClick += MetadataSingle_ButtonOkClick;
    }

    protected AbstractMetadata(Dictionary<string, object> documentMetadata, Project project = null) : this(project)
    {
      RefreshMetadata(documentMetadata);
    }

    public Dictionary<string, object> DocumentMetadata { get; set; }

    public event EventHandler NewProperty;

    protected void RefreshMetadata(Dictionary<string, object> documentMetadata)
    {
      if (_editor != null)
        _editor.Metadata = DocumentMetadata;
      DocumentMetadata = documentMetadata;
    }

    protected void RegisterMetadataEditor(MetadataEditor editor)
    {
      _editor = editor;
      if (_editor != null)
        _editor.NewProperty += MetadataEditor1_NewProperty;
    }

    private void MetadataEditor1_NewProperty(object sender, EventArgs e)
    {
      if (NewProperty == null)
        return;

      NewProperty(sender, null);
      if (_editor != null)
        _editor.Metadata = DocumentMetadata;
    }

    private void MetadataSingle_ButtonOkClick(object sender, EventArgs e)
    {
      if (_editor != null)
        DocumentMetadata = _editor.Metadata;
    }
  }
}