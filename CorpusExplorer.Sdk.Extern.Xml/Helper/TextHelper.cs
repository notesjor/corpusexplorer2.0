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

    private static readonly Regex _r1 = new Regex("[ ]{2,}", RegexOptions.None);

    public static string RemoveMultiSpacesAndLinebreaks(string text)
    {
      try
      {
        return _r1.Replace(text.Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " "), " ");
      }
      catch
      {
        return text;
      }
    }
  }
}
