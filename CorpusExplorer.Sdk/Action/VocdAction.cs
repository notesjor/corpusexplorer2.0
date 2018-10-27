using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.ViewModel;

namespace CorpusExplorer.Sdk.Action
{
  public class VocdAction : IAction
  {
    public string Action => "vocd";
    public string Description => "vocd [LAYER] [META] - calculates VOCD for [LAYER] clustered by [META]";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      if (args.Length != 2)
        return;

      var vm = new VocdViewModel
      {
        Selection = selection,
        LayerDisplayname = args[0],
        MetadataKey = args[1]
      };
      vm.Execute();

      writer.WriteTable(selection.Displayname, vm.GetDataTable());
    }
  }
}