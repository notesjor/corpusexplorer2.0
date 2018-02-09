using System.Linq;
using System.Text;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Export.Abstract;
using CorpusExplorer.Sdk.Model.Interface;

namespace CorpusExplorer.Core.Exporter
{
  public class ExporterPlaintextPureInOneFile : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      FileIO.Write(path, Export(hydra), Configuration.Encoding);
    }

    public string Export(IHydra hydra)
    {
      var stb = new StringBuilder();
      foreach (var csel in hydra.CorporaAndDocumentGuids)
      {
        var corpus = hydra.GetCorpus(csel.Key);
        var layer = corpus?.GetLayers(LayerDisplayname).FirstOrDefault();
        if (layer == null)
          continue;

        foreach (var dsel in csel.Value)
        {
          if (!layer.ContainsDocument(dsel))
            continue;

          stb.AppendLine(layer.GetReadableDocumentByGuid(dsel).ConvertToPlainText());
        }
      }
      return stb.ToString();
    }

    public string LayerDisplayname { get; set; } = "Wort";
  }
}