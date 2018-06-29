using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.PromXes.Model;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.PromXes.Exporter
{
  public class ExporterPromXes : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      var res = new log();
      var meta = hydra.DocumentMetadata.ToArray();

      foreach (var x in meta)
      {
      }
    }
  }
}