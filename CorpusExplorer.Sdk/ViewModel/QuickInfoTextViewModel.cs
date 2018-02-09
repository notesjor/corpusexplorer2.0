using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.QuickInfoText;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class QuickInfoTextViewModel : AbstractViewModel
  {
    public QuickInfoTextViewModel() { LayerDisplayname = "Wort"; }

    public IEnumerable<KeyValuePair<Guid, int>> Documents { get; set; }

    public string LayerDisplayname { get; set; }

    public IEnumerable<QuickInfoTextResult> QuickDocumentInfoResults { get; set; }

    protected override void ExecuteAnalyse()
    {
      var res = new Dictionary<Guid, QuickInfoTextResult>();
      foreach (var d in Documents)
        if (res.ContainsKey(d.Key))
          res[d.Key].HighlightedSentences.Add(d.Value);
        else
          res.Add(
            d.Key,
            new QuickInfoTextResult
            {
              DocumentGuid = d.Key,
              DocumentMetadata = Selection.GetDocumentMetadata(d.Key),
              HighlightedSentences = new HashSet<int> {d.Value},
              Text = Selection.GetReadableDocument(d.Key, LayerDisplayname)
            });
      QuickDocumentInfoResults = res.Values;
    }

    public void SetNewDocumentMetadata(KeyValuePair<string, Type> property)
    {
      Selection.Project.SetNewDocumentMetadata(property.Key, property.Value);
    }

    protected override bool Validate() { return !string.IsNullOrEmpty(LayerDisplayname) && Documents != null; }
  }
}