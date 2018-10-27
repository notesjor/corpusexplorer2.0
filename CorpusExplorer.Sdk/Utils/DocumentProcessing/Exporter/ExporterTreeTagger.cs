using System.IO;
using System.Linq;
using System.Text;
using Bcs.IO;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter
{
  public class ExporterTreeTagger : AbstractExporter
  {
    public bool UseSentenceTag { get; set; }

    public override void Export(IHydra hydra, string path)
    {
      var dir = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path));
      if (!Directory.Exists(dir))
        Directory.CreateDirectory(dir);

      foreach (var csel in hydra.CorporaAndDocumentGuids)
      foreach (var dsel in csel.Value)
      {
        var layers = hydra.GetReadableMultilayerDocument(dsel)
          .ToDictionary(x => x.Key, x => x.Value.Select(y => y.ToArray()).ToArray());
        if (!layers.ContainsKey("Wort") || !layers.ContainsKey("Lemma") || !layers.ContainsKey("POS"))
          continue;

        var stb = new StringBuilder();
        try
        {
          var first = layers.First().Value;
          var wor = layers["Wort"];
          var lem = layers["Lemma"];
          var pos = layers["POS"];
          var phr = layers.ContainsKey("Phrase") ? layers["Phrase"] : null;

          for (var i = 0; i < first.Length; i++)
          {
            if (UseSentenceTag)
              stb.AppendLine("<s>");

            var phrase = string.Empty;

            for (var j = 0; j < first[i].Length; j++)
            {
              if (phr != null)
              {
                var nph = phr[i][j] ?? string.Empty;
                if (nph != phrase)
                {
                  if (!string.IsNullOrEmpty(phrase))
                    stb.AppendLine($"</{phrase}>");
                  phrase = nph;
                  if (!string.IsNullOrEmpty(phrase))
                    stb.AppendLine($"<{phrase}>");
                }
              }

              stb.AppendLine($"{wor[i][j]}\t{pos[i][j]}\t{lem[i][j]}");
            }

            if (!string.IsNullOrEmpty(phrase))
              stb.AppendLine($"</{phrase}>");

            if (UseSentenceTag)
              stb.AppendLine("</s>");
          }
        }
        catch
        {
          continue;
        }

        FileIO.Write(Path.Combine(dir, dsel.ToString("N") + ".treetagger"), stb.ToString(), Configuration.Encoding);
      }
    }
  }
}