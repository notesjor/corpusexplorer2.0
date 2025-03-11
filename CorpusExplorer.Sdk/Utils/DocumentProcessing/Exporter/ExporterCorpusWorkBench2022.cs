using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter
{
  public class ExporterCorpusWorkBench2022 : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      var prototype = hydra.GetDocumentMetadataPrototypeOnlyProperties().ToArray();

      List<string> layerNames = null;

      using (var fsCorpus = new FileStream(path, FileMode.Create, FileAccess.Write))
      using (var wsCorpus = new StreamWriter(fsCorpus, Encoding.UTF8))
      using (var fsMeta = new FileStream(path + ".meta", FileMode.Create, FileAccess.Write))
      using (var wsMeta = new StreamWriter(fsMeta, Encoding.UTF8))
      {
        var textId = 0;

        foreach (var csel in hydra.CorporaAndDocumentGuids)
          foreach (var dsel in csel.Value)
          {
            try
            {
              var layers = hydra.GetReadableMultilayerDocument(dsel).ToDictionary(x => x.Key, x => x.Value.Select(y => y.ToArray()).ToArray());
              if (!layers.ContainsKey("Wort"))
                continue;

              var stb = new StringBuilder();
              var date = hydra.GetDocumentMetadata(dsel, "Datum", DateTime.MinValue);
              stb.Append(date == DateTime.MinValue
                                 ? $"<text id=\"{textId}\""
                                 : $"<text id=\"{textId}\" date=\"{date:yyyy-MM-dd}\" yearmonth=\"{date:yyyy-MM}\" year=\"{date:yyyy}\"");

              var meta = hydra.GetDocumentMetadata(dsel).ToDictionary(x => x.Key, x => x.Value);
              foreach (var x in meta)
                stb.Append($" {x.Key.Replace(" ", "_")}=\"{x.Value?.ToString()?.Replace("\"", "'")}\"");
              
              textId++;
              stb.Append(">\n");

              var first = layers["Wort"];
              if (first.Length == 0)
                continue;
              layers.Remove("Wort");

              if (layerNames == null)
              {
                layerNames = layers.Keys.ToList();
                layerNames.Insert(0, "Wort");
              }

              for (var i = 0; i < first.Length; i++)
              {
                if (UseSentenceTag)
                  stb.Append("<s>\n");

                for (var j = 0; j < first[i].Length; j++)
                {
                  stb.Append($"{first[i][j]}\t{string.Join("\t", layers.Select(layer => layer.Value[i][j]))}\n");
                }

                if (UseSentenceTag)
                  stb.Append("</s>\n");
              }

              stb.Append($"</text>\n");

              wsMeta.WriteLine($"{textId}\t{string.Join("\t", prototype.Select(x => meta.ContainsKey(x) ? meta[x] : ""))}");
              wsCorpus.Write(stb.ToString());
            }
            catch
            {
              // ignore
            }
          }
      }

      File.WriteAllLines(path + ".layers", layerNames, Encoding.UTF8);
    }

    public bool UseSentenceTag { get; set; } = true;
  }
}
