#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.Similarity;
using CorpusExplorer.Sdk.Blocks.Similarity.Abstract;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

#endregion

namespace CorpusExplorer.Sdk.ViewModel
{
  /// <summary>
  ///   The similarity view model.
  /// </summary>
  public class DocumentSimilarityViewModel : AbstractViewModel, IUseSpecificLayer
  {
    private DocumentSimilarityBlock _block;

    public IEnumerable<Guid> DocumentGuids { get; set; }

    public Dictionary<Guid, string> DocumentGuidsMappedToMetaProperty
    {
      get
      {
        var res = new Dictionary<Guid, string>();
        foreach (var guid in DocumentGuids)
        {
          var meta = Selection.GetDocumentMetadata(guid);
          if (meta != null &&
              meta.ContainsKey(SelectedDocumentMetaProperty))
            res.Add(guid, meta[SelectedDocumentMetaProperty].ToString());
        }
        return res;
      }
    }

    public IEnumerable<string> DocumentMetaProperties => Selection.GetDocumentMetadataPrototypeOnlyProperties();

    public double MinimumDocumentSimilarity { get; set; } = 0.8d;
    public double MinimumInversDocumentFrequency { get; set; } = 0.003d;
    public string SelectedDocumentMetaProperty { get; set; }
    public AbstractSimilarity SimilarityMeasure { get; set; } = new CosineMesure();

    public IEnumerable<string> LayerDisplaynames => Selection.LayerUniqueDisplaynames;

    public string LayerDisplayname { get; set; } = "Wort";

    protected override void ExecuteAnalyse()
    {
      _block = Selection.CreateBlock<DocumentSimilarityBlock>();
      _block.Similarity = SimilarityMeasure;
      _block.LayerDisplayname = LayerDisplayname;
      _block.MinimumInversDocumentFrequency = MinimumInversDocumentFrequency;
      _block.MinimumDocumentSimilarity = MinimumDocumentSimilarity;
      _block.Calculate();

      DocumentGuids = _block.DocumentGuids;
    }

    public IEnumerable<Guid> RequestDocumentGuidByMetadata(string metaValue)
    {
      return _block.RequestDocumentGuidByMetadata(SelectedDocumentMetaProperty, metaValue);
    }

    public Dictionary<string, double> RequestDocumentSimilarity(Guid guid)
    {
      if (_block == null)
        return null;

      var req = _block.RequestDocumentSimilarity(guid);
      var res = new Dictionary<string, double>();

      foreach (var x in req)
        if (string.IsNullOrEmpty(SelectedDocumentMetaProperty))
        {
          res.Add(Selection.GetDocumentDisplayname(x.Key), x.Value);
        }
        else
        {
          var meta = Selection.GetDocumentMetadata(x.Key);
          res.Add(
            meta == null || !meta.ContainsKey(SelectedDocumentMetaProperty)
              ? "- KEIN WERT -"
              : meta[SelectedDocumentMetaProperty].ToString(),
            x.Value);
        }

      return res;
    }

    public Dictionary<string, double> RequestMetadataSimilarity(string metaValue)
    {
      return RequestMetadataSimilarity(SelectedDocumentMetaProperty, metaValue);
    }

    public Dictionary<string, double> RequestMetadataSimilarity(string metaName, string metaValue)
    {
      return _block.RequestMetaclusterSimilarity(metaName, metaValue);
    }

    public IEnumerable<string> RequestMetadataSimilarityValues()
    {
      return RequestMetadataSimilarityValues(SelectedDocumentMetaProperty);
    }

    public IEnumerable<string> RequestMetadataSimilarityValues(string metaName)
    {
      var values = Selection.GetDocumentMetadataPrototype();
      return values.ContainsKey(metaName) ? values[metaName].Select(obj => obj?.ToString() ?? "") : null;
    }

    protected override bool Validate() { return MinimumInversDocumentFrequency > 0 && SimilarityMeasure != null; }
  }
}