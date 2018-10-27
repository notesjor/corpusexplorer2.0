using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Action
{
  public class NamedEntityAction : IAction
  {
    public string Action => "ner";
    public string Description => "ner [NERFILE] - performs a named entity recorgnition";
    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      if(args.Length != 1)
        return;

      var vm = new ViewModel.NamedEntityDetectionViewModel
      {
        Selection = selection,
        Model = Blocks.NamedEntityRecognition.Model.Load(args[0])
      };

      vm.Execute();

      writer.WriteTable(selection.Displayname, vm.GetDataTable());
    }
  }
}
