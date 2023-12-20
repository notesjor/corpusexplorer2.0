using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.Xml.Helper
{
  public static class TextHelper
  {
    public static string SafeJoin(Func<IEnumerable<string>> call, string separator = " ")
    {
      try
      {
        return string.Join(separator, call());
      }
      catch
      {
        return "";
      }
    }

    public static string RemoveMultiSpacesAndLinebreaks(string text)
    {
      try
      {
        text = text.Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ");
        var length = text.Length;
        do
        {
          length = text.Length;
          text = text.Replace("  ", " ");
        } while (length != text.Length);
        return text;
      }
      catch
      {
        return text;
      }
    }
  }
}
