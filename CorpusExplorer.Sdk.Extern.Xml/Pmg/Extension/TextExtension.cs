using System.Text;
using CorpusExplorer.Sdk.Extern.Xml.Pmg.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Pmg.Extension
{
  public static class TextExtension
  {
    public static string Plaintext(this text text)
    {
      var stb = new StringBuilder();
      foreach (var item in text.Items)
      {
        if (!(item is Inline))
          continue;

        var inline = (Inline) item;
        foreach (var t in inline.Text)
          stb.AppendLine(t);
      }

      return stb.ToString();
    }
  }
}