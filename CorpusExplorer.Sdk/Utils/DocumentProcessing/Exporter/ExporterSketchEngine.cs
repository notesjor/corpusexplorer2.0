using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter
{
  public class ExporterSketchEngine : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      using (var bs = new BufferedStream(fs))
      using (var writer = new StreamWriter(bs, Encoding.UTF8))
      {
        foreach (var csel in hydra.CorporaAndDocumentGuids)
          foreach (var dsel in csel.Value)
          {
            writer.WriteLine($"<doc id=\"CorpusExplorerID_{dsel:D}\" filename=\"{GetFilename(hydra, dsel)}\" parent_folder=\"upload\">");

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
                stb.AppendLine("<s>");

                for (var j = 0; j < first[i].Length; j++)
                {
                  stb.AppendLine($"{first[i][j]}\t{string.Join("\t", layers.Select(layer => layer.Value[i][j]))}");
                }

                stb.AppendLine("</s>");
              }
            }
            catch
            {
              continue;
            }

            writer.WriteLine(stb.ToString());
            writer.WriteLine("</doc>");
          }
      }
    }

    private string GetFilename(IHydra hydra, Guid dsel)
    {
      var res = hydra.GetDocumentMetadata(dsel, "Titel", null);
      if(res!=null)
        return res;
      res = hydra.GetDocumentMetadata(dsel, "Filename", null);
      return res ?? $"{dsel:D}.txt";
    }
  }
}
