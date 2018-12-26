using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace CorpusExplorer.Sdk.Extern.SocialMedia.Helper
{
  public static class HtmlToPlaintext
  {
    public static string ConvertToPlaintext(this string html)
    {
      var pageDoc = new HtmlDocument();
      pageDoc.LoadHtml(html);
      return pageDoc.DocumentNode.InnerText;
    }
  }
}
