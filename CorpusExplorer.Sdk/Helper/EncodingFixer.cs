using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Helper
{
  public static class EncodingFixer
  {
    private static Dictionary<string, string> _fixes = new Dictionary<string, string>
    {
      {"Ã¤", "ä"},
      {"Ã¶", "ö"},
      {"Ã¼", "ü"},
      {"ÃŸ", "ß"},
      {"Ã„", "Ä"},
      {"Ã–", "Ö"},
      {"Ãœ", "Ü"},
    };
    public static string Fix(string input)
    {
      var stb = new StringBuilder(input);
      foreach (var fix in _fixes)
      {
        stb = stb.Replace(fix.Key, fix.Value);
      }
      return stb.ToString();
    }
  }
}
