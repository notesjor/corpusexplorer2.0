using CorpusExplorer.Sdk.Extern.Xml.Ids.Helper;
using CorpusExplorer.Sdk.Extern.Xml.Properties;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml
{
  public class ExporterI5 : AbstractExporter
  {
    public string LicenseName { get; set; } = "https://creativecommons.org/licenses/by-nc-sa/4.0/deed.de";

    private Regex _excapeL0 = new Regex(@"[\x00-\x08\x0B\x0C\x0E-\x1F]");
    private Dictionary<string, string> _escapeL1 = new Dictionary<string, string>
    {
      { "&", "&amp;" },
      { "<", "&lt;" },
      { ">", "&gt;" },

      { "\u0002", "" },
    };
    private Dictionary<string, string> _escapeL2 = new Dictionary<string, string>
    {
      { "&", "&amp;" },
      { "<", "&lt;" },
      { ">", "&gt;" },
      { "\"", "&quot;" },
      { "'", "&apos;" },
      { "\u0002", "" },
    };

    public override void Export(IHydra hydra, string path)
    {
      var csigle = Path.GetFileNameWithoutExtension(path);
      var packages = ExportPackageHelper.MakePackages(csigle, hydra);

      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      using (var writer = new StreamWriter(fs, Encoding.UTF8))
      {
        writer.Write(Resources.Template_Ids_I5_Head
          .Replace("{export_date}", DateTime.Now.ToString("yyyy-MM-dd"))
          .Replace("{export_data_year}", DateTime.Now.ToString("yyyy"))
          .Replace("{corpus_id}", csigle));

        foreach (var package in packages)
        {
          var i = 0;

          writer.Write(Resources.Template_Ids_I5_Doc_Head
            .Replace("{cluster_id}", package.Key)
            .Replace("{title}", EscapeL2($"{csigle} ({package.Key.Replace($"{csigle}_", "")})")));

          foreach (var dsel in package.Value)
          {
            i++;

            var author = hydra.GetDocumentMetadata(dsel, "Autor", "");
            var date = hydra.GetDocumentMetadata(dsel, "Datum", DateTime.MinValue);

            var doc = EscapeL1(string.Join("\r\n", hydra.GetReadableDocument(dsel, "Wort").Select(x => MakeSentence(x))));
            var meta = hydra.GetDocumentMetadata(dsel);

            writer.Write(Resources.Template_Ids_I5_Doc_Text
              .Replace("{cluster_id}", package.Key)
              .Replace("{text_id}", $"{package.Key}.{i:D6}")
              .Replace("{title}", EscapeL2(MakeTitle(meta)))
              .Replace("{guid}", dsel.ToString("N"))
              .Replace("{guid_short}", dsel.ToString("N").Substring(0, 8))
              .Replace("{author}", EscapeL2(author))
              .Replace("{license}", LicenseName)
              .Replace("{doc_date}", date.ToString("yyyy-MM-dd"))
              .Replace("{doc_date_year}", date.ToString("yyyy"))
              .Replace("{doc_date_month}", date.ToString("MM"))
              .Replace("{doc_date_day}", date.ToString("dd"))
              .Replace("{doc_place}", meta.TryGetValue("Ort", out var value) ? value?.ToString() : "")
              .Replace("{text}", doc)
              .Replace("{XENODATA}", ExportXenodataHelper.GenerateXenoData(meta))
            );
          }

          writer.Write(Resources.Template_Ids_I5_Doc_Foot);
        }

        writer.Write(Resources.Template_Ids_I5_Foot);
      }
    }

    private string MakeTitle(Dictionary<string, object> meta)
    {
      var author = meta.ContainsKey("Autor") ? meta["Autor"]?.ToString() : "N.N.";
      var date = meta.ContainsKey("Datum") && meta["Datum"] is DateTime dt && dt.Year > 1 ? dt.ToString("yyyy") : "????";
      var title = meta.ContainsKey("Titel") && !string.IsNullOrEmpty(meta["Titel"]?.ToString()) ? $": {meta["Titel"]}" : "";

      return $"{author} ({date}): {title}";
    }

    private string MakeSentence(IEnumerable<string> sentence)
    {
      var res = string.Join(" ", sentence) + " ";
      res = res.Replace(" . ", ". ");
      res = res.Replace(" , ", ", ");
      res = res.Replace(" ! ", "! ");
      res = res.Replace(" ? ", "? ");
      res = res.Replace(" : ", ": ");
      res = res.Replace(" ; ", "; ");
      res = res.Replace("  ", " ");

      return res.Trim();
    }

    private string EscapeL1(string text)
      => Escape(text, ref _escapeL1);

    private string EscapeL2(string text)
      => Escape(text, ref _escapeL2);

    private string Escape(string text, ref Dictionary<string, string> escapeDict)
      => _excapeL0.Replace(escapeDict.Aggregate(text, (current, kvp) => current.Replace(kvp.Key, kvp.Value)), string.Empty);
  }
}
