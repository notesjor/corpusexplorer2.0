using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter
{
  public class ExporterConll : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      var dir = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path));
      if (!Directory.Exists(dir))
        Directory.CreateDirectory(dir);

      foreach (var csel in hydra.CorporaAndDocumentGuids)
      {
        var corpus = hydra.GetCorpus(csel.Key);
        if (corpus.Layers.Count() > 9 && corpus.GetCorpusMetadata("IMPORT_FROM") is string from && from == "CoNLL")
          foreach (var dsel in csel.Value)
          {
            var layers = hydra.GetReadableMultilayerDocument(dsel)
                              .ToDictionary(x => x.Key, x => x.Value.Select(y => y.ToArray()).ToArray());
            var first = layers["ID"];
            var stb = new StringBuilder();
            for (var i = 0; i < first.Length; i++)
            {
              for (var j = 0; j < first[i].Length; j++)
                stb.AppendLine(string.Join("\t", ImporterConll._layerNames.Select(name => layers[name][i][j])));
              stb.AppendLine();
            }

            FileIO.Write(Path.Combine(dir, dsel.ToString("N") + ".conll"), stb.ToString(), Configuration.Encoding);
          }
        else
          foreach (var dsel in csel.Value)
          {
            var layers = hydra.GetReadableMultilayerDocument(dsel)
                              .ToDictionary(x => x.Key, x => x.Value.Select(y => y.ToArray()).ToArray());
            var first = layers.First().Value;
            var stb = new StringBuilder();
            for (var i = 0; i < first.Length; i++)
            {
              for (var j = 0; j < first[i].Length; j++)
              {
                var list = new List<string>();
                foreach (var name in ImporterConll._layerNames)
                  if (name == "ID")
                    list.Add(layers.ContainsKey("ID") ? layers[name][i][j] : (j + 1).ToString());
                  else
                    list.Add(layers.ContainsKey(name) ? layers[name][i][j] : "_");
                stb.AppendLine(string.Join("\t", list));
              }

              stb.AppendLine();
            }

            FileIO.Write(Path.Combine(dir, dsel.ToString("N") + ".conll"), stb.ToString(), Configuration.Encoding);
          }
      }
    }
  }
}