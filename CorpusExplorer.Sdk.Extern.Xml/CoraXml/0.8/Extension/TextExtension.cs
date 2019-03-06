using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.Extern.Xml.CoraXml._0._8.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.CoraXml._0._8.Extension
{
  public static class TextExtension
  {
    public static IEnumerable<comment> GetComment(this text text)
      => text.Items.OfType<comment>();
    public static IEnumerable<token> GetToken(this text text)
      => text.Items.OfType<token>();
  }
}
