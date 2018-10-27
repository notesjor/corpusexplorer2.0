using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.ViewModel;

namespace CorpusExplorer.Sdk.Action
{
  public class StyleNgramAction : IAction
  {
    public string Action => "style-ngram";

    public string Description =>
      "style-ngram [LAYER] [META] [N] [minFREQ] - style analytics based on ngram";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      if (args == null || args.Length != 4)
        return;

      var vm = new ClusterMetadataByNGramViewModel
      {
        Selection = selection,
        LayerDisplayname = args[0],
        MetadataKey = args[1],
        NGramSize = int.Parse(args[2]),
        NGramMinFrequency = int.Parse(args[3])
      };
      vm.Execute();

      writer.WriteTable(selection.Displayname, vm.GetCrossDataTable());
    }
  }
}