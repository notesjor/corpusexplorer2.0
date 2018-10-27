using System;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Addon;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Utils.DataTableWriter.Abstract;

namespace CorpusExplorer.Sdk.Action
{
  public class ConvertAction : IAction
  {
    public string Action => "convert";
    public string Description => "convert - see help section [OUTPUT] for more information";

    public void Execute(Selection selection, string[] args, AbstractTableWriter writer)
    {
      var output = args.Last().Split(new[] {"#"}, StringSplitOptions.RemoveEmptyEntries);
      if (output.Length != 2)
        return;
      var exporters = Configuration.AddonExporters.GetDictionary();
      if (!exporters.ContainsKey(output[0]))
        return;

      var path = output[1].Replace("\"", "");
      var dir = Path.GetDirectoryName(path);
      if (dir != null && !Directory.Exists(dir))
        Directory.CreateDirectory(dir);

      exporters[output[0]].Export(selection, path);
    }
  }
}