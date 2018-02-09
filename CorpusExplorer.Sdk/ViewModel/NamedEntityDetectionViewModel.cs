using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class NamedEntityDetectionViewModel : AbstractViewModel, IProvideDataTable
  {
    public Dictionary<string, double> NamedEntities { get; set; }
    public Dictionary<string, HashSet<string>> NamedEntitiesItems { get; set; }

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add("Entität", typeof(string));
      dt.Columns.Add("Umfang", typeof(int));
      dt.Columns.Add(Resources.Frequency, typeof(double));

      dt.BeginLoadData();

      foreach (var entity in NamedEntities)
        dt.Rows.Add(entity.Key, NamedEntitiesItems[entity.Key].Count, entity.Value);

      dt.EndLoadData();

      return dt;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<NamedEntityDetectionBlock>();
      block.Calculate();

      NamedEntities = block.NamedEntities;
      NamedEntitiesItems = block.NamedEntitiesItems;
    }

    protected override bool Validate() { return true; }
  }
}