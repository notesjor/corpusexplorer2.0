using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.CoraXml._1._0.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.CoraXml._1._0.Extension
{
  public static class TextExtension
  {
    public static IEnumerable<header> GetHeader(this text text)
      => text.Items.OfType<header>();
    public static IEnumerable<layoutinfo> GetLayoutInfo(this text text)
      => text.Items.OfType<layoutinfo>();
    public static IEnumerable<shifttags> GetShiftTags(this text text)
      => text.Items.OfType<shifttags>();
    public static IEnumerable<token> GetToken(this text text)
      => text.Items.OfType<token>();
  }
}
