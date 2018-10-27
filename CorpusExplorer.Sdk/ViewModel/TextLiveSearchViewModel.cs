#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Interface;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;
using CorpusExplorer.Sdk.ViewModel.TextLiveSearch;

#endregion

namespace CorpusExplorer.Sdk.ViewModel
{
  public class TextLiveSearchViewModel : AbstractViewModel, IProvideDataTable
  {
    private readonly Dictionary<Guid, AbstractFilterQuery> _queries = new Dictionary<Guid, AbstractFilterQuery>();
    private Dictionary<string, double> _highlightCache;

    public string LayerDisplayname { get; set; } = "Wort";

    public bool EnableHighlighting { get; set; }
    public string HighlightStart { get; set; } = "<strong>";
    public string HighlightEnd { get; set; } = "</strong>";
    public string HighlightBodyStart { get; set; } = "<html>";
    public string HighlightBodyEnd { get; set; } = "</html>";

    public IEnumerable<string> PureKwicSentences => SearchResults == null
      ? null
      : (from corpus in SearchResults
         from result in corpus.Value
         from sent in result.Value
         select Selection
           .GetReadableDocumentSnippet(
             result.Key,
             "Wort",
             sent.Key,
             sent.Key)?.ReduceDocumentToText());

    public IEnumerable<KeyValuePair<Guid, AbstractFilterQuery>> Queries => _queries;

    public int ResultCountCorpora => SearchResults.Count;

    public int ResultCountDocuments
    {
      get { return SearchResults.Sum(x => x.Value.Count); }
    }

    public int ResultCountSentences
    {
      get { return SearchResults.SelectMany(x => x.Value).Sum(y => y.Value.Count); }
    }

    public int ResultCountWords => (from x in SearchResults from y in x.Value from z in y.Value select z.Value.Count)
      .Sum();

    public Selection ResultSelection { get; set; }

    public Dictionary<Guid, Dictionary<Guid, Dictionary<int, HashSet<int>>>> SearchResults { get; private set; }

    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add("CorpusID", typeof(Guid));
      dt.Columns.Add("DocumentID", typeof(Guid));
      dt.Columns.Add("SentenceID", typeof(int));
      dt.Columns.Add("Pre", typeof(string));
      dt.Columns.Add("Match", typeof(string));
      dt.Columns.Add("Post", typeof(string));

      var data = GetData();

      dt.BeginLoadData();
      foreach (var d in data)
        dt.Rows.Add(d.Item1, d.Item2, d.Item3, d.Item4, d.Item5, d.Item6);
      dt.EndLoadData();

      return dt;
    }

    public Guid AddQuery(AbstractFilterQuery query)
    {
      var res = Guid.NewGuid();
      _queries.Add(res, query);
      return res;
    }

    public void ClearQueries()
    {
      _queries.Clear();
    }

    public IEnumerable<Tuple<Guid, Guid, int, string, string, string>> GetData()
    {
      var res = new List<Tuple<Guid, Guid, int, string, string, string>>();
      foreach (var corpus in SearchResults)
        foreach (var result in corpus.Value)
          foreach (var sent in result.Value)
          {
            if (sent.Value == null || sent.Value.Count == 0)
              continue;

            var streamDoc = Selection.GetReadableDocumentSnippet(result.Key, "Wort", sent.Key, sent.Key).ReduceDocumentToStreamDocument().ToArray();
            if (EnableHighlighting)
              streamDoc = RunHighlighting(streamDoc);

            var min = sent.Value.Min();
            var max = sent.Value.Max();
            res.Add(new Tuple<Guid, Guid, int, string, string, string>
            (
              corpus.Key,
              result.Key,
              sent.Key,
              EnableHighlighting ? $"{HighlightBodyStart}{streamDoc.SplitDocument(0, min)}{HighlightBodyEnd}" : streamDoc.SplitDocument(0, min),
              EnableHighlighting ? $"{HighlightBodyStart}{streamDoc.SplitDocument(min, max + 1)}{HighlightBodyEnd}" : streamDoc.SplitDocument(min, max + 1),
              EnableHighlighting ? $"{HighlightBodyStart}{streamDoc.SplitDocument(max + 1)}{HighlightBodyEnd}" : streamDoc.SplitDocument(max + 1)
            ));
          }

      return res;
    }

    public string GetDocumentDisplayname(Guid key)
    {
      return Selection.GetDocumentDisplayname(key);
    }

