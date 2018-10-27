using System.Linq;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.ViewModel;

namespace CorpusExplorer.Sdk.Action
{
  public class NGramSelectedAction : IAction
  {
    public string Action => "ngram-select";

    public string Description =>
      "ngram-select [N] [LAYER] [minFREQ] [WORDS] - all [N]-grams on [LAYER] containing [WORDS] .";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      if (args.Length < 4)
        return;

      var vm = new Ngram1LayerSelectiveViewModel
      {
        Selection = selection,
        NGramSize = int.Parse(args[0]),
        LayerDisplayname = args[1],
        NGramMinFrequency = int.Parse(args[2])
      };

      var queries = args.ToList();
      queries.RemoveAt(0);
      queries.RemoveAt(0);
      queries.RemoveAt(0);
      vm.LayerQueries = queries;

      vm.Execute();

      writer.WriteTable(selection.Displayname, vm.GetDataTable());
    }
  }
}