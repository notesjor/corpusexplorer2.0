using System;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

namespace CorpusExplorer.Sdk.ViewModel
{
  public class CooccurrenceCompareViewModel : AbstractCompareViewModel, IProvideDataTable
  {
    private DataTable _dataTable;

    public CooccurrenceCompareViewModel()
    {
      LayerDisplayname = "Wort";
    }

    public string LayerDisplayname { get; set; }

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      return _dataTable;
    }

    protected override void ExecuteAnalyse()
    {
      var block1 = Selection.CreateBlock<CooccurrenceBlock>();
      block1.LayerDisplayname = LayerDisplayname;
      block1.Calculate();

      if (block1.CooccurrenceSignificance == null)
        return;

      var block2 = SelectionToCompare.CreateBlock<CooccurrenceBlock>();
      block2.LayerDisplayname = LayerDisplayname;
      block2.Calculate();

      if (block2.CooccurrenceSignificance == null)
        return;

      _dataTable = new DataTable();
      _dataTable.Columns.Add(Resources.StringLabel, typeof(string));
      _dataTable.Columns.Add(Resources.Cooccurrence, typeof(string));
      _dataTable.Columns.Add(Resources.Frequeny1, typeof(double));
      _dataTable.Columns.Add(Resources.Frequeny2, typeof(double));
      _dataTable.Columns.Add(Resources.FrequenyD12, typeof(double));
      _dataTable.Columns.Add(Resources.Significance1, typeof(double));
      _dataTable.Columns.Add(Resources.Significance2, typeof(double));
      _dataTable.Columns.Add(Resources.SignificanceD12, typeof(double));

      _dataTable.BeginLoadData();

      var freq1 = block1.CooccurrenceFrequency.CompleteDictionaryToFullDictionary().GetNormalizedDictionary();
      var freq2 = block2.CooccurrenceFrequency.CompleteDictionaryToFullDictionary().GetNormalizedDictionary();

      var cooc1 = block1.CooccurrenceSignificance.CompleteDictionaryToFullDictionary();
      var cooc2 = block2.CooccurrenceSignificance.CompleteDictionaryToFullDictionary();

      foreach (var entry in cooc1)
        if (cooc2.ContainsKey(entry.Key))
          foreach (var row in entry.Value)
            if (cooc2[entry.Key].ContainsKey(row.Key))
            {
              _dataTable.Rows.Add(
                entry.Key,
                row.Key,
                freq1[entry.Key][row.Key],
                freq2[entry.Key][row.Key],
                Math.Abs(
                  freq1[entry.Key][row.Key] -
                  freq2[entry.Key][row.Key]),
                row.Value,
                cooc2[entry.Key][row.Key],
                Math.Abs(row.Value - cooc2[entry.Key][row.Key]));
              cooc2[entry.Key].Remove(row.Key);
            }
            else
            {
              _dataTable.Rows.Add(
                entry.Key,
                row.Key,
                freq1[entry.Key][row.Key],
                0.0d,
                freq1[entry.Key][row.Key],
                row.Value,
                0.0d,
                row.Value);
            }
        else
          foreach (var row in entry.Value)
            _dataTable.Rows.Add(
              entry.Key,
              row.Key,
              freq1[entry.Key][row.Key],
              0.0d,
              freq1[entry.Key][row.Key],
              row.Value,
              0.0d,
              row.Value);

      foreach (var entry in block2.CooccurrenceSignificance)
      foreach (var row in entry.Value)
        _dataTable.Rows.Add(
          entry.Key,
          row.Key,
          0.0d,
          freq2[entry.Key][row.Key],
          freq2[entry.Key][row.Key],
          0.0d,
          row.Value,
          row.Value);

      _dataTable.EndLoadData();
    }
  }
}