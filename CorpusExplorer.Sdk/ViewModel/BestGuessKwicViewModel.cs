using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Utils.Filter;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class BestGuessKwicViewModel : AbstractViewModel, IUseSpecificLayer
  {
    private CooccurrenceBlock _cooc = null;

    protected override void ExecuteAnalyse()
    {
      if (_cooc == null || _cooc.LayerDisplayname != LayerDisplayname)
      {
        _cooc = Selection.CreateBlock<CooccurrenceBlock>();
        _cooc.LayerDisplayname = LayerDisplayname;
        _cooc.Calculate();
      }

      var matches = QuickQuery.SearchOnSentenceLevel(Selection, 
        new FilterQuerySingleLayerAnyMatch
        {
          LayerDisplayname = LayerDisplayname,
          LayerQueries = new[] { LayerQuey }
        });

      var list = (from csel in matches
                  from dsel in csel.Value
                  from sidx in dsel.Value
                  select new BestGuessKwic
                  {
                    DocumentGuid = dsel.Key,
                    SentenceId = sidx,
                    Tokens = Selection.GetReadableDocumentSnippet(dsel.Key, LayerDisplayname, sidx, sidx + 1)
                                      .First()
                                      .ToArray()
                  }).ToList();

      var cooc = _cooc.SearchCooccurrence(LayerQuey);
      var done = new Dictionary<string, double>();

      BestGuessGroups = new List<BestGuessKwic[]>();

      while (list.Count > 0 && cooc.Count > 0)
      {
        // RANK
        var best = new BestGuessKwic { Rank = 0 }; // Dummyvalue - wird direkt überschrieben
        foreach (var x in list)
        {
          x.Rank = cooc.Where(c => x.UniqueTokens.Contains(c.Key)).Sum(c => c.Value);
          if (x.Rank > best.Rank)
            best = x;
        }

        // Erstelle Gruppe
        var group = new List<BestGuessKwic> { best };
        list.Remove(best);

        // Kookkurrenzen umbuchen
        var keys = cooc.Keys.ToArray();
        foreach (var x in keys)
        {
          if (!best.UniqueTokens.Contains(x)) 
            continue;

          done.Add(x, cooc[x]);
          cooc.Remove(x);
        }

        // Gruppenzuordnung (wenn rank >= alter Wert)
        var arr = list.ToArray();
        foreach (var x in arr)
        {
          var rank = done.Where(c => x.UniqueTokens.Contains(c.Key)).Sum(c => c.Value);
          if (rank < x.Rank) 
            continue;

          x.Rank = rank;
          list.Remove(x);
          group.Add(x);
        }

        BestGuessGroups.Add(group.ToArray());
      }

      if (list.Count > 0)
        BestGuessGroups.Add(list.ToArray());
    }

    public List<BestGuessKwic[]> BestGuessGroups { get; set; }

    public class BestGuessKwic
    {
      private string[] tokens;
      public Guid DocumentGuid { get; set; }
      public int SentenceId { get; set; }
      public HashSet<string> UniqueTokens { get; set; }

      public string[] Tokens
      {
        get => tokens;
        set
        {
          tokens = value;
          UniqueTokens = new HashSet<string>(value);
        }
      }

      public string GetText(string tokenSeparator = " ")
        => string.Join(tokenSeparator, Tokens);

      public double Rank { get; set; }
    }

    protected override bool Validate() => !string.IsNullOrWhiteSpace(LayerDisplayname) && !string.IsNullOrWhiteSpace(LayerQuey);

    public string LayerDisplayname { get; set; }

    public string LayerQuey { get; set; }
  }
}
