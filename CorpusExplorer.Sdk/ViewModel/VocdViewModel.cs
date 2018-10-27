using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class VocdViewModel : AbstractViewModel, IProvideDataTable
  {
    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<VocdBlock>();
      block.MetadataKey = MetadataKey;
      block.LayerDisplayname = LayerDisplayname;
      block.NumberOfSubsampels = NumberOfSubsampels;
      block.NumberOfTrails = NumberOfTrails;
      block.Precision = Precision;
      block.SampleRangeStart = SampleRangeStart;
      block.SampleRangeStop = SampleRangeStop;
      block.ValueMax = ValueMax;
      block.ValueMin = ValueMin;
      block.Calculate();

      TypeTokenRatio = block.TypeTokenRatio;
      Diversity = block.Diversity;
      Variance = block.Variance;
    }

    public string LayerDisplayname { get; set; } = "Wort";
    public string MetadataKey { get; set; } = "Autor";
    public int NumberOfSubsampels { get; set; } = 100;
    public int NumberOfTrails { get; set; } = 3;
    public double Precision { get; set; } = 0.01;
    public int SampleRangeStart { get; set; } = 35;
    public int SampleRangeStop { get; set; } = 50;
    public int ValueMax { get; set; } = 200;
    public int ValueMin { get; set; } = 1;

    /// <summary>
    ///   Type / Token / TypeTokenRatio
    /// </summary>
    public Dictionary<string, double[]> TypeTokenRatio { get; private set; }
    public Dictionary<string, double> Diversity { get; private set; }
    public Dictionary<string, double> Variance { get; private set; }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname)
          && !string.IsNullOrEmpty(MetadataKey)
          && NumberOfSubsampels > 0
          && NumberOfTrails     > 0
          && Precision          > 0
          && Precision          < 1
          && SampleRangeStart   > 0
          && SampleRangeStop    > SampleRangeStart
          && ValueMin           > 0
          && ValueMax           > ValueMin;
    }

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

        dt.Rows.Add(TypeTokenRatio[x.Key][0], 
                    TypeTokenRatio[x.Key][1], 
                    TypeTokenRatio[x.Key][2], 
                    Diversity[x.Key],
                    x.Value);
      }
      dt.EndLoadData();

      return dt;
    }
  }
}
