using System.IO;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Extern.MachineLearning.Configuration.Lda;
using CorpusExplorer.Sdk.Extern.MachineLearning.ViewModel;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Extern.MachineLearning.Action
{
  public class LdaAction : IAction
  {
    public string Action =>
      "lda";

    public string Description =>
      "lda [CONFIG] {TOPIC-EXPORT} - [CONFIG] must be a JSON-Config file. If the file don't exists a new file will be created. Use {TOPIC-EXPORT} to export a additional topic-list.";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      var config = new LdaConfiguration().Load(args[0]);
      var vm = new LdaViewModel
      {
        Selection = selection,
        Configuration = config
      };
      vm.Execute();

      writer.WriteTable(vm.GetDataTableDocuments());

      if (args.Length != 2) 
        return;

      using (var fs = new FileStream(args[1], FileMode.Create, FileAccess.Write))
        writer.Clone(fs).WriteTable(vm.GetDataTableTopics());
    }
  }
}
