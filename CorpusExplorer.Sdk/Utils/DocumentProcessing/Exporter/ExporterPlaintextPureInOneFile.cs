using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter
{
  public class ExporterPlaintextPureInOneFile : AbstractExporter
  {
    public string LayerDisplayname { get; set; } = "Wort";

    public override void Export(IHydra hydra, string path)
    {
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        Export(hydra, fs);
    }

    public string Export(IHydra hydra)
    {
      using (var ms = new MemoryStream())
      {
        Export(hydra, ms);
        return Encoding.UTF8.GetString(ms.ToArray());
      }
    }

    private void Export(IHydra hydra, Stream stream)
    {
      using (var writer = new StreamWriter(stream, Configuration.Encoding, 4096, true))
      {
        foreach (var csel in hydra.CorporaAndDocumentGuids)
        {
          var layer = hydra.GetCorpus(csel.Key)?.GetLayers(LayerDisplayname)?.FirstOrDefault();
          if (layer == null)
            continue;

          foreach (var dsel in csel.Value)
          {
            if (!layer.ContainsDocument(dsel))
              continue;

            writer.WriteLine(layer.GetReadableDocumentByGuid(dsel).ReduceDocumentToText());
          }
        }
      }
    }
  }
}