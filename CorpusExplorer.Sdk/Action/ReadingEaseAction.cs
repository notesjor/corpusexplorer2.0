using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.ViewModel;

namespace CorpusExplorer.Sdk.Action
{
  public class ReadingEaseAction : IAction
  {
    public string Action => "reading-ease";
    public string Description => "reading-ease {LAYER} - reading ease of [LAYER]";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      try
      {
        var vm = new ReadingEaseViewModel {Selection = selection};
        if (args != null && args.Length == 1)
          vm.LayerDisplayname = args[0];
        vm.Execute();
        var table = vm.GetDataTable();

        writer.WriteTable(selection.Displayname, table);
      }
      catch
      {
        // ignore
      }
    }
  }
}