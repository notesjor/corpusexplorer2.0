using System.Collections.Generic;
using System.IO;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.Helper;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Scraper.Abstract;

namespace CorpusExplorer.Sdk.Extern.Xml.DraCor
{
  public class DraCorTurnScraper : AbstractScraper
  {
    public override string DisplayName => "DraCorTurn";

    protected override IEnumerable<Dictionary<string, object>> Execute(string file)
    {
      try
      {
        var html = new HtmlAgilityPackHelper(file);
        html.RemoveNodes(new[] { "//speaker", "//stage" });
        var castList = GetCastList(html);

        var doc = new Dictionary<string, object>
        {
          {"Titel", GetTitle(html)?.Trim()},
          {"Autor", GetAuthor(html)?.Trim()},
          {"Datum (Druck)", GetDatePrint(html)?.Trim()},
          {"Datum (Premiere)", GetDatePremiere(html)?.Trim()},
          {"Datei", Path.GetFileName(file)}
        };

        return GetTurns(html, castList, doc);
      }
      catch
      {
        // ignore
      }

      return null;
    }

    private IEnumerable<Dictionary<string, object>> GetTurns(HtmlAgilityPackHelper html,
      Dictionary<string, KeyValuePair<string, string>> castList, Dictionary<string, object> doc)
    {
      var turns = html.GetNodes("//sp");
      var res = new List<Dictionary<string, object>>();

      if (turns == null) 
        return res;
        
      foreach (var turn in turns)
      {
        var speaker = turn.GetAttributeValue("who", "").Replace("#", "");
        var sex = "UNKNOWN";
        if (castList.ContainsKey(speaker))
        {
          sex = castList[speaker].Value;
          speaker = castList[speaker].Key;
        }

        var div = turn.ParentNode;
        var Szene = "";
        if (div != null && div.Name == "div" && div.GetAttributeValue("type", "") == "scene")
          Szene = div.GetAttributeValue("n", "?");

        var text = turn.InnerText;

        var temp = doc.ToDictionary(x => x.Key, x => x.Value);
        temp.Add("Sprecher", speaker?.Trim());
        temp.Add("Sprecher (Geschlecht)", sex?.Trim());
        temp.Add("Text", text?.Trim().Replace("\t", " ").Replace("  ", " ").Replace("  ", " "));
        temp.Add("Szene", Szene.Trim());
        res.Add(temp);
      }

      return res;
    }

    private Dictionary<string, KeyValuePair<string, string>> GetCastList(HtmlAgilityPackHelper html)
    {
      var roles = html.GetNodes("//person");
      var castList = new Dictionary<string, KeyValuePair<string, string>>();

      if (roles != null && roles.Count > 0)
        foreach (var role in roles)
        {
          var key = role.GetAttributeValue("xml:id", "").Replace("#", "");
          var value = role.InnerText;
          var sex = role.GetAttributeValue("sex", "UNKNOWN");

          try
          {
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
              castList.Add(key, new KeyValuePair<string, string>(value, sex));
          }
          catch
          {
            // ignore
          }
        }
      else // Fallback for some other xml structure
      {
        roles = html.GetNodes("//role");

        if(roles == null)
          return castList;

        foreach (var role in roles)
        {
          var key = role.GetAttributeValue("corresp", "");
          var value = role.InnerText;
          try
          {
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
              castList.Add(key, new KeyValuePair<string, string>(value, "UNKNOWN"));
          }
          catch
          {
            // ignore
          }
        }
      }
      return castList;
    }

    private string GetDatePremiere(HtmlAgilityPackHelper html)
    {
      var tmp = html.GetNodes("//event[@type=\"premiere\"]")?.FirstOrDefault();
      return tmp?.GetAttributeValue("when", "");
    }

    private string GetDatePrint(HtmlAgilityPackHelper html)
    {
      var tmp = html.GetNodes("//event[@type=\"print\"]")?.FirstOrDefault();
      return tmp?.GetAttributeValue("when", "");
    }

    private string GetAuthor(HtmlAgilityPackHelper html)
    {
      var tmp = html.GetNodes("//author/persname");
      return tmp == null ? "" : string.Join("; ", tmp.Select(x => string.Join(" ", x.InnerText)));
    }

    private string GetTitle(HtmlAgilityPackHelper html)
    {
      var tmp = html.GetNodes("//title");
      return tmp == null ? "" : string.Join(" - ", tmp.Select(x => string.Join(" ", x.InnerText)));
    }
  }
}