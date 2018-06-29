#region

using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.ViewModel.Abstract;
using CorpusExplorer.Sdk.ViewModel.Interfaces;

#endregion

namespace CorpusExplorer.Sdk.ViewModel
{
  /// <summary>
  ///   The frequency view model.
  /// </summary>
  public class FrequencyViewModel : AbstractViewModel, IProvideDataTable
  {
    private AbstractViewModel _vm;

    public FrequencyViewModel()
    {
      LayerDisplaynames = new List<string>
      {
        "POS",
        "Lemma",
        "Wort"
      };
    }

    public IEnumerable<string> LayerDisplaynames { get; set; }

    /// <summary>
    ///   Gets the data table.
    /// </summary>
    public DataTable GetDataTable()
    {
      return ((IProvideDataTable) _vm).GetDataTable();
    }

    protected override void ExecuteAnalyse()
    {
      var layers = new HashSet<string>(LayerDisplaynames).Where(x => Selection.ContainsLayer(x)).ToArray();

      switch (layers.Length)
      {
        case 1:
          _vm = new Frequency1LayerViewModel
          {
            Selection = Selection,
            LayerDisplayname = layers[0]
          };
          break;
        case 2:
          _vm = new Frequency2LayerViewModel
          {
            Selection = Selection,
            Layer1Displayname = layers[0],
            Layer2Displayname = layers[1]
          };
          break;
        case 3:
          _vm = new Frequency3LayerViewModel
          {
            Selection = Selection,
            Layer1Displayname = layers[0],
            Layer2Displayname = layers[1],
            Layer3Displayname = layers[2]
          };
          break;
      }

      _vm.Analyse();
    }

    protected override bool Validate()
    {
      return true;
    }
  }
}