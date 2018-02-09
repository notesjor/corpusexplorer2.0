#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Model.Export.Abstract;
using CorpusExplorer.Sdk.Model.Interface;
using Polenter.Serialization;

#endregion

namespace CorpusExplorer.Core.Exporter
{
  public class ExporterXml : AbstractExporter
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
      path = path.Replace(".xml", "");
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      var serializer = new SharpSerializer();

      foreach (var csel in hydra.CorporaAndDocumentGuids)
      {
        var root = CombineAndEnsureDirectoryExsists(path, csel.ToString());

        // Erzeuge Index.xml (Guid > Dokumentnamen - Dictionary)
        using (var fs = new FileStream(Path.Combine(root, "doc.index.xml"), FileMode.Create, FileAccess.Write))
          serializer.Serialize(
            csel.Value.ToDictionary(x => x, hydra.GetDocumentDisplayname),
            fs);

        var corpus = hydra.GetCorpus(csel.Key);

        // Erzeuge Index.xml (Guid > Layernamen - Dictionary)
        using (var fs = new FileStream(Path.Combine(root, "layer.index.xml"), FileMode.Create, FileAccess.Write))
          serializer.Serialize(
            corpus.LayerGuidAndDisplaynames.ToDictionary(x => x.Key, x => x.Value),
            fs);

        // Speichere alle Dokumente
        foreach (var dsel in csel.Value)
        {
          var dpath = CombineAndEnsureDirectoryExsists(root, dsel.ToString());

          // Speichere die Dokument-Metadaten
          using (var fs = new FileStream(Path.Combine(dpath, "doc.meta.xml"), FileMode.Create, FileAccess.Write))
            serializer.Serialize(corpus.GetDocumentMetadata(dsel), fs);

          var list = new List<Guid>();

          // Gebe die Layerdaten des Dokuments aus
          foreach (var layer in corpus.Layers)
          {
            if (!layer.ContainsDocument(dsel))
              continue;

            var lguid = layer.Guid;
            list.Add(lguid);
            var lpath = CombineAndEnsureDirectoryExsists(dpath, lguid.ToString());

            using (var fs = new FileStream(Path.Combine(lpath, "doc.data.xml"), FileMode.Create, FileAccess.Write))
              serializer.Serialize(
                layer.GetReadableDocumentByGuid(dsel).Select(d => d.ToArray()).ToArray(),
                fs);
          }

          using (var fs = new FileStream(Path.Combine(dpath, "layer.info.xml"), FileMode.Create, FileAccess.Write))
            serializer.Serialize(list.ToArray(), fs);
        }
      }
    }
  }
}