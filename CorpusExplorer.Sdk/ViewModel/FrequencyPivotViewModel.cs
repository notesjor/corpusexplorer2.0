using System;
using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Blocks.Partition;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class FrequencyPivotViewModel : AbstractViewModel, IProvideDataTable
  {
    private Dictionary<string, Dictionary<string, Guid[]>> _partition;
    private Dictionary<Guid, Dictionary<string, Dictionary<string, Dictionary<string, double>>>> _values;

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      var res = new DataTable();
      res.Columns.Add(Resources.Category, typeof(string));
      res.Columns.Add(Resources.MetadataLabel, typeof(string));
      res.Columns.Add("POS", typeof(string));
      res.Columns.Add("Lemma", typeof(string));
      res.Columns.Add("Wort", typeof(string));
      res.Columns.Add(Resources.Frequency, typeof(double));

      foreach (var k in _partition)
      foreach (var v in k.Value)
        if (v.Value != null)
          foreach (var d in v.Value)
          foreach (var p in _values[d])
          foreach (var l in p.Value)
          foreach (var w in l.Value)
            res.Rows.Add(k.Key, v.Key, p.Key, l.Key, w.Key, w.Value);

      return res;
    }

    private void AggregationDelegate(
      ref Dictionary<string, Dictionary<string, Dictionary<string, double>>> memory,
      ref Dictionary<string, Dictionary<string, Dictionary<string, double>>> dictionary)
    {
      DictionaryMergeHelper.Merge3LevelDictionary(ref memory, dictionary, (x, y) => x + y);
    }

    protected override void ExecuteAnalyse()
    {
      var block =
        Selection
          .CreateBlock
          <
            MakeMetadataDocumentPartionBlock
            <Dictionary<string, Dictionary<string, Dictionary<string, double>>>, Frequency3LayerBlock>>();
      block.AggregationDelegate = AggregationDelegate;
      block.MappingDelegate = x =>
      {
        x.Calculate();
        return x.Frequency;
      };
      block.Calculate();
      _values = block.OutputPartitionValue;
      _partition = block.OutputPartition;
    }

    protected override bool Validate() { return true; }
  }
}