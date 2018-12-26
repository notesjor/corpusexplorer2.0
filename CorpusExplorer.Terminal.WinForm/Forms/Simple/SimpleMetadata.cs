#region

using System.Collections.Generic;
using CorpusExplorer.Terminal.WinForm.Forms.Simple.Abstract;

#endregion

namespace CorpusExplorer.Terminal.WinForm.Forms.Simple
{
  public partial class SimpleMetadata : AbstractMetadata
  {
    public SimpleMetadata(Dictionary<string, object> documentMetadata)
      : base(documentMetadata)
    {
      InitializeComponent();
      RegisterMetadataEditor(metadataEditor1);
      if (documentMetadata == null)
        return;
      metadataEditor1.Metadata = documentMetadata;
    }
  }
}