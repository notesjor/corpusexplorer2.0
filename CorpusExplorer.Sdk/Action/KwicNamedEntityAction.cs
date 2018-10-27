using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Action
{
  public class KwicNamedEntityAction : IAction
  {
    public string Action => "kwic-ner";
    public string Description => "ner [NERFILE] - performs a named entity recorgnition + kwic-resuls";
    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      if (args.Length != 1)
        return;

      var vm = new ViewModel.NamedEntityDetectionViewModel
      {
        Selection = selection,
        Model = Blocks.NamedEntityRecognition.Model.Load(args[0])
      };

      vm.Execute();

      writer.WriteTable(selection.Displayname, vm.GetKwicDataTable());
    }
  }
}