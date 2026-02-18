using CorpusExplorer.Sdk.Extern.Xml.Ids.Helper;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CorpusExplorer.Sdk.Extern.Xml.Properties;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml
{
  public class ExporterI5Plus : AbstractExporter
  {
    public string LicenseName { get; set; } = "CC-BY-NC-ND-4.0-DE";

    private Regex _excapeL0 = new Regex(@"[\x00-\x08\x0B\x0C\x0E-\x1F]");
    private Dictionary<string, string> _escapeL1 = new Dictionary<string, string>
    {
      { "&", "&amp;" },
      { "<", "&lt;" },
      { ">", "&gt;" },
    };
    private Dictionary<string, string> _escapeL2 = new Dictionary<string, string>
    {
      { "&", "&amp;" },
      { "<", "&lt;" },
      { ">", "&gt;" },
      { "\"", "&quot;" },
      { "'", "&apos;" },
    };

    public override void Export(IHydra hydra, string path)
    {
      var csigle = Path.GetFileNameWithoutExtension(path).Replace("_", "/");

      var num = 0;
      path = path.Replace(".i5", "").Replace(".xml", "");
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

      foreach (var dsel in hydra.DocumentGuids)
      {
        var sigle = $"{csigle}.{num:D5}";
        var date = hydra.GetDocumentMetadata(dsel, "Datum", DateTime.MinValue);

        using (var fs = new FileStream(Path.Combine(path, $"{sigle.Replace("/", "_")}.i5.xml"), FileMode.Create, FileAccess.Write))
        using (var writer = new StreamWriter(fs, Encoding.UTF8))
        {
          writer.Write(Resources.Template_Ids_I5Plus
            .Replace("{sigle}", sigle)
            .Replace("{bibl}", GenerateBibLong(hydra.GetDocumentMetadata(dsel)))
            .Replace("{bibl_short}", GenerateTitle(hydra.GetDocumentMetadata(dsel)))
            .Replace("{license}", LicenseName)
            .Replace("{export_data_year}", DateTime.Now.ToString("yyyy"))
            .Replace("{title}", GenerateTitle(hydra.GetDocumentMetadata(dsel)))
            .Replace("{doc_date_year}", date.ToString("yyyy"))
            .Replace("{doc_date_month}", date.ToString("MM"))
            .Replace("{doc_date_day}", date.ToString("dd"))
            .Replace("{doc_date_dot}", date.ToString("yyyy.MM.dd"))
            .Replace("{XENODATA}", ExportXenodataHelper.GenerateXenoData(hydra.GetDocumentMetadata(dsel)))
            .Replace("{ANNODATA}",
              GenerateAnnoData(hydra.GetReadableMultilayerDocument(dsel)?
              .ToDictionary(x => x.Key,
              x => x.Value?.Select(y => y?.ToArray())?.ToArray())))
            );
        }

        num++;
      }
    }

    private string GenerateAnnoData(Dictionary<string, string[][]> multiDoc)
    {
      var nameRes = new Dictionary<string, string> { { "Wort", "" }, { "Lemma", "" }, { "POS", "" } };
      var keys = nameRes.Keys.ToArray();
      foreach (var k in keys)
        foreach (var key in multiDoc.Keys.Where(key => key.Contains(k)))
          nameRes[k] = key;

      var ws = multiDoc[nameRes["Wort"]];
      var ls = multiDoc[nameRes["Lemma"]];
      var ps = multiDoc[nameRes["POS"]];

      var stb = new StringBuilder();
      stb.Append("<p>");
      for (var i = 0; i < ws.Length; i++)
      {
        stb.Append("<s>");
        for (var j = 0; j < ws[i].Length; j++)
        {
          var w = EscapeL1(ws[i][j]);
          var l = ls != null && i < ls.Length && j < ls[i].Length ? EscapeL2(ls[i][j]) : "";
          var p = ps != null && i < ps.Length && j < ps[i].Length ? EscapeL2(ps[i][j]) : "";
          stb.Append($"<w lemma=\"{l}\" pos=\"{p}\">{w}</w>");
        }
        stb.Append("</s>");
      }
      stb.Append("</p>");

      return stb.ToString();
    }

    private string GenerateTitle(Dictionary<string, object> meta)
    {
      var author = meta.ContainsKey("Autor") ? meta["Autor"]?.ToString() : "N.N.";
      var date = meta.ContainsKey("Datum") && meta["Datum"] is DateTime dt && dt.Year > 1 ? dt.ToString("yyyy") : "????";
      var title = meta.ContainsKey("Titel") && !string.IsNullOrEmpty(meta["Titel"]?.ToString()) ? $": {meta["Titel"]}" : "";

      return $"{author} ({date}): {title}";
    }

    private string GenerateBibLong(Dictionary<string, object> meta)
    {
      var author = meta.ContainsKey("Autor") ? meta["Autor"]?.ToString() : "N.N.";
      var date = meta.ContainsKey("Datum") && meta["Datum"] is DateTime dt && dt.Year > 1 ? dt.ToString("yyyy") : "????";
      var title = meta.ContainsKey("Titel") && !string.IsNullOrEmpty(meta["Titel"]?.ToString()) ? $": {meta["Titel"]}" : "";
      var verlag = meta.ContainsKey("Verlag") && !string.IsNullOrEmpty(meta["Verlag"]?.ToString()) ? $": {meta["Verlag"]}" : "";
      var url = meta.ContainsKey("Url") && !string.IsNullOrEmpty(meta["Url"]?.ToString()) ? $": {meta["Url"]}" : "";

      return $"{author} ({date}): {title}{(verlag == "" ? "" : $" In: {verlag}")}{(url == "" ? "" : $" URL: {url}")}";
    }

    private string EscapeL1(string text)
      => Escape(text, ref _escapeL1);

    private string EscapeL2(string text)
      => Escape(text, ref _escapeL2);

    private string Escape(string text, ref Dictionary<string, string> escapeDict)
      => _excapeL0.Replace(escapeDict.Aggregate(text, (current, kvp) => current.Replace(kvp.Key, kvp.Value)), string.Empty);
  }
}