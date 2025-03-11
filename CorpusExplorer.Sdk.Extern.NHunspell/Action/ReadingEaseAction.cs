using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Extern.NHunspell.Properties;
using CorpusExplorer.Sdk.Extern.NHunspell.ViewModel;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Extern.NHunspell.Action
{
  public class ReadingEaseAction : IAction
  {
    public string Action => "reading-ease";
    public string Description => Resources.DescReadingEase;

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      try
      {
        var vm = new ReadingEaseViewModel { Selection = selection };
        if (args != null && args.Length == 1)
          vm.LayerDisplayname = args[0];
        vm.Execute();

        writer.WriteTable(selection.Displayname, vm.GetDataTableSimple());
      }
      catch
      {
        // ignore
      }
    }
  }
}