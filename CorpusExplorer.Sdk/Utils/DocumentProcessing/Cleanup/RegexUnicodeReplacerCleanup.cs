using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup
{
  public class RegexUnicodeReplacerCleanup : AbstractCleanup
  {
    private Regex _regex = new Regex("[\u20AD-\uFFFF]");

    public override string DisplayName
      => "Regex Replace Unicode";

    protected override string Execute(string key, string input)
      => Bypass(input);

    public string Bypass(string token)
    {
      var matches = _regex.Matches(token);
      if (matches.Count == 0)
        return token;

      var stb = new StringBuilder(token);
      foreach (Match match in matches)
        stb.Replace(match.Value, $"\\u{string.Concat(Array.ConvertAll(Encoding.UTF8.GetBytes(match.Value), b => b.ToString("X2")))}");

      return stb.ToString();
    }
  }
}
