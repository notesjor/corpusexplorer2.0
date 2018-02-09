#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Model.Export.Abstract;
using CorpusExplorer.Sdk.Model.Interface;
using Newtonsoft.Json;

#endregion

namespace CorpusExplorer.Core.Exporter
{
  public class ExporterJson : AbstractExporter
  {
    private static string CombineAndEnsureDirectoryExsists(string pathA, string pathB)
    {
      var res = Path.Combine(pathA, pathB);
      if (!Directory.Exists(res))
        Directory.CreateDirectory(res);
      return res;
    }

    public override void Export(IHydra hydra, string path)
    {
      path = path.Replace(".json", "");
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      foreach (var csel in hydra.CorporaAndDocumentGuids)
      {
        var root = CombineAndEnsureDirectoryExsists(path, csel.Key.ToString());
        var corpus = hydra.GetCorpus(csel.Key);
        if (corpus == null)
          continue;

        // Erzeuge Index.json (Guid > Dokumentnamen - Dictionary)
        File.WriteAllText(
          Path.Combine(root, "doc.index.json"),
          JsonConvert.SerializeObject(
            csel.Value.ToDictionary(
              x => x,
              hydra.GetDocumentDisplayname)));

        // Erzeuge Index.json (Guid > Layernamen - Dictionary)
        File.WriteAllText(
          Path.Combine(root, "layer.index.json"),
          JsonConvert.SerializeObject(
            corpus.LayerGuidAndDisplaynames.ToDictionary(
              x => x.Key,
              x => x.Value)));

        // Speichere alle Dokumente
        foreach (var dsel in csel.Value)
        {
          var dpath = CombineAndEnsureDirectoryExsists(root, dsel.ToString());

          // Speichere die Dokument-Metadaten
          File.WriteAllText(
            Path.Combine(dpath, "doc.meta.json"),
            JsonConvert.SerializeObject(corpus.GetDocumentMetadata(dsel)));

          var list = new List<Guid>();

          // Gebe die Layerdaten des Dokuments aus
          foreach (var layer in corpus.Layers)
          {
            if (!layer.ContainsDocument(dsel))
              continue;

            var lguid = layer.Guid;
            list.Add(lguid);
            var lpath = CombineAndEnsureDirectoryExsists(dpath, lguid.ToString());

            File.WriteAllText(
              Path.Combine(lpath, "doc.data.json"),
              JsonConvert.SerializeObject(
                layer.GetReadableDocumentByGuid(dsel)
                     .Select(d => d.ToArray())
                     .ToArray()));
          }

          File.WriteAllText(Path.Combine(dpath, "layer.info.json"), JsonConvert.SerializeObject(list.ToArray()));
        }
      }
    }
  }
}