using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Ids.Helper;
using CorpusExplorer.Sdk.Extern.Xml.Properties;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml
{
  public class ExporterI5 : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      var csigle = Path.GetFileNameWithoutExtension(path);
      var packages = ExportPackageHelper.MakePackages(hydra);

      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      using (var writer = new StreamWriter(fs, Encoding.UTF8))
      {
        writer.Write(Resources.Template_Ids_I5_Head
          .Replace("{export_date}", DateTime.Now.ToString("yyyy-MM-dd"))
          .Replace("{export_data_year}", DateTime.Now.ToString("yyyy"))
          .Replace("{corpus_id}", csigle));

        foreach (var package in packages)
        {
          //var subcsigle = $"{csigle}/{package.Key}";          
          var i = 0;

          writer.Write(Resources.Template_Ids_I5_Doc_Head.Replace("{cluster_id}", package.Key));

          foreach (var dsel in package.Value)
          {
            i++;

            var author = hydra.GetDocumentMetadata(dsel, "Autor", "");
            var date = hydra.GetDocumentMetadata(dsel, "Datum", DateTime.MinValue);

            var doc = string.Join("\r\n", hydra.GetReadableDocument(dsel, "Wort").Select(x => $"<s>{MakeSentence(x)}</s>"));

            writer.Write(Resources.Template_Ids_I5_Doc_Text
              .Replace("{cluster_id}", package.Key)
              .Replace("{text_id}", $"{csigle}_{package.Key}.{i:D6}")
              .Replace("{title}", hydra.GetDocumentDisplayname(dsel))
              .Replace("{guid}", dsel.ToString("N"))
              .Replace("{guid_short}", dsel.ToString("N").Substring(0, 8))
              .Replace("{author}", author)
              .Replace("{doc_date}", date.ToString("yyyy-MM-dd"))
              .Replace("{doc_date_year}", date.ToString("yyyy"))
              .Replace("{doc_date_month}", date.ToString("MM"))
              .Replace("{doc_date_day}", date.ToString("dd"))
              .Replace("{text}", doc)
              .Replace("{XENODATA}", ExportXenodataHelper.GenerateXenoData(hydra.GetDocumentMetadata(dsel)))
            );
          }

          writer.Write(Resources.Template_Ids_I5_Doc_Foot);          
        }

        writer.Write(Resources.Template_Ids_I5_Foot);
      }
    }

    private string MakeSentence(IEnumerable<string> sentence)
    {
      var res = string.Join(" ", sentence) + " ";
      res = res.Replace(" . ", ". ");
      res = res.Replace(" , ", ", ");
      res = res.Replace(" ! ", "! ");
      res = res.Replace(" ? ", "? ");
      res = res.Replace(" \" ", "\" ");
      res = res.Replace(" : ", ": ");
      res = res.Replace(" ; ", "; ");
      res = res.Replace("  ", " ");

      return res.Trim();
    }
  }
}
