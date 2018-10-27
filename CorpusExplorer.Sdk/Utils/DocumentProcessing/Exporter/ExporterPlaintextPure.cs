using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter
{
  public class ExporterPlaintextPure : AbstractExporter
  {
    public string LayerDisplayname { get; set; } = "Wort";

    public override void Export(IHydra hydra, string path)
    {
      path = path.Replace(".txt", "");
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      foreach (var csel in hydra.CorporaAndDocumentGuids)
      {
        var root = CombineAndEnsureDirectoryExsists(path, csel.Key.ToString("N"));

        // Erzeuge Index.xml (Guid > Dokumentnamen - Dictionary)
        FileIO.Write(
          Path.Combine(root, "documents.txt"),
          SerializeDictionary(csel.Value.ToDictionary(x => x.ToString("N"), hydra.GetDocumentDisplayname)),
          Configuration.Encoding);

        var corpus = hydra.GetCorpus(csel.Key);
        var layer = corpus?.GetLayers(LayerDisplayname)?.FirstOrDefault();
        if (layer == null)
          continue;

        // Speichere alle Dokumente
        foreach (var dsel in csel.Value)
        {
          if (!layer.ContainsDocument(dsel))
            continue;

          // Speichere die Dokument-Metadaten
          FileIO.Write(
            Path.Combine(root, $"{dsel:N}.meta.txt"),
            SerializeDictionary(hydra.GetDocumentMetadata(dsel)),
            Configuration.Encoding);

          // Gebe die Layerdaten des Dokuments aus
          FileIO.Write(
            Path.Combine(root, $"{dsel:N}.text.txt"),
            layer.GetReadableDocumentByGuid(dsel).ConvertToPlainText(),
            Configuration.Encoding);
        }
      }
    }

    private static string CombineAndEnsureDirectoryExsists(string pathA, string pathB)
    {
      var res = Path.Combine(pathA, pathB);
      if (!Directory.Exists(res))
        Directory.CreateDirectory(res);
      return res;
    }

    private static string SerializeDictionary<TKey, TValue>(Dictionary<TKey, TValue> dic)
    {
      var stb = new StringBuilder();
      foreach (var entry in dic)
        stb.Append($"{entry.Key}\t{entry.Value}\r\n");
      return stb.ToString();
    }
  }
}