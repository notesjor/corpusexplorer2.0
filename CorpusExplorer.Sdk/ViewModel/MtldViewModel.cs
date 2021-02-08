using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.Mtld;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class MtldViewModel : AbstractViewModel, IProvideDataTable
  {
    public string LayerDisplayname { get; set; } = "Wort";
    public string MetadataKey { get; set; } = "Autor";
    public double Threshold { get; set; } = 0.71;
    public WeightingMode WeightingMode { get; set; } = WeightingMode.WithinOnly;

    /// <summary>
    ///   Type / Token / TypeTokenRatio
    /// </summary>
    public Dictionary<string, double[]> TypeTokenRatio { get; private set; }

    public Dictionary<string, double> Diversity { get; private set; }
    public Dictionary<string, double> Variance { get; private set; }

    public DataTable GetDataTable()
    {
      var dt = new DataTable();
      dt.Columns.Add("Cluster", typeof(string));
      dt.Columns.Add("Type", typeof(double));
      dt.Columns.Add("Token", typeof(double));
      dt.Columns.Add("TTR", typeof(double));
      dt.Columns.Add("Diversität", typeof(double));
      dt.Columns.Add("Varianz", typeof(double));

      dt.BeginLoadData();
      foreach (var x in Variance)
      {
        if (!TypeTokenRatio.ContainsKey(x.Key) || !Diversity.ContainsKey(x.Key))
          continue;

        dt.Rows.Add(x.Key,
                    TypeTokenRatio[x.Key][0],
                    TypeTokenRatio[x.Key][1],
                    TypeTokenRatio[x.Key][2],
                    Diversity[x.Key],
                    x.Value);
      }

      dt.EndLoadData();

      return dt;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<MtldBlock>();
      block.MetadataKey = MetadataKey;
      block.LayerDisplayname = LayerDisplayname;
      block.Threshold = Threshold;
      block.WeightingMode = WeightingMode;
      block.Calculate();

      TypeTokenRatio = block.TypeTokenRatio;
      Diversity = block.Diversity;
      Variance = block.Variance;
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname)
          && !string.IsNullOrEmpty(MetadataKey)
          && Threshold > 0;
    }
  }
}