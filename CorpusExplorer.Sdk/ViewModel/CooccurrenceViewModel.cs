#region

using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

#endregion

namespace CorpusExplorer.Sdk.ViewModel
{
  /// <summary>
  ///   The cooccurrence view model.
  /// </summary>
  public class CooccurrenceViewModel
    : AbstractViewModel,
      IProvideDataTable,
      IProvideCorrespondingLayerValueFilter
  {
    public CooccurrenceViewModel()
    {
      LayerDisplayname = "Wort";
    }

    public HashSet<string> Filter { get; set; }

    /// <summary>
    ///   Gets or sets the frequency dictionary.
    /// </summary>
    public Dictionary<string, Dictionary<string, double>> FrequencyDictionary { get; set; }

    public string LayerDisplayname { get; set; }
    
    /// <summary>
    ///   Eigenschaft kann gesetzt werden, um die Ausgabe von GetDataTable() zu filtern.
    ///   Zum Filter/Optimieren des Blocks sollte Configuration.MinimumFrequency gesetzt werden.
    /// </summary>
    /// <value>The cooccurrence minimum frequency.</value>
    public int CooccurrenceMinFrequency { get; set; } = 1;

    /// <summary>
    ///   Eigenschaft kann gesetzt werden, um die Ausgabe von GetDataTable() zu filtern.
    ///   Zum Filter/Optimieren des Blocks sollte Configuration.MinimumSignificance gesetzt werden.
    /// </summary>
    /// <value>The cooccurrence minimum significance.</value>
    public double CooccurrenceMinSignificance { get; set; } = 0;

    /// <summary>
    ///   Gets or sets the significance dictionary.
    /// </summary>
    public Dictionary<string, Dictionary<string, double>> SignificanceDictionary { get; set; }

    /// <summary>
    ///   Gets the data table.
    /// </summary>
    public DataTable GetDataTable()
    {
      return FilterDataTable(SignificanceDictionary, FrequencyDictionary);
    }

    public DataTable GetFullDataTable()
    {
      return FilterDataTable(
                             SignificanceDictionary.CompleteDictionaryToFullDictionary(),
                             FrequencyDictionary.CompleteDictionaryToFullDictionary());
    }

    public IEnumerable<KeyValuePair<string, double[]>> Search(IEnumerable<string> queries)
    {
      if (SignificanceDictionary == null)
        Execute();

      var res = new Dictionary<string, double[]>();
      var hsh = new HashSet<string>(queries);

      foreach (var query in hsh)
      {
        if (!SignificanceDictionary.ContainsKey(query))
          continue;

        foreach (var x in SignificanceDictionary[query])
        {
          if (Filter != null && Filter.Count > 0 && !Filter.Contains(x.Key))
            continue;

          if (res.ContainsKey(x.Key))
          {
            if (x.Value > res[x.Key][1])
            {
              res[x.Key][0] = FrequencyDictionary[query][x.Key];
              res[x.Key][1] = x.Value;
            }

            continue;
          }

          res.Add(x.Key, new[] { FrequencyDictionary[query][x.Key], x.Value });
        }
      }

      foreach (var x in SignificanceDictionary)
      {
        if (Filter != null && Filter.Count > 0 && !Filter.Contains(x.Key))
          continue;

        foreach (var query in hsh)
          if (x.Value.ContainsKey(query) && !res.ContainsKey(x.Key))
            res.Add(x.Key, new[] { FrequencyDictionary[x.Key][query], x.Value[query] });
      }

      return res;
    }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<CooccurrenceBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.Calculate();

      FrequencyDictionary = block.CooccurrenceFrequency;
      SignificanceDictionary = block.CooccurrenceSignificance;
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname);
    }

    private DataTable BuildDataTable(
      Dictionary<string, Dictionary<string, double>> sdf,
      Dictionary<string, Dictionary<string, double>> fdf)
    {
      var res = new DataTable();
      res.Columns.Add(LayerDisplayname, typeof(string));
      res.Columns.Add(Resources.Cooccurrence, typeof(string));
      res.Columns.Add(Resources.Frequency, typeof(double));
      res.Columns.Add(Resources.Significance, typeof(double));

      if (sdf == null || fdf == null)
        return res;

      CorrespondingLayerValueFilter?.DataTableFilterInit(ref res, new[] { Resources.Cooccurrence });

      res.BeginLoadData();
      foreach (var data in from sd in sdf where fdf.ContainsKey(sd.Key) from se in sd.Value.Where(se => fdf[sd.Key].ContainsKey(se.Key)) where se.Value >= CooccurrenceMinSignificance && fdf[sd.Key][se.Key] >= CooccurrenceMinFrequency select new object[] { sd.Key, se.Key, fdf[sd.Key][se.Key], se.Value })
      {
        if (CorrespondingLayerValueFilter == null)
          res.Rows.Add(data);
        else
        {
          if (CorrespondingLayerValueFilter.DataTableFilter(data))
            res.Rows.Add(data);
        }
      }

      res.EndLoadData();

      return res;
    }

    private DataTable FilterDataTable(
      Dictionary<string, Dictionary<string, double>> sdf,
      Dictionary<string, Dictionary<string, double>> fdf)
    {
      // Wenn kein Filter gesetzt - gebe Ergebnis direkt zurück.
      if (Filter == null)
        return BuildDataTable(sdf, fdf);

      // Baue Filterfunktion - Es reicht wenn sdf gefiltert wird
      var nsdf = new Dictionary<string, Dictionary<string, double>>();
      foreach (var x in sdf)
        // Kopiere alles wenn Key0 in Filter enthalten.
        if (Filter.Contains(x.Key))
          nsdf.Add(x.Key, x.Value);
        // Kopiere nur das notwendigste, wenn Key1 in Filter enthalten.
        else
          foreach (var y in x.Value)
          {
            if (!Filter.Contains(y.Key))
              continue;

            if (nsdf.ContainsKey(x.Key))
              nsdf[x.Key].Add(y.Key, y.Value);
            else
              nsdf.Add(x.Key, new Dictionary<string, double> { { y.Key, y.Value } });
          }

      // Erzeuge DataTable
      return BuildDataTable(nsdf, fdf);
    }

    public CorrespondingLayerValueFilterViewModel CorrespondingLayerValueFilter { get; set; }
  }
}