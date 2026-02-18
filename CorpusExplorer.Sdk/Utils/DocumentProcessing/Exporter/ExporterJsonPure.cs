#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using Newtonsoft.Json;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter
{
  public class ExporterJsonPure : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      path = path.Replace(".json", "");
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      foreach (var csel in hydra.CorporaAndDocumentGuids)
      {
        var root = CombineAndEnsureDirectoryExsists(path, csel.Key.ToString("N"));
        var corpus = hydra.GetCorpus(csel.Key);
        var layer = corpus?.GetLayers("Wort").SingleOrDefault();
        if (layer == null)
          continue;

        // Speichere alle Dokumente
        foreach (var dsel in csel.Value)
        {
          // Speichere die Dokument-Metadaten
          File.WriteAllText(Path.Combine(root, $"{dsel:N}.meta.json"),
                            JsonConvert.SerializeObject(corpus.GetDocumentMetadata(dsel)));

          if (!layer.ContainsDocument(dsel))
            continue;

          // Speichere den Wort-Layer
          File.WriteAllText(
            Path.Combine(root, $"{dsel:N}.data.json"),
            JsonConvert.SerializeObject(
              layer.GetReadableDocumentByGuid(dsel)
                .Select(d => d.ToArray())
                .ToArray()));
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
  }
}