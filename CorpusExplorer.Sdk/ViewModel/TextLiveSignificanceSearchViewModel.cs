using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Interface;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;
using CorpusExplorer.Sdk.ViewModel.TextLiveSearch;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class TextLiveSignificanceSearchViewModel : AbstractViewModel, IProvideDataTable
  {
    private readonly Dictionary<Guid, AbstractFilterQuery> _queries = new Dictionary<Guid, AbstractFilterQuery>();
    private Dictionary<string, double> _highlightCache;

    public string LayerDisplayname { get; set; } = "Wort";

    public string HighlightStart { get; set; } = "<strong>";
    public string HighlightEnd { get; set; } = "</strong>";
    public string HighlightBodyStart { get; set; } = "<html>";
    public string HighlightBodyEnd { get; set; } = "</html>";

    public IEnumerable<KeyValuePair<Guid, AbstractFilterQuery>> Queries => _queries;

    public Selection ResultSelection { get; set; }

    public Dictionary<Guid, Dictionary<Guid, Dictionary<int, HashSet<CeRange>>>> SearchResults { get; private set; }

    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add("Pre", typeof(string));
      dt.Columns.Add("Match", typeof(string));
      dt.Columns.Add("Post", typeof(string));
      dt.Columns.Add("Frequenz", typeof(int));
      dt.Columns.Add("Token", typeof(int));
      dt.Columns.Add("Co-occurrences", typeof(string));
      dt.Columns.Add("SigToken", typeof(int));
      dt.Columns.Add("SigMax", typeof(double));
      dt.Columns.Add("SigSum", typeof(double));
      dt.Columns.Add("SigMed", typeof(double));
      dt.Columns.Add("SigRank", typeof(double));
      dt.Columns.Add("CorpusGuid", typeof(string));
      dt.Columns.Add("DocumentGuid", typeof(string));

      var data = GetUniqueData();

      dt.BeginLoadData();
      foreach (var d in data)
        dt.Rows.Add(d.Pre, d.Match, d.Post, d.Count, d.Token, string.Join(" | ", d.FoundCooccurrences), d.SignificantToken, d.SignificanceMax, d.SignificanceSum,
                    d.SignificanceMed, d.SignificanceRank, d.CorpusGuid.ToString("N"), d.DocumentGuid.ToString("N"));
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

    public IEnumerable<SignificanceExtendedUniqueTextLiveSearchResultEntry> GetUniqueData()
    {
      var res = new Dictionary<string, SignificanceExtendedUniqueTextLiveSearchResultEntry>();
      foreach (var corpus in SearchResults)
        foreach (var document in corpus.Value)
          foreach (var sent in document.Value.Where(sent => sent.Value != null && sent.Value.Count != 0))
          {
            var streamDoc =
              RunHighlighting(Selection.GetReadableDocumentSnippet(document.Key, "Wort", sent.Key, sent.Key).ReduceDocumentToStreamDocument().ToArray(),
                              out var token, out var stoken, out var sigMax, out var sigSum, out var sigMed, out var cooc);

            var key = string.Join("|", streamDoc);
            if (!res.ContainsKey(key))
              foreach (var range in sent.Value)
              {
                res.Add(
                        key,
                        new SignificanceExtendedUniqueTextLiveSearchResultEntry
                        {
                          Pre = $"{HighlightBodyStart}{streamDoc.SplitDocument(0, range.To)}{HighlightBodyEnd}",
                          Match = $"{HighlightBodyStart}{streamDoc.SplitDocument(range.From, range.To)}{HighlightBodyEnd}",
                          Post = $"{HighlightBodyStart}{streamDoc.SplitDocument(range.To)}{HighlightBodyEnd}",
                          Token = token,
                          SignificantToken = stoken,
                          SignificanceMax = sigMax,
                          SignificanceSum = sigSum,
                          SignificanceMed = sigMed,
                          CorpusGuid = corpus.Key,
                          DocumentGuid = document.Key,
                          FoundCooccurrences = cooc
                        });
              }

            res[key].AddSentence(document.Key, sent.Key);
          }

      var sigTokenMax = res.Max(x => x.Value.SignificantToken);
      foreach (var x in res)
        try
        {
          x.Value.SignificanceRank =
            x.Value.SignificantToken / x.Value.Token +
            x.Value.SignificanceMed * (x.Value.SignificantToken / sigTokenMax) +
            x.Value.SignificanceSum * (x.Value.SignificantToken / sigTokenMax);
        }
        catch
        {
          x.Value.SignificanceRank = 0;
        }

      return res.Values;
    }

    private string[] RunHighlighting(string[] streamDoc, out int token, out int stoken, out double sigMax,
                                     out double sigSum, out double sigMed, out HashSet<string> cooc)
    {
      var res = new List<string>();
      cooc = new HashSet<string>(); // Verhindert Kookkurrenz-Mehrfachnennung UND gibt die gefunden Kookkurrenzen zurück
      var med = new List<double>();
      token = streamDoc.Length;
      sigMax = 0;
      sigSum = 0;

      foreach (var w in streamDoc)
      {
        string val;
        if (_highlightCache.ContainsKey(w))
        {
          val = $"{HighlightStart}{w}{HighlightEnd}";
          if (!cooc.Contains(w))
          {
            cooc.Add(w);
            var sig = _highlightCache[w];
            if (sig > sigMax)
              sigMax = sig;
            sigSum += sig;
            med.Add(sig);
          }
        }
        else
        {
          val = w;
        }

        res.Add(val);
      }

      stoken = cooc.Count;
      sigMed = med.Count == 0 ? 0 : med.GetMedian();
      return res.ToArray();
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