using System.Linq;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.Filter;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter
{
  public class ExporterQuery : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      FileIO.Write(path.ForceFileExtension("ceusd"), ExportInline(hydra as Selection), Configuration.Encoding);
    }

    public static string ExportInline(Selection selection)
    {
      var queries = selection?.Queries?.ToArray();
      if (queries == null || queries.Length == 0)
        return null;

      try
      {
        return string.Join("\r\n",
          selection.Queries.Select(QueryParser.Serialize).Where(t => !string.IsNullOrEmpty(t)));
      }
      catch
      {
        return null;
      }
    }
  }
}