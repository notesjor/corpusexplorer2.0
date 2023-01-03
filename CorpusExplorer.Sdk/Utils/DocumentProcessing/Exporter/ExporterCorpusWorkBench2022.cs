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
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      using (var writer = new StreamWriter(fs, Encoding.UTF8))
      {
        writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        writer.WriteLine("<corpus>");

        var textId = 0;

        foreach (var csel in hydra.CorporaAndDocumentGuids)
          foreach (var dsel in csel.Value)
          {
            var date = hydra.GetDocumentMetadata(dsel, "Datum", DateTime.MinValue);
            writer.Write(date == DateTime.MinValue
                               ? $"<text id=\"{textId++}\""
                               : $"<text id=\"{textId++}\" date=\"{date:yyyy-MM-dd}\" yearmonth=\"{date:yyyy-MM}\" year=\"{date:yyyy}\"");

            foreach (var x in hydra.GetDocumentMetadata(dsel))
              writer.Write($" {x.Key.Replace(" ", "_")}=\"{x.Value}\"");

            writer.WriteLine(">");

            var layers = hydra.GetReadableMultilayerDocument(dsel).ToDictionary(x => x.Key, x => x.Value.Select(y => y.ToArray()).ToArray());
            if (!layers.ContainsKey("Wort") || !layers.ContainsKey("Lemma") || !layers.ContainsKey("POS"))
              continue;

            var stb = new StringBuilder();
            try
            {
              var first = layers["Wort"];
              layers.Remove("Wort");

              for (var i = 0; i < first.Length; i++)
              {
                if (UseSentenceTag)
                  stb.AppendLine("<s>");

                for (var j = 0; j < first[i].Length; j++)
                {
                  stb.AppendLine($"{first[i][j]}\t{string.Join("\t", layers.Select(layer => layer.Value[i][j]))}");
                }

                if (UseSentenceTag)
                  stb.AppendLine("</s>");
              }
            }
            catch
            {
              continue;
            }

            writer.WriteLine(stb.ToString());
            writer.WriteLine("</text>");
          }
        writer.WriteLine("</corpus>");
      }
    }

    public bool UseSentenceTag { get; set; } = true;
  }
}
