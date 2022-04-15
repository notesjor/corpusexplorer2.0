using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter
{
  public class ExporterPlaintext : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      path = path.Replace(".txt", "");
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      foreach (var csel in hydra.CorporaAndDocumentGuids)
      {
        var root = CombineAndEnsureDirectoryExsists(path, csel.Key.ToString());

        var corpus = hydra.GetCorpus(csel.Key);
        if (corpus == null)
          continue;

        // Erzeuge Index.xml (Guid > Dokumentnamen - Dictionary)
        FileIO.Write(
                     Path.Combine(root, "doc.index.txt"),
                     SerializeDictionary(csel.Value.ToDictionary(x => x, hydra.GetDocumentDisplayname)),
                     Configuration.Encoding);

        // Erzeuge Index.xml (Guid > Layernamen - Dictionary)
        FileIO.Write(
                     Path.Combine(root, "layer.index.txt"),
                     SerializeDictionary(hydra.LayerGuidAndDisplaynames.ToDictionary(x => x.Key, x => x.Value)),
                     Configuration.Encoding);

        // Speichere alle Dokumente
        foreach (var dsel in csel.Value)
        {
          var dpath = CombineAndEnsureDirectoryExsists(root, dsel.ToString("N"));

          // Speichere die Dokument-Metadaten
          FileIO.Write(
                       Path.Combine(dpath, "doc.meta.txt"),
                       SerializeDictionary(hydra.GetDocumentMetadata(dsel)),
                       Configuration.Encoding);

          var list = new List<Guid>();

          // Gebe die Layerdaten des Dokuments aus
          foreach (var layer in corpus.Layers)
          {
            if (!layer.ContainsDocument(dsel))
              continue;

            var lguid = layer.Guid;
            list.Add(lguid);
            var lpath = CombineAndEnsureDirectoryExsists(dpath, lguid.ToString());

            FileIO.Write(
                         Path.Combine(lpath, "doc.data.txt"),
                         layer.GetReadableDocumentByGuid(dsel).Select(d => string.Join("\t", d)).ToArray(),
                         Configuration.Encoding);
          }

          FileIO.Write(Path.Combine(dpath, "layer.info.txt"), list.Select(x => x.ToString()).ToArray(),
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