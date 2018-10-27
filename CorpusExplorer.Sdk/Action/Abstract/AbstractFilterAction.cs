using System.Collections.Generic;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter.Abstract;
using CorpusExplorer.Sdk.ViewModel;

namespace CorpusExplorer.Sdk.Action.Abstract
{
  public abstract class AbstractFilterAction : IAction
  {
    public abstract string Action { get; }
    public abstract string Description { get; }

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      if (args == null || args.Length < 2)
        return;

      var queries = new List<string>(args);
      queries.RemoveAt(0);

      var vm = new TextLiveSearchViewModel {Selection = selection};
      vm.AddQuery(GetQuery(args[0], queries));
      vm.Execute();

      writer.WriteTable(selection.Displayname, vm.GetUniqueDataTableCsv());
    }

    protected abstract AbstractFilterQuery GetQuery(string layerDisplayname, IEnumerable<string> queries);
  }
}