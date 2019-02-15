using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator;
using CorpusExplorer.Sdk.Blocks.SelectionCluster.Generator.Abstract;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class ClusterMetadataByBurrowsDeltaViewModel : AbstractViewModel, IProvideDataTable
  {
    private Dictionary<string, Dictionary<string, double>> _dic;
    private string[] _names;

    public string MetadataKeyA { get; set; }
    public string MetadataKeyB { get; set; }

    public AbstractSelectionClusterGenerator SelectionClusterGenerator { get; set; } =
      new SelectionClusterGeneratorStringValue();

    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add(MetadataKeyB, typeof(string));
      dt.Columns.Add(MetadataKeyA, typeof(string));
      dt.Columns.Add("value", typeof(double));

      dt.BeginLoadData();
      foreach (var x in _dic)
      foreach (var y in _names)
        if (x.Value.ContainsKey(y))
          dt.Rows.Add(x.Key, y, x.Value[y].ToString(CultureInfo.InvariantCulture));
      dt.EndLoadData();

      return dt;
    }

    protected override void ExecuteAnalyse()
    {
      var blockAc = Selection.CreateBlock<SelectionClusterBlock>();
      blockAc.ClusterGenerator = SelectionClusterGenerator;
      blockAc.MetadataKey = MetadataKeyA;
      blockAc.Calculate();
      var selA = blockAc.GetSelectionClusters().ToArray();

      var blockBc = Selection.CreateBlock<SelectionClusterBlock>();
      blockBc.ClusterGenerator = SelectionClusterGenerator;
      blockBc.MetadataKey = MetadataKeyB;
      blockBc.Calculate();
      var selB = blockBc.GetSelectionClusters().ToArray();

      _names = selA.Select(x => x.Displayname).ToArray();
      _dic = new Dictionary<string, Dictionary<string, double>>();
      var loc = new object();

      Parallel.ForEach(selA, sA =>
      {
        Parallel.ForEach(selB, sB =>
        {
          try
          {
            var sAsB = sA.JoinLeft(sB, null);

            var block = sAsB.CreateBlock<BurrowsDeltaBlock>();
            block.MetadataKey = MetadataKeyA;
            block.Calculate();

            var res = block.Compare(sB).CompareResults;

            lock (loc)
            {
              if (_dic.ContainsKey(sB.Displayname))
                foreach (var x in res)
                  if (_dic[sB.Displayname].ContainsKey(x.Key) && x.Value > _dic[sB.Displayname][x.Key])
                    _dic[sB.Displayname][x.Key] = x.Value;
                  else
                    _dic[sB.Displayname].Add(x.Key, x.Value);
              else
                _dic.Add(sB.Displayname, res);
            }
          }
          catch
          {
            // ignore
          }
        });
      });
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(MetadataKeyA) && !string.IsNullOrEmpty(MetadataKeyB);
    }

    public DataTable GetCrossDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add(MetadataKeyB, typeof(string));

      foreach (var x in _names)
        dt.Columns.Add(x, typeof(string));

      dt.BeginLoadData();
      foreach (var x in _dic)
      {
        var row = new object[_names.Length + 1];
        row[0] = x.Key;

        for (var i = 0; i < _names.Length; i++)
          row[i + 1] = x.Value.ContainsKey(_names[i]) ? x.Value[_names[i]].ToString(CultureInfo.InvariantCulture) : "";

        dt.Rows.Add(row);
      }

      dt.EndLoadData();

      return dt;
    }
  }
}