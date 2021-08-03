using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.NamedEntityRecognition;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class NamedEntityDetectionViewModel : AbstractViewModel, IProvideDataTable
  {
    public Blocks.NamedEntityRecognition.NamedEntityRecognitionModel Model { get; set; }

    public Dictionary<Entity, HashSet<Guid>> DetectedEntities { get; set; }

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add("Entität", typeof(string));
      dt.Columns.Add(Resources.Frequency, typeof(double));

      dt.BeginLoadData();

      foreach (var entity in DetectedEntities)
        dt.Rows.Add(entity.Key.Name, (double) entity.Value.Count);

      dt.EndLoadData();

      return dt;
    }

    public DataTable GetKwicDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add("Entität", typeof(string));
      dt.Columns.Add("DocumentID", typeof(Guid));
      dt.Columns.Add("SentenceID", typeof(int));
      dt.Columns.Add("Match", typeof(string));

      dt.BeginLoadData();
      foreach (var ent in DetectedEntities)
      {
        var tmp = GetEntityEntriesWithFulltext(ent);
        foreach (var tuple in tmp)
          dt.Rows.Add(ent.Key.Name, tuple.Item1, tuple.Item2, tuple.Item3);
      }

      dt.EndLoadData();

      return dt;
    }

    public IEnumerable<Tuple<Guid, int>> GetEntityEntries(string entity)
    {
      var e = GetDetectedEntityByName(entity);
      return e == null ? null : GetEntityEntries(e.Value);
    }

    private List<Tuple<Guid, int>> GetEntityEntries(KeyValuePair<Entity, HashSet<Guid>> ent)
    {
      var res = new List<Tuple<Guid, int>>();
      foreach (var dsel in ent.Value)
      {
        var top = Selection.CreateTemporary(new[] {dsel});

        var sent = new HashSet<int>();
        foreach (var rule in ent.Key.Rules)
          try
          {
            var matches = top.CreateTemporary(new[] {rule.Filter}).GetSelectedSentences()?.FirstOrDefault();
            if (matches == null)
              continue;

            foreach (var s in matches.Value.Value)
              sent.Add(s);
          }
          catch
          {
            //ignore
          }

        foreach (var s in sent)
          res.Add(new Tuple<Guid, int>(dsel, s));
      }

      return res;
    }

    public IEnumerable<Tuple<Guid, int, string>> GetEntityEntriesWithFulltext(string entity)
    {
      var e = GetDetectedEntityByName(entity);
      return e == null ? null : GetEntityEntriesWithFulltext(e.Value);
    }

    private List<Tuple<Guid, int, string>> GetEntityEntriesWithFulltext(KeyValuePair<Entity, HashSet<Guid>> ent)
    {
      var tmp = GetEntityEntries(ent);
      var res = new List<Tuple<Guid, int, string>>();

      foreach (var x in tmp)
        res.Add(new Tuple<Guid, int, string>(x.Item1, x.Item2,
                                             Selection.GetReadableDocumentSnippet(x.Item1, "Wort", x.Item2, x.Item2)
                                                      .ReduceDocumentToText()));

      return res;
    }

    public KeyValuePair<Entity, HashSet<Guid>>? GetDetectedEntityByName(string entityName)
    {
      return (from x in DetectedEntities where x.Key.Name == entityName select x).FirstOrDefault();
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<NamedEntityRecognitionBlock>();
      block.Model = Model;
      block.Calculate();

      DetectedEntities = block.DetectedEntities;
    }

    protected override bool Validate()
    {
      return true;
    }
  }
}