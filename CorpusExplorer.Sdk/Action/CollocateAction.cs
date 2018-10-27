using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.ViewModel;

namespace CorpusExplorer.Sdk.Action
{
  public class CollocateAction : IAction
  {
    public string Action => "position-frequency";

    public string Description =>
      "position-frequency [LAYER1] [WORD] - left/right position of words around [WORD]";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      if (args == null || args.Length < 2)
        return;

      var vm = new PositionFrequencyViewModel
      {
        Selection = selection,
        LayerDisplayname = args[0]
      };
      vm.Execute();

      writer.WriteTable(selection.Displayname, vm.GetDataTable());
    }
  }
}