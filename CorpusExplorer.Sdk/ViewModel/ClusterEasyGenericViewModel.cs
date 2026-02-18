using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;
using CorpusExplorer.Sdk.Ecosystem.Model;
using System.Linq;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class ClusterEasyGenericViewModel : AbstractViewModel, IProvideDataTable
  {
    private SelectionClusterBlock _block;

    public string LayerDisplayname { get; set; } = "Wort";

    public string MetadataKey { get; set; } = "Datum";

    public IEnumerable<string> DocumentMetaProperties
      => Selection.GetDocumentMetadataPrototypeOnlyProperties();

    public AbstractSelectionClusterGenerator ClusterGenerator { get; set; } = new SelectionClusterGeneratorDateTimeYearMonthDay();

    public IProvideDataTable ChildViewModel { get; set; } = null;

    public string[] ClusterNames { get; set; }

    public DataTable GetDataTable()
    {
      var res = new DataTable();
      var @lock = new object();

      res.BeginLoadData();
      Parallel.ForEach(ClusterTables, Configuration.ParallelOptions, insert =>
      {
        lock (@lock)
        {
          if (res.Rows.Count == 0)
          {
            res = insert.Value.Clone();
            res.Columns.Add(MetadataKey, typeof(string));
          }

          foreach (DataRow row in insert.Value.Rows)
          {
            var newrow = res.NewRow();
            foreach (DataColumn col in insert.Value.Columns)
              newrow[col.ColumnName] = row[col.ColumnName];
            newrow[MetadataKey] = insert.Key;
            res.Rows.Add(newrow);
          }
        }
      });
      res.EndLoadData();

      return res;
    }

    protected override void ExecuteAnalyse()
    {
      // POST VALIDATE
      if (string.IsNullOrEmpty(LayerDisplayname) || string.IsNullOrEmpty(MetadataKey) || ClusterGenerator == null || ChildViewModel == null)
        return;

      _block = Selection.CreateBlock<SelectionClusterBlock>();
      _block.ClusterGenerator = ClusterGenerator;
      _block.MetadataKey = MetadataKey;
      _block.NoParent = false;
      _block.Calculate();

      var cluster = _block.GetTemporarySelectionClusters();
      ClusterNames = cluster.Select(c => c.Displayname).ToArray();

      ClusterTables = new Dictionary<string, DataTable>();
      foreach (var sel in cluster)
      {
        ChildViewModel.Selection = sel;
        ChildViewModel.Execute();
        ClusterTables.Add(sel.Displayname,  ChildViewModel.GetDataTable());
      }
      /* TODO: Enable parallel - problem: Reuse of ChildViewModel in multiple threads
       * 
      var @lock = new object();

      Parallel.ForEach(cluster, Configuration.ParallelOptions, sel =>
      {
        ChildViewModel.Selection = sel;
        ChildViewModel.Execute();
        var table = ChildViewModel.GetDataTable();

        lock (@lock)
          ClusterTables.Add(sel.Displayname, table);
      });
      */
    }

    public Dictionary<string, DataTable> ClusterTables { get; set; }

    protected override bool Validate()
    {
      return true; // NOTE: Müsste eigentlich wie folgt aussehen - aber dieses VM lässt sich nicht abschließend initialisieren
      // Daher POST VALIDATE
      // return !string.IsNullOrEmpty(LayerDisplayname) && !string.IsNullOrEmpty(MetadataKey) && ClusterGenerator != null && ChildViewModel != null;
    }
  }
}
