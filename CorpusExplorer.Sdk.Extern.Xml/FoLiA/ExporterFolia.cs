using Bcs.IO;
using CorpusExplorer.Sdk.Extern.Xml.Properties;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Xml.FoLiA
{
  public class ExporterFolia : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      path = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path));
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      foreach (var dsel in hydra.DocumentGuids)
      {
        var rawMulti = hydra.GetReadableMultilayerDocument(dsel).ExtractLayer("Wort", out var rawLayer);
        var baseLayer = rawLayer.Select(x => x.ToArray()).ToArray();
        var multi = rawMulti.ToDictionary(x => x.Key, x => x.Value.Select(y => y.ToArray()).ToArray());
        var keys = multi.Keys.ToArray();

        var guid = dsel.ToString("N");

        var stb1 = new StringBuilder();
        for (int s = 0; s < baseLayer.Length; s++)
        {
          var sStr = s.ToString();

          var stb2 = new StringBuilder();
          for (var w = 0; w < baseLayer[s].Length; w++)
          {
            var wStr = w.ToString();

            var stb3 = new StringBuilder();
            foreach (var k in keys)
              stb3.AppendLine($"<{k.ToLower()} class=\"{Clean(multi[k][s][w])}\"/>");
            stb2.AppendLine(Resources.Template_FoLiA_Token
              .Replace("{{GUID}}", guid)
              .Replace("{{SID}}", sStr)
              .Replace("{{WID}}", wStr)
              .Replace("{{WORD}}", Clean(baseLayer[s][w]))
              .Replace("{{LAYERS}}", stb3.ToString()));
          }

          stb1.AppendLine(Resources.Template_FoLiA_Sentence
            .Replace("{{GUID}}", guid)
            .Replace("{{SID}}", sStr)
            .Replace("{{TOKEN}}", stb2.ToString()));
        }
        var doc = new StringBuilder(Resources.Template_FoLiA_Document);
        doc = doc.Replace("{{GUID}}", guid);
        doc = doc.Replace("{{TEXT}}", stb1.ToString());

        var stbM = new StringBuilder();
        var meta = hydra.GetDocumentMetadata(dsel);
        foreach(var m in meta)
          stbM.AppendLine($"<meta id=\"{Clean(m.Key)}\">{Clean(m.Value?.ToString())}</meta>");
        doc = doc.Replace("{{META}}", stbM.ToString());
        FileIO.Write(Path.Combine(path, $"{guid}.xml"), doc.ToString());
      }
    }

    private static string Clean(string text)
    {
      return text.Replace("\"", "''");
    }
  }
}
