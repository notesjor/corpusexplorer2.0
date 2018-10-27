using System.Collections.Generic;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Queries;
using CorpusExplorer.Sdk.ViewModel;

namespace CorpusExplorer.Sdk.Action
{
  public class KwicSignificantFilterAction : IAction
  {
    public string Action => "kwic-sig";
    public string Description =>
      "kwic-sig [LAYER] [WORDS] - KWIC with significance metrics - [WORDS] = space separated tokens";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      if (args == null || args.Length < 2)
        return;

      var queries = new List<string>(args);
      queries.RemoveAt(0);

      var vm = new TextLiveSignificanceSearchViewModel
      {
        Selection = selection,
        HighlightBodyStart = "<div>",
        HighlightBodyEnd = "</div>"
      };
      vm.AddQuery(new FilterQuerySingleLayerAnyMatch { LayerDisplayname = args[0], LayerQueries = queries });
      vm.Execute();

      writer.WriteTable(selection.Displayname, vm.GetDataTable());
    }
  }
}