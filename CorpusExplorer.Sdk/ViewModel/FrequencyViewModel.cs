#region

using System.Collections.Generic;
using System.Data;
using System.Linq;
using CorpusExplorer.Sdk.Helper;
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
      Mapper = new ViewModelLayerDisplaynameMapper(this, new[]{ nameof(Layer1Displayname), nameof(Layer2Displayname), nameof(Layer3Displayname) });
    }

    public string Layer1Displayname { get; set; } = "POS";

    public string Layer2Displayname { get; set; } = "Lemma";

    public string Layer3Displayname { get; set; } = "Wort";

    /// <summary>
    ///   Gets the data table.
    /// </summary>
    public DataTable GetDataTable()
    {
      return ((IProvideDataTable) _vm).GetDataTable();
    }

    public ViewModelLayerDisplaynameMapper Mapper { get; set; }

    protected override void ExecuteAnalyse()
    {
      var val = string.IsNullOrEmpty(Layer2Displayname) ? 1 : string.IsNullOrEmpty(Layer3Displayname) ? 2 : 3;

      switch (val)
      {
        case 1:
          _vm = new Frequency1LayerViewModel
          {
            Selection = Selection,
            LayerDisplayname = Layer1Displayname
          };
          break;
        case 2:
          _vm = new Frequency2LayerViewModel
          {
            Selection = Selection,
            Layer1Displayname = Layer1Displayname,
            Layer2Displayname = Layer2Displayname
          };
          break;
        case 3:
          _vm = new Frequency3LayerViewModel
          {
            Selection = Selection,
            Layer1Displayname = Layer1Displayname,
            Layer2Displayname = Layer2Displayname,
            Layer3Displayname = Layer3Displayname
          };
          break;
      }

      _vm.Execute();
    }

    protected override bool Validate()
    {
      return true;
    }
  }
}