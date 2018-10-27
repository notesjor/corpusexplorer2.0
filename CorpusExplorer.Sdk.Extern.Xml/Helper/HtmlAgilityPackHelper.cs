using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Ecosystem.Model;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.Xml.Helper
{
  public class HtmlAgilityPackHelper
  {
    private HtmlDocument _doc;

    public HtmlAgilityPackHelper(string file)
    {
      _doc = new HtmlDocument();
      _doc.Load(file, Configuration.Encoding);
    }

    public void RemoveNodes(IEnumerable<string> nodeXpaths)
    {
      foreach (var nodeXpath in nodeXpaths)
      {
        try
        {
          var ns = _doc.DocumentNode.SelectNodes(nodeXpath);
          if (ns == null) return;
          foreach (var n in ns)
            n.Remove();
        }
        catch
        {
          // ignore
        }
      }
    }

    public string GetBodyText(string bodyXpath)
    {
      var text = _doc.DocumentNode.SelectNodes("//text").FirstOrDefault();
      return text == null ? string.Empty : text.InnerText;
    }
  }
}
