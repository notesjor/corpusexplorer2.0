#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using Polenter.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter
{
  public class ExporterXml : AbstractExporter
  {
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
        using (var bs = new BufferedStream(fs))
        {
          serializer.Serialize(csel.Value.ToDictionary(x => x, hydra.GetDocumentDisplayname), bs);
        }

        var corpus = hydra.GetCorpus(csel.Key);

        // Erzeuge Index.xml (Guid > Layernamen - Dictionary)
        using (var fs = new FileStream(Path.Combine(root, "layer.index.xml"), FileMode.Create, FileAccess.Write))
        using (var bs = new BufferedStream(fs))
        {
          serializer.Serialize(corpus.LayerGuidAndDisplaynames.ToDictionary(x => x.Key, x => x.Value), bs);
        }

        // Speichere alle Dokumente
        foreach (var dsel in csel.Value)
        {
          var dpath = CombineAndEnsureDirectoryExsists(root, dsel.ToString());

          // Speichere die Dokument-Metadaten
          using (var fs = new FileStream(Path.Combine(dpath, "doc.meta.xml"), FileMode.Create, FileAccess.Write))
          using (var bs = new BufferedStream(fs))
          {
            serializer.Serialize(corpus.GetDocumentMetadata(dsel), bs);
          }

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
            using (var bs = new BufferedStream(fs))
            {
              serializer.Serialize(layer.GetReadableDocumentByGuid(dsel).Select(d => d.ToArray()).ToArray(), bs);
            }
          }

          using (var fs = new FileStream(Path.Combine(dpath, "layer.info.xml"), FileMode.Create, FileAccess.Write))
          using (var bs = new BufferedStream(fs))
          {
            serializer.Serialize(list.ToArray(), bs);
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