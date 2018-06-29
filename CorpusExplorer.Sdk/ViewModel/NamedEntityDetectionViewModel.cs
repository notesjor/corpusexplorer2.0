using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class NamedEntityDetectionViewModel : AbstractViewModel, IProvideDataTable
  {
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
        dt.Rows.Add(entity.Key, entity.Value.Count);

      dt.EndLoadData();

      return dt;
    }

    public IEnumerable<Tuple<Guid, int>> GetEntityEntries(string entity)
      => (from doc in DetectedEntities[entity]
          from sen in doc.Value
          select new Tuple<Guid, int>(doc.Key, sen))
        .OrderBy(x => x.Item2);

    public IEnumerable<Tuple<Guid, int, string>> GetEntityEntriesWithFulltext(string entity)
      => (from doc in DetectedEntities[entity]
          from sen in doc.Value
          select new Tuple<Guid, int, string>(
            doc.Key,
            sen, 
            Selection.GetReadableDocumentSnippet(doc.Key, "Wort", sen, sen).ReduceDocumentToText()))
        .OrderBy(x => x.Item3);
    
    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<NamedEntityRecognitionBlock>();      
      block.Model = Model;
      block.Calculate();

      DetectedEntities = block.DetectedEntities;
    }

    public Blocks.NamedEntityRecognition.Model Model { get; set; }

    public Dictionary<string, Dictionary<Guid, HashSet<int>>> DetectedEntities { get; set; }

    protected override bool Validate()
    {
      return true;
    }
  }
}