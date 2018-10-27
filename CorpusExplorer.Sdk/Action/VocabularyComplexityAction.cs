using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.ViewModel;

namespace CorpusExplorer.Sdk.Action
{
  public class VocabularyComplexityAction : IAction
  {
    public string Action => "vocabulary-complexity";
    public string Description => "vocabulary-complexity {LAYER} - vocabulary complexity in [LAYER]";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      var vm = new VocabularyComplexityViewModel {Selection = selection};
      if (args != null && args.Length == 1)
        vm.LayerDisplayname = args[0];
      vm.Execute();
      var table = vm.GetDataTable();

      writer.WriteTable(selection.Displayname, table);
    }
  }
}