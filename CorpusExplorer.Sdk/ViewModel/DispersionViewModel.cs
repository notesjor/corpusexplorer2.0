using System;
using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class DispersionViewModel : AbstractViewModel,
                                     IProvideDataTable,
                                     IProvideCorrespondingLayerValueFilter
  {
    public DispersionViewModel()
    {
      LayerDisplayname = "Wort";
      MetadataKey = "GUID";
    }

    public string LayerDisplayname { get; set; }
    public string MetadataKey { get; set; }

    protected override void ExecuteAnalyse()
    {
      var blockA = Selection.CreateBlock<DocumentTermFrequencyBlock>();
      blockA.LayerDisplayname = LayerDisplayname;
      blockA.MetadataKey = MetadataKey;
      blockA.Calculate();

      var blockB = Selection.CreateBlock<InverseDocumentTermFrequencyBlock>();
      blockB.LayerDisplayname = LayerDisplayname;
      blockB.MetadataKey = MetadataKey;
      blockB.Calculate();

      var freq = blockA.DocumentTermFrequencyReduced;
      var invf = blockB.InverseDocumentTermFrequencyReduced;

      DispersionValues = new Dictionary<string, Tuple<double, double>>();
      foreach (var x in freq)
        DispersionValues.Add(x.Key, new Tuple<double, double>(x.Value, invf[x.Key]));
    }

    public Dictionary<string, Tuple<double, double>> DispersionValues { get; set; }
    public CorrespondingLayerValueFilterViewModel CorrespondingLayerValueFilter { get; set; }

    protected override bool Validate() => !string.IsNullOrEmpty(LayerDisplayname) && !string.IsNullOrEmpty(MetadataKey);

    public DataTable GetDataTable()
    {
      var res = new DataTable();
      res.Columns.Add(LayerDisplayname, typeof(string));
      res.Columns.Add($"{MetadataKey}-Term-Frequenz", typeof(double));
      res.Columns.Add($"Inverse-{MetadataKey}-Term-Frequenz", typeof(double));

      res.BeginLoadData();
      foreach (var x in DispersionValues)
        if (CorrespondingLayerValueFilter == null)
          res.Rows.Add(x.Key, x.Value.Item1, x.Value.Item2);
        else
        {
          if (CorrespondingLayerValueFilter.CustomFilter(x.Key))
            res.Rows.Add(x.Key, x.Value.Item1, x.Value.Item2);
        }
      res.EndLoadData();
      return res;
    }
  }
}