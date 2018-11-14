using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.VocabularyComplaxity;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class VocabularyComplexityViewModel : AbstractViewModel, IProvideDataTable
  {
    public Dictionary<string, Dictionary<Guid, double>> ComplexityValues { get; set; }

    public string LayerDisplayname { get; set; } = "Wort";

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      var proto = Selection.GetDocumentMetadataPrototypeOnlyProperties().ToArray();

      var res = new DataTable();
      res.Columns.Add(Resources.Index, typeof(string));
      foreach (var x in proto)
        res.Columns.Add(x, typeof(string));
      res.Columns.Add(Resources.Wert, typeof(double));

      res.BeginLoadData();

      var row = new object[proto.Length + 2];
      var lst = row.Length - 1;

      foreach (var x in ComplexityValues)
      {
        row[0] = x.Key;
        foreach (var y in x.Value)
        {
          var meta = Selection.GetDocumentMetadata(y.Key);
          for (var i = 0; i < proto.Length; i++)
            row[i + 1] = meta.ContainsKey(proto[i]) ? meta[proto[i]] == null ? "" : meta[proto[i]].ToString() : "";
          row[lst] = y.Value;

          res.Rows.Add(row);
        }
      }

      res.EndLoadData();
      return res;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<VocabularyComplexityBlock>();
      block.LayerDisplayname = LayerDisplayname;

      ComplexityValues = new Dictionary<string, Dictionary<Guid, double>>();

      foreach (var algo in Configuration.GetSideloadFeature<AbstractVocabularyComplexity>())
        try
        {
          block.ComplexityAlgorithm = algo;
          block.Calculate();

          ComplexityValues.Add(algo.Displayname, block.ComplexityValues);
        }
        catch
        {
          // ignore
        }
    }

    protected override bool Validate()
    {
      return true;
    }
  }
}