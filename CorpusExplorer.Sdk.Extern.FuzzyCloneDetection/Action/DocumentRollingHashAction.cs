using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Extern.FuzzyCloneDetection.ViewModel;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Extern.FuzzyCloneDetection.Action
{
  public class DocumentRollingHashAction : IAction
  {
    public string Action => "hash-roll";
    public string Description => "hash-roll [LAYER] - calculates a rolling hashsum for all documents in [LAYER].";
    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      var vm = new DocumentRollingHashViewModel();
      if (args.Length == 1)
        vm.LayerDisplayname = args[0];
      vm.Execute();

      writer.WriteTable(vm.GetDataTable());
    }
  }
}
