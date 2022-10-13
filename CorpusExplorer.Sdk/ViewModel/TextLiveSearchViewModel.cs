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

    public int AddContextSentencesPre { get; set; } = 0;
    public int AddContextSentencesPost { get; set; } = 0;

    public IEnumerable<string> PureKwicSentences => SearchResults == null
                                                      ? null
                                                      : from corpus in SearchResults
                                                        from result in corpus.Value
                                                        from sent in result.Value
                                                        select Selection
                                                              .GetReadableDocumentSnippet(
                                                                                          result.Key,
                                                                                          "Wort",
                                                                                          sent.Key,
                                                                                          sent.Key)
                                                             ?.ReduceDocumentToText();

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

            var streamDoc = Selection.GetReadableDocumentSnippet(result.Key, "Wort", sent.Key, sent.Key)
                                     .ReduceDocumentToStreamDocument().ToArray();
            var min = sent.Value.Min();
            var max = sent.Value.Max();

            res.Add(new Tuple<Guid, Guid, int, string, string, string>
                      (
                       corpus.Key,
                       result.Key,
                       sent.Key,
                       $"{GetAddContextSentencesPre(result.Key, sent.Key)} {streamDoc.SplitDocument(0, min)}".Trim(), 
                       streamDoc.SplitDocument(min, max + 1),
                       $"{streamDoc.SplitDocument(max + 1)} {GetAddContextSentencesPost(result.Key, sent.Key)}".Trim()
                      ));
          }

      return res;
    }

    private string GetAddContextSentencesPost(Guid resultKey, int sentKey)
      => AddContextSentencesPost < 1
        ? ""
        : Selection.GetReadableDocumentSnippet(resultKey, "Wort", sentKey + 1, sentKey + AddContextSentencesPost)
          .ReduceDocumentToText(sentenceSeparator: " ");

    private string GetAddContextSentencesPre(Guid resultKey, int sentKey)
      => AddContextSentencesPre < 1
        ? ""
        : Selection.GetReadableDocumentSnippet(resultKey, "Wort", sentKey - AddContextSentencesPre, sentKey - 1)
          .ReduceDocumentToText(sentenceSeparator: " ");

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

      if (SearchResults == null)
        return res.Values;

      foreach (var corpus in SearchResults)
        foreach (var result in corpus.Value)
          foreach (var sent in result.Value)
          {
            if (sent.Value == null || sent.Value.Count == 0)
              continue;

            var streamDoc = Selection.GetReadableDocumentSnippet(result.Key, "Wort", sent.Key, sent.Key)
                                     .ReduceDocumentToStreamDocument().ToArray();
            var key = string.Join("|", streamDoc);
            if (!res.ContainsKey(key))
            {
              var min = sent.Value.Min();
              var max = sent.Value.Max();

              res.Add(
                      key,
                      new UniqueTextLiveSearchResultEntry
                      {
                        Pre = $"{GetAddContextSentencesPre(result.Key, sent.Key)} {streamDoc.SplitDocument(0, min)}".Trim(),
                        Match = streamDoc.SplitDocument(min, max + 1),
                        Post = $"{streamDoc.SplitDocument(max + 1)} {GetAddContextSentencesPost(result.Key, sent.Key)}".Trim()
                      });
            }

            res[key].AddSentence(result.Key, sent.Key);
          }

      return res.Values;
    }

    public IEnumerable<UniqueTextLiveSearchCutOffPhraseResultEntry> GetUniqueCutOffPhraseData()
    {
      var res = new Dictionary<string, UniqueTextLiveSearchCutOffPhraseResultEntry>();
      foreach (var corpus in SearchResults)
        foreach (var result in corpus.Value)
          foreach (var sent in result.Value)
          {
            if (sent.Value == null || sent.Value.Count == 0)
              continue;

            var streamDoc = Selection.GetReadableDocumentSnippet(result.Key, "Wort", sent.Key, sent.Key)
                                     .ReduceDocumentToStreamDocument().ToArray();

            var key = string.Join("|", streamDoc);
            if (!res.ContainsKey(key))
            {
              var min = sent.Value.Min();
              var max = sent.Value.Max();
              res.Add(
                      key,
                      new UniqueTextLiveSearchCutOffPhraseResultEntry
                      {
                        Pre = $"{GetAddContextSentencesPre(result.Key, sent.Key)} {streamDoc.SplitDocument(0, min)}".Trim(),
                        Match = streamDoc.SplitDocument(min, max + 1),
                        Post = $"{streamDoc.SplitDocument(max + 1)} {GetAddContextSentencesPost(result.Key, sent.Key)}".Trim(),
                        Span = max - min - 2,
                      });
            }

            res[key].AddSentence(result.Key, sent.Key);
          }

      return res.Values;
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

    public DataTable GetUniqueDataTableCutOffPhrase()
    {
      var dt = new DataTable();
      dt.Columns.Add("Pre", typeof(string));
      dt.Columns.Add("Match", typeof(string));
      dt.Columns.Add("Post", typeof(string));
      dt.Columns.Add("Spanne", typeof(int));
      dt.Columns.Add("Frequenz", typeof(int));
      dt.Columns.Add("Info", typeof(IEnumerable<KeyValuePair<Guid, int>>));

      var data = GetUniqueCutOffPhraseData();

      dt.BeginLoadData();
      foreach (var d in data)
        dt.Rows.Add(d.Pre, d.Match, d.Post, d.Span, d.Count, d.Sentences);
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
    }

    protected override bool Validate()
    {
      return _queries != null && _queries.Count > 0;
    }
  }
}