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
  public class ExporterJson : AbstractExporter
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
        if (corpus == null)
          continue;

        // Erzeuge Index.json (Guid > Dokumentnamen - Dictionary)
        File.WriteAllText(
                          Path.Combine(root, "doc.index.json"),
                          JsonConvert.SerializeObject(
                                                      csel.Value.ToDictionary(
                                                                              x => x.ToString("N"),
                                                                              hydra.GetDocumentDisplayname)));

        // Erzeuge Index.json (Guid > Layernamen - Dictionary)
        File.WriteAllText(
                          Path.Combine(root, "layer.index.json"),
                          JsonConvert.SerializeObject(
                                                      corpus.LayerGuidAndDisplaynames.ToDictionary(
                                                                                                   x => x.Key.ToString("N"),
                                                                                                   x => x.Value)));

        // Speichere alle Dokumente
        foreach (var dsel in csel.Value)
        {
          var dpath = CombineAndEnsureDirectoryExsists(root, dsel.ToString("N"));

          // Speichere die Dokument-Metadaten
          File.WriteAllText(
                            Path.Combine(dpath, "doc.meta.json"),
                            JsonConvert.SerializeObject(corpus.GetDocumentMetadata(dsel)));

          // Gebe die Layerdaten des Dokuments aus
          foreach (var layer in corpus.Layers)
          {
            if (!layer.ContainsDocument(dsel))
              continue;

            var lpath = CombineAndEnsureDirectoryExsists(dpath, layer.Guid.ToString("N"));

            File.WriteAllText(
                              Path.Combine(lpath, "doc.data.json"),
                              JsonConvert.SerializeObject(
                                                          layer.GetReadableDocumentByGuid(dsel)
                                                               .Select(d => d.ToArray())
                                                               .ToArray()));
          }
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