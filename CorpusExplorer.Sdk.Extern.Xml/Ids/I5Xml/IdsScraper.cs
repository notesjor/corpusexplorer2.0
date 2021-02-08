using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml.Model;
using CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml.Serializer;
using CorpusExplorer.Sdk.Extern.Xml.Ids.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml
{
  public class IdsScraper : AbstractGenericXmlSerializerFormatScraper<idsCorpus>
  {
    public override string DisplayName => "IDS-Korpus";

    protected override AbstractGenericSerializer<idsCorpus> Serializer
    {
      get
      {
        var res = new IdsSerializer();
        res.OnException += ResOnOnException;
        return res;
      }
    }

    private bool ResOnOnException(string path, Exception ex)
    {
      if (!(ex is InvalidOperationException) || !(ex.InnerException is XmlException iex))
        return false;

      if (!File.Exists(path + ".bak"))
        File.Copy(path, path + ".bak");

      using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
      using (var reader = new StreamReader(fs, Encoding.UTF8))
      using (var tmp = new FileStream(path + ".fix", FileMode.Create, FileAccess.Write))
      using (var writer = new StreamWriter(tmp, Encoding.UTF8))
      {
        for (int i = 0; i < iex.LineNumber - 1; i++)
          writer.WriteLine(reader.ReadLine());

        var line = reader.ReadLine();
        var nline = line.Substring(0, iex.LinePosition - 2) + line.Substring(line.IndexOf(';', iex.LinePosition) + 1);
        writer.WriteLine(nline);

        while (!reader.EndOfStream)
          writer.WriteLine(reader.ReadLine());
      }

      File.Delete(path);
      File.Move(path + ".fix", path);

      return true;
    }

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(string file, idsCorpus model)
    {
      var list = new List<Dictionary<string, object>>();

      var pK = new Dictionary<string, object>();
      if (model.idsHeader != null)
      {
        // pK.Add("Sigle (K)", model.idsHeader.fileDesc?.titleStmt?.KorpusSigle);
        pK.Add("Sprache", model.idsHeader.profileDesc?.LangUsage?.language?.id);
        pK.Add("Name (K)", model.idsHeader.fileDesc?.titleStmt?.TitleC);
      }

      foreach (var doc in model.idsDoc)
      {
        var pD = pK.ToDictionary(x => x.Key, x => x.Value);
        if (doc.idsHeader != null)
        {
          // pD.Add("Sigle (D)", doc.idsHeader.fileDesc?.titleStmt?.DokumentSigle);
          pD.Add("Name (D)", doc.idsHeader.fileDesc?.titleStmt?.TitleD);
          pD.Add("Textsorte", doc.idsHeader.profileDesc?.textDesc?.textType);
        }

        foreach (var text in doc.idsText)
        {
          var d = pD.ToDictionary(x => x.Key, x => x.Value);
          if (text.idsHeader != null)
          {
            d.Add("Sigle", text.idsHeader.fileDesc?.titleStmt?.TextSigle);
            d.Add("Veröffentlichung (Ort)", text.idsHeader.fileDesc?.sourceDesc?.biblStruct?.monogr?.imprint?.pubPlace?.Value);
            d.Add("Datum", GetDate(text.idsHeader.fileDesc?.sourceDesc?.biblStruct?.monogr?.imprint?.pubDate));
            d.Add("Herausgeber", text.idsHeader.fileDesc?.sourceDesc?.biblStruct?.monogr?.imprint?.publisher);
            d.Add("Titel", Reduce(text.idsHeader.fileDesc?.sourceDesc?.biblStruct?.monogr?.htitle?.FirstOrDefault(x => x.type == "main")?.Text));
            d.Add("Untertitel", Reduce(text.idsHeader.fileDesc?.sourceDesc?.biblStruct?.monogr?.htitle?.FirstOrDefault(x => x.type == "sub")?.Text));
            d.Add("Abbr", Reduce(text.idsHeader.fileDesc?.sourceDesc?.biblStruct?.monogr?.htitle?.FirstOrDefault(x => x.type == "abbr")?.Text));
            d.Add("Referenz", Reduce(text.idsHeader.fileDesc?.sourceDesc?.reference?.FirstOrDefault(x => x.type == "complete")?.Text));
          }
          d.Add("Text", GetText(text.text?.body));
          list.Add(d);
        }
      }

      return list;
    }

    private string GetText(body body)
    {
      var html = SubNodeToHtml(body);

      // clean
      var clean = new[] { "byline", "ptr", "pb", "bibl", "closer", "caption", "figure", "list", "note", "table" };
      foreach (var c in clean)
      {
        var nodes = html.DocumentNode.SelectNodes($"//{c}");
        if (nodes == null)
          continue;

        foreach (var n in nodes)
          n.ParentNode?.RemoveChild(n);
      }

      return html.DocumentNode.InnerText;
    }

    private DateTime GetDate(IEnumerable<pubDate> pubDates)
    {
      try
      {
        var y = int.Parse(Reduce(pubDates.FirstOrDefault(x => x.type == "year").Text));
        var m = int.Parse(Reduce(pubDates.FirstOrDefault(x => x.type == "month").Text));
        var d = int.Parse(Reduce(pubDates.FirstOrDefault(x => x.type == "day").Text));

        return new DateTime(y, m, d);
      }
      catch
      {
        return DateTime.MinValue;
      }
    }

    private string Reduce(string[] text)
      => text == null ? "" : string.Join(" ", text);
  }
}
