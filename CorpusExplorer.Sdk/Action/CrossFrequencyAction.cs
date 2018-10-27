using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.ViewModel;

namespace CorpusExplorer.Sdk.Action
{
  public class CrossFrequencyAction : IAction
  {
    public string Action => "cross-frequency";
    public string Description => "cross-frequency {LAYER} - calculates the cross-frequency based on [LAYER]";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      var vm = new FrequencyCrossViewModel {Selection = selection};
      if (args != null && args.Length == 1)
        vm.LayerDisplayname = args[0];
      vm.Execute();

      writer.WriteTable(selection.Displayname, vm.GetDataTable());
    }
  }
}