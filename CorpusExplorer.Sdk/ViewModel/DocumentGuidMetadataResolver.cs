#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;

#endregion

namespace CorpusExplorer.Sdk.ViewModel
{
  [Serializable]
  public class DocumentGuidMetadataResolver : AbstractViewModel
  {
    public DocumentGuidMetadataResolver() { SelectedProperty = Resources.Title; }

    public IEnumerable<string> AvailabelProperties => Selection.GetDocumentMetadataPrototypeOnlyProperties();

    public string SelectedProperty { get; set; }

    protected override void ExecuteAnalyse() { }

    public string ResolveMetadata(Guid documentGuid)
    {
      var meta = Selection.GetDocumentMetadata(documentGuid);

      return meta.ContainsKey(SelectedProperty) ? meta[SelectedProperty].ToString() : documentGuid.ToString();
    }

    protected override bool Validate()
    {
      return Selection != null && AvailabelProperties != null && AvailabelProperties.Any() &&
             !string.IsNullOrEmpty(SelectedProperty);
    }
  }
}