#region

using System.Collections.Generic;
using System.Data;
using CorpusExplorer.Sdk.Blocks;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

#endregion

namespace CorpusExplorer.Sdk.ViewModel
{
  public class CooccurrencePolarisationViewModel : AbstractViewModel, IUseSpecificLayer, IProvideDataTable
  {
    public CooccurrencePolarisationViewModel() { LayerDisplayname = "Wort"; }

    public Dictionary<string, double> CollocatesPolarisation { get; set; }
    public string LayerValueA { get; set; }
    public string LayerValueB { get; set; }

    /// <summary>
    ///   Gibt eine Datentabelle zurück
    /// </summary>
    /// <returns>Datentabelle</returns>
    public DataTable GetDataTable()
    {
      if (CollocatesPolarisation == null)
        return null;

      var dt = new DataTable();
      dt.Columns.Add(Resources.Cooccurrence, typeof(string));
      dt.Columns.Add("Polarisation", typeof(double));

      dt.BeginLoadData();
      foreach (var entry in CollocatesPolarisation)
        dt.Rows.Add(entry.Key, entry.Value);
      dt.EndLoadData();

      return dt;
    }

    public IEnumerable<string> LayerDisplaynames => Selection.LayerUniqueDisplaynames;

    public string LayerDisplayname { get; set; }

    protected override void ExecuteAnalyse()
    {
      var block = Selection.CreateBlock<CooccurrencePolarisationBlock>();
      block.LayerDisplayname = LayerDisplayname;
      block.LayerValueA = LayerValueA;
      block.LayerValueB = LayerValueB;
      block.Calculate();

      CollocatesPolarisation = block.CooccurrencesPolarisation;
    }

    protected override bool Validate()
    {
      return !string.IsNullOrEmpty(LayerDisplayname) && !string.IsNullOrEmpty(LayerValueA)
             && !string.IsNullOrEmpty(LayerValueB) && LayerValueA != LayerValueB;
    }
  }
}