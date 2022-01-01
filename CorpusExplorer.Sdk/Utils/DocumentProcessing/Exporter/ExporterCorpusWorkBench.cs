﻿using System;
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
  public class ExporterCorpusWorkBench : AbstractExporter
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
            writer.WriteLine(date == DateTime.MinValue
                               ? $"<text id=\"{textId++}\">"
                               : $"<text id=\"{textId++}\" date=\"{date:yyyy-MM-dd}\" yearmonth=\"{date:yyyy-MM}\" year=\"{date:yyyy}\">");

            // Schreibe zusätzliche Metadaten in CWB (zulässig in alten Versionen)
            // Bsp. 1: <text_collection historical>
            // Bsp. 2: <text_period 1700-1750>
            var killTags = new List<string>();
            foreach (var x in hydra.GetDocumentMetadata(dsel))
            {
              var tag = $"text_{x.Key.Replace(" ", "_")}";
              writer.WriteLine($"<{tag} {x.Value}>");
              killTags.Add($"</{tag}>");
            }

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
            foreach (var killTag in killTags)
              writer.WriteLine(killTag);
            writer.WriteLine("</text>");
          }
        writer.WriteLine("</corpus>");
      }
    }

    public bool UseSentenceTag { get; set; } = true;
  }
}
