using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Properties;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml
{
  public class ExporterI5 : AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
      using (var writer = new StreamWriter(fs, Encoding.UTF8))
      {
        writer.Write(Resources.Template_Ids_I5_Head
          .Replace("{export_date}", DateTime.Now.ToString("yyyy.MM.dd"))
          .Replace("{export_date_year}", DateTime.Now.ToString("yyyy")));

        var clusterId = 1;
        var textId = 0;
        
        writer.Write(Resources.Template_Ids_I5_Doc_Head.Replace("{cluster_id}", clusterId.ToString()));

        foreach (var dsel in hydra.DocumentGuids)
        {
          textId++;
          if(textId > 99999)
          {
            writer.Write(Resources.Template_Ids_I5_Doc_Foot);
            clusterId++;
            textId = 1;
            writer.Write(Resources.Template_Ids_I5_Doc_Head.Replace("{cluster_id}", clusterId.ToString()));
          }

          var author = hydra.GetDocumentMetadata(dsel, "Autor", "");
          var date = hydra.GetDocumentMetadata(dsel, "Datum", DateTime.MinValue);

          var doc = string.Join("\r\n", hydra.GetReadableDocument(dsel, "Wort").Select(x=> $"<s>{MakeSentence(x)}</s>"));
          
          writer.Write(Resources.Template_Ids_I5_Doc_Text
            .Replace("{cluster_id}", clusterId.ToString())
            .Replace("{text_id}", textId.ToString())
            .Replace("{title}", hydra.GetDocumentDisplayname(dsel))
            .Replace("{guid}", dsel.ToString("N"))
            .Replace("{guid_short}", dsel.ToString("N").Substring(0, 8))
            .Replace("{author}", author)
            .Replace("{doc_date}", date.ToString("yyyy-MM-dd"))
            .Replace("{doc_date_year}", date.ToString("yyyy"))
            .Replace("{doc_date_month}", date.ToString("MM"))
            .Replace("{doc_date_day}", date.ToString("dd"))
            .Replace("{text}", doc)
          );
        }

        writer.Write(Resources.Template_Ids_I5_Doc_Foot);
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