    public IEnumerable<IEnumerable<string>> GetReadableDocumentSnippet(
      Guid documentGuid,
      string layerDisplayname,
      int start,
      int stop)
    {
      return Selection.GetReadableDocumentSnippet(documentGuid, layerDisplayname, start, stop);
    }

    public IEnumerable<UniqueTextLiveSearchResultEntry> GetUniqueData()
    {
      var res = new Dictionary<string, UniqueTextLiveSearchResultEntry>();
      foreach (var corpus in SearchResults)
        foreach (var result in corpus.Value)
          foreach (var sent in result.Value)
          {
            if (sent.Value == null || sent.Value.Count == 0)
              continue;

            var streamDoc = Selection.GetReadableDocumentSnippet(result.Key, "Wort", sent.Key, sent.Key).ReduceDocumentToStreamDocument().ToArray();
            if (EnableHighlighting)
              streamDoc = RunHighlighting(streamDoc);

            var key = string.Join("|", streamDoc);
            if (!res.ContainsKey(key))
            {
              var min = sent.Value.Min();
              var max = sent.Value.Max();
              res.Add(
                key,
                new UniqueTextLiveSearchResultEntry
                {
                  Pre = EnableHighlighting ? $"{HighlightBodyStart}{streamDoc.SplitDocument(0, min)}{HighlightBodyEnd}" : streamDoc.SplitDocument(0, min),
                  Match = EnableHighlighting ? $"{HighlightBodyStart}{streamDoc.SplitDocument(min, max + 1)}{HighlightBodyEnd}" : streamDoc.SplitDocument(min, max + 1),
                  Post = EnableHighlighting ? $"{HighlightBodyStart}{streamDoc.SplitDocument(max + 1)}{HighlightBodyEnd}" : streamDoc.SplitDocument(max + 1)
                });
            }

            res[key].AddSentence(result.Key, sent.Key);
          }

      return res.Values;
    }

    private string[] RunHighlighting(string[] streamDoc)
    {
      return streamDoc.Select(w => _highlightCache.ContainsKey(w) ? $"{HighlightStart}{w}{HighlightEnd}" : w).ToArray();
    }

    public DataTable GetUniqueDataTableGui()
    {
      var dt = new DataTable();
      dt.Columns.Add("Pre", typeof(string));
      dt.Columns.Add("Match", typeof(string));
      dt.Columns.Add("Post", typeof(string));
      dt.Columns.Add("Frequenz", typeof(int));
      dt.Columns.Add("Info", typeof(IEnumerable<KeyValuePair<Guid, int>>));

      var data = GetUniqueData();

      dt.BeginLoadData();
      foreach (var d in data)
        dt.Rows.Add(d.Pre, d.Match, d.Post, d.Count, d.Sentences);
      dt.EndLoadData();

      return dt;
    }

    public DataTable GetUniqueDataTableCsv()
    {
      var dt = new DataTable();
      dt.Columns.Add("Pre", typeof(string));
      dt.Columns.Add("Match", typeof(string));
      dt.Columns.Add("Post", typeof(string));
      dt.Columns.Add("Frequenz (-1 = copycat)", typeof(int));
      dt.Columns.Add("GUID", typeof(string));
      dt.Columns.Add("SatzID", typeof(int));

      var data = GetUniqueData();

      dt.BeginLoadData();
      foreach (var d in data)
      {
        var first = true;
        foreach (var s in d.Sentences)
        {
          dt.Rows.Add(d.Pre, d.Match, d.Post, first ? d.Count : -1, s.Key.ToString("N"), s.Value);
          first = false;
        }
      }
      dt.EndLoadData();

      return dt;
    }

    public bool RemoveQuery(Guid queryGuid)
    {
      return _queries.Remove(queryGuid);
    }

    /// <summary>
    ///   The analyse.
    /// </summary>
    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<TextLiveSearchBlock>();
      block.LayerQueries = Queries.Select(x => x.Value);
      block.Calculate();

      ResultSelection = block.ResultSelection;
      SearchResults = block.SearchResults;

      if (EnableHighlighting)
        BuildHighlightingCache();
    }

    private void BuildHighlightingCache()
    {
      var overlapping = new CooccurrenceOverlappingViewModel
      {
        Selection = Selection,
        LayerDisplayname = LayerDisplayname,
        LayerQueries = new HashSet<string>(Queries.Select(x => x.Value).OfType<IFilterQueryWithLayerValues>()
                                                  .SelectMany(x => x.LayerQueries))
      };
      overlapping.Execute();
      _highlightCache = overlapping.CooccurrenceSignificance;
    }

    protected override bool Validate()
    {
      return _queries != null && _queries.Count > 0;
    }
  }
}