using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.ViewModel;

namespace CorpusExplorer.Sdk.Action
{
  public class Frequency1Action : IAction
  {
    public string Action => "frequency1";
    public string Description => "frequency1 {LAYER} - count token frequency on [LAYER]";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      var vm = new Frequency1LayerViewModel {Selection = selection};
      if (args != null && args.Length == 1)
        vm.LayerDisplayname = args[0];
      vm.Execute();

      writer.WriteTable(selection.Displayname, vm.GetNormalizedDataTable());
    }
  }
}