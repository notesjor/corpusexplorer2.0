using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.AltoXml._1._2.Model;
using CorpusExplorer.Sdk.Extern.Xml.AltoXml._1._2.Serializer;
using CorpusExplorer.Sdk.Helper;
using HtmlAgilityPack;
using String = CorpusExplorer.Sdk.Extern.Xml.AltoXml._1._2.Model.String;

namespace CorpusExplorer.Sdk.Extern.Xml.AltoXml._1._2
{
  public class Alto12Scraper : AbstractGenericXmlSerializerFormatScraper<alto>
  {
    public override string DisplayName => "ALTO-XML (v 1.2)";
    protected override AbstractGenericSerializer<alto> Serializer => new Alto12Serializer();

    protected override IEnumerable<Dictionary<string, object>> ScrapDocuments(string file, alto model)
    {
      var dic = new Dictionary<string, object> { { "ID", Path.GetFileNameWithoutExtension(file).Replace("-ALTO", "") } };
      if (file.EndsWith("-ALTO.xml") && File.Exists(file.Replace("-ALTO.xml", "-METS.xml")))
        GetMetsMetadata(file, ref dic);

      ExtractText(model, ref dic);

      return new[] { dic };
    }

    private void ExtractText(alto model, ref Dictionary<string, object> dic)
    {
      var tokens = new List<string>();

      try
      {
        foreach (var tb in model.Layout.Page.PrintSpace.TextBlock)
          try
          {
            foreach (var tl in tb.TextLine)
              try
              {
                foreach (var item in tl.Items)
                  try
                  {
                    if (item is String s)
                      tokens.Add(s.CONTENT.Replace("■", ""));
                  }
                  catch
                  {
                    //ignore
                  }
              }
              catch
              {
                //ignore
              }
          }
          catch
          {
            //ignore
          }
      }
      catch
      {
        //ignore
      }

      dic.Add("Text", string.Join(" ", tokens));
    }

    private void GetMetsMetadata(string path, ref Dictionary<string, object> dic)
    {
      var xml = new HtmlDocument();
      xml.Load(path.Replace("-ALTO.xml", "-METS.xml"), Encoding.UTF8);

      var dfs = xml.DocumentNode.SelectNodes("//datafield");
      if (dfs == null || dfs.Count == 0)
        return;

      var dfT = ClearMetsMetadata((from x in dfs where x.GetAttributeValue("tag", "") == "245" select x).FirstOrDefault());
      var dfA = ClearMetsMetadata((from x in dfs where x.GetAttributeValue("tag", "") == "600" select x).FirstOrDefault());
      dic.Add("Titel", dfT);
      dic.Add("Autor", dfA);

      var d260 = (from x in dfs where x.GetAttributeValue("tag", "") == "260" select x).FirstOrDefault();
      if (d260 != null)
      {
        var l260 = (from x in d260.ChildNodes
                    where x.Name == "subfield" && x.GetAttributeValue("code", "") == "a"
                    select x).FirstOrDefault();
        dic.Add("Sprache", l260 == null ? "" : ClearMetsMetadata(l260));

        var z260 = (from x in d260.ChildNodes
                    where x.Name == "subfield" && x.GetAttributeValue("code", "") == "b"
                    select x).FirstOrDefault();
        dic.Add("Zeitung", z260 == null ? "" : ClearMetsMetadata(z260));

        var t260 = (from x in d260.ChildNodes
                    where x.Name == "subfield" && x.GetAttributeValue("code", "") == "c"
                    select x).FirstOrDefault();
        var dat = t260 == null ? "" : ClearMetsMetadata(t260);
        dic.Add("Datum", dat.Length > 4 ? DateTimeHelper.Parse(dat, "dd.MM.yyyy") : DateTime.MinValue);
      }
    }

    private string ClearMetsMetadata(HtmlNode node)
    {
      return node?.InnerText?.Replace("Unknown", "").Replace("\t", " ").Replace("\n", "").Replace("\r", "").Replace("  ", " ").Replace("  ", " ");
    }
  }
}
