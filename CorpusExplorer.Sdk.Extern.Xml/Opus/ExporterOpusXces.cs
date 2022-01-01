using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Opus
{
  public class ExporterOpusXces : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      Parallel.ForEach(hydra.DocumentGuids, Configuration.ParallelOptions, dsel =>
      {
        using (var fs = new FileStream(Path.Combine(path, $"{dsel:D}.xml"), FileMode.Create, FileAccess.Write))
        using (var buffer = new BufferedStream(fs))
        using (var writer = new StreamWriter(buffer, Encoding.UTF8))
        {
          writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
          writer.WriteLine("<document>");

          writer.WriteLine("<head>");
          foreach (var m in hydra.GetDocumentMetadata(dsel))
            writer.WriteLine($"\t<meta name=\"{SecurityElement.Escape(m.Key)}\" content=\"{SecurityElement.Escape(m.Value.ToString())}\"/>");
          writer.WriteLine("</head>");

          var tmp = hydra.GetReadableMultilayerDocument(dsel).ToDictionary(x => x.Key, x => x.Value.Select(y => y.ToArray()).ToArray());
          var lead = tmp["Wort"];
          tmp.Remove("Wort");

          for (var i = 0; i < lead.Length; i++)
          {
            writer.WriteLine($"<s id=\"{i + 1}\">");
            for (var j = 0; j < lead[i].Length; j++)
            {
              var lem = GetValue(ref tmp, "Lemma", i, j, "lem");
              var tre = GetValue(ref tmp, "POS", i, j, "tree");
              writer.WriteLine($"\t<w {lem} {tre} id=\"w{i + 1}.{j + 1}\">{lead[i][j]}</w>");
            }
            writer.WriteLine("</s>");
          }

          writer.WriteLine("</document>");
        }
      });
    }

    private string GetValue(ref Dictionary<string, string[][]> tmp, string layerDisplayname, int i, int j, string xcesLayerName)
    {
      try
      {
        return tmp.ContainsKey(layerDisplayname) ? $"{xcesLayerName}=\"{tmp[layerDisplayname][i][j]}\"" : "";
      }
      catch
      {
        return "";
      }
    }
  }
}
