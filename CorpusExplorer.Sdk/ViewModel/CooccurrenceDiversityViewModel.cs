﻿#region

using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

#endregion

namespace CorpusExplorer.Sdk.ViewModel
{
  public class CooccurrenceDiversityViewModel : AbstractViewModel, IUseSpecificLayer, IProvideDataTable
  {
    public Dictionary<string, double> CollocatesAverage { get; set; }
    public Dictionary<string, double> CollocatesBest { get; set; }
    public Dictionary<string, double> CollocatesDeviation { get; set; }
    public Dictionary<string, double> CollocatesWorst { get; set; }
    public IEnumerable<string> LayerQueries { get; set; }

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      var res = new DataTable();
      res.Columns.Add(Resources.Cooccurrence, typeof(string));
      res.Columns.Add("Beste", typeof(double));
      res.Columns.Add("Schlechteste", typeof(double));
      res.Columns.Add("Mittelwert", typeof(double));
      res.Columns.Add("Standardabweichung", typeof(double));

      res.BeginLoadData();
      foreach (var x in CollocatesAverage)
      {
        if (!CollocatesBest.ContainsKey(x.Key) || !CollocatesDeviation.ContainsKey(x.Key) ||
            !CollocatesWorst.ContainsKey(x.Key))
          continue;

        res.Rows.Add(x.Key, CollocatesBest[x.Key], CollocatesWorst[x.Key], x.Value, CollocatesDeviation[x.Key]);
      }

      res.EndLoadData();

      return res;
    }
    
    public string LayerDisplayname { get; set; }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<CooccurrenceSpreadingBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.LayerQueries = LayerQueries;
      block.Calculate();

      CollocatesAverage = block.SignificanceAverageCooccurrence;
      CollocatesBest = block.SignificanceBestCooccurrence;
      CollocatesDeviation = block.SignificanceStandardDeviationCooccurrence;
      CollocatesWorst = block.SignificanceWorstCooccurrence;
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname) && LayerQueries != null && LayerQueries.Any();
    }
  }
}