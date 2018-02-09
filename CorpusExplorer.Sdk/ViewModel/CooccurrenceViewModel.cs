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
      IProvideDataTable
  {
    public CooccurrenceViewModel() { LayerDisplayname = "Wort"; }

    public HashSet<string> Filter { get; set; }

    /// <summary>
    ///   Gets or sets the frequency dictionary.
    /// </summary>
    public Dictionary<string, Dictionary<string, double>> FrequencyDictionary { get; set; }

    public IEnumerable<string> LayerDisplaynames => Selection.LayerUniqueDisplaynames;
    public IEnumerable<string> LayerValues => Selection.GetLayerValues(LayerDisplayname);

    public string LayerDisplayname { get; set; }

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

    private DataTable BuildDataTable(
      Dictionary<string, Dictionary<string, double>> sdf,
      Dictionary<string, Dictionary<string, double>> fdf)
    {
      var res = new DataTable();
      res.Columns.Add(Resources.StringLabel, typeof(string));
      res.Columns.Add(Resources.Cooccurrence, typeof(string));
      res.Columns.Add(Resources.Frequency, typeof(double));
      res.Columns.Add(Resources.Significance, typeof(double));

      if (sdf == null || fdf == null)
        return res;

      res.BeginLoadData();
      foreach (var sd in sdf)
      {
        if (!fdf.ContainsKey(sd.Key))
          continue;

        foreach (var se in sd.Value.Where(se => fdf[sd.Key].ContainsKey(se.Key)))
          res.Rows.Add(sd.Key, se.Key, fdf[sd.Key][se.Key], se.Value);
      }
      res.EndLoadData();

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
              nsdf.Add(x.Key, new Dictionary<string, double> {{y.Key, y.Value}});
          }

      // Erzeuge DataTable
      return BuildDataTable(nsdf, fdf);
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
        Analyse();

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
          res.Add(x.Key, new[] {FrequencyDictionary[query][x.Key], x.Value});
        }
      }

      foreach (var x in SignificanceDictionary)
      {
        if (Filter != null && Filter.Count > 0 && !Filter.Contains(x.Key))
          continue;

        foreach (var query in hsh)
          if (x.Value.ContainsKey(query) && !res.ContainsKey(x.Key))
            res.Add(x.Key, new[] {FrequencyDictionary[x.Key][query], x.Value[query]});
      }

      return res;
    }

    public DataTable SearchDataTable(IEnumerable<string> queries)
    {
      var dt = new DataTable();
      dt.Columns.Add(Resources.Cooccurrence, typeof(string));
      dt.Columns.Add(Resources.Frequency, typeof(double));
      dt.Columns.Add(Resources.Significance, typeof(double));

      dt.BeginLoadData();
      foreach (var x in Search(queries))
        dt.Rows.Add(x.Key, x.Value[0], x.Value[1]);
      dt.EndLoadData();
      return dt;
    }

    protected override bool Validate() { return !string.IsNullOrEmpty(LayerDisplayname); }
  }
}