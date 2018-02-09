#region

using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel.Abstract;

#endregion

namespace CorpusExplorer.Sdk.ViewModel
{
  public class ExplorationViewModel : AbstractViewModel
  {
    public ExplorationViewModel()
    {
      SignificanceMinimum = 1.0d;
      GetLimit = 100;
    }

    // public Dictionary<string, Dictionary<string, double>> CooccurrencesFrequency { get; set; }

    private Dictionary<string, Dictionary<string, double>> CollocatesSignificance { get; set; }

    public IEnumerable<string> DocumentMetadataProperties { get; set; }
    public int GetLimit { get; set; }
    public double SignificanceMinimum { get; set; }

    protected override void ExecuteAnalyse()
    {
      var block1 = Selection.CreateBlock<CooccurrenceBlock>();
      block1.Calculate();

      CollocatesSignificance = block1.CooccurrenceSignificance.CompleteDictionaryToFullDictionary();
      DocumentMetadataProperties = Selection.GetDocumentMetadataPrototypeOnlyProperties();
    }

    public IEnumerable<KeyValuePair<string, double>> GetCollocates(string query)
    {
      if (!CollocatesSignificance.ContainsKey(query))
        return new Dictionary<string, double>();

      return CollocatesSignificance[query].Where(x => x.Value > SignificanceMinimum)
                                          .OrderByDescending(x => x.Value)
                                          .Take(GetLimit);
    }

    public IEnumerable<string> GetFulltext(string query, int sentenceSpanPre = 0, int sentenceSpanPost = 0)
    {
      var block = Selection.CreateBlock<TextLiveSearchBlock>();
      block.LayerQueries = new[]
      {
        new FilterQuerySingleLayerAllInSpanSentences
        {
          LayerDisplayname = "Wort",
          LayerQueries = new[] {query}
        }
      };
      block.Calculate();

      if (block.SearchResults == null)
        return new string[0];

      var res = new Dictionary<string, int>();

      foreach (var c in block.SearchResults)
      {
        var corpus = Selection.GetCorpus(c.Key);
        if (corpus == null)
          continue;

        foreach (var doc in c.Value)
        {
          if (doc.Value == null ||
              doc.Value.Count == 0)
            continue;

          var indices = doc.Value.Select(x => x.Key).ToArray();
          var count = doc.Value.SelectMany(x => x.Value).Count();
          var min = indices.Min() - sentenceSpanPre;
          var max = indices.Max() + sentenceSpanPost;

          res.Add(
            corpus.GetReadableDocumentSnippet(doc.Key, "Wort", min, max).ReduceDocumentToText(),
            count);
        }
      }

      return res.OrderByDescending(x => x.Value).Take(GetLimit).Select(x => x.Key);
    }

    public IEnumerable<string> GetMetadata(string query, string metaLabel)
    {
      var block = Selection.CreateBlock<TextLiveSearchBlock>();
      block.LayerQueries = new[]
      {
        new FilterQuerySingleLayerAllInSpanSentences
        {
          LayerDisplayname = "Wort",
          LayerQueries = new[] {query}
        }
      };
      block.Calculate();

      if (block.SearchResults == null)
        return new string[0];

      var res = new Dictionary<string, int>();
      foreach (var key in from c in block.SearchResults
                          let corpus = Selection.GetCorpus(c.Key)
                          where corpus != null
                          from doc in c.Value
                          select corpus.GetDocumentMetadata(doc.Key)
                          into meta
                          where meta != null && meta.ContainsKey(metaLabel)
                          select GetMetadata_GetKey(metaLabel, meta))
        if (res.ContainsKey(key))
          res[key]++;
        else
          res.Add(key, 1);

      return res.OrderByDescending(x => x.Value).Take(GetLimit).Select(x => x.Key);
    }

    private static string GetMetadata_GetKey(string metaLabel, Dictionary<string, object> meta)
    {
      var key = "";

      try
      {
        var entry = meta[metaLabel];

        if (entry is DateTime)
          key = ((DateTime) entry).ToString("yyyy-MM-dd");
        else
          key = entry.ToString();
      }
      catch
      {
        // ignore
      }
      return key;
    }

    protected override bool Validate() { return true; }
  }
}