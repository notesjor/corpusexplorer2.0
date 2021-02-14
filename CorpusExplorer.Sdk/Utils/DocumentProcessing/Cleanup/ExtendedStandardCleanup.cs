using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Properties;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup
{
  public class ExtendedStandardCleanup : StandardCleanup
  {
    private Regex[] _regex = new []
    {
      new Regex(@"\&[a-zA-Z]*\;*"),
      new Regex(@"\<\s*\>"),
    };

    public override string DisplayName => Resources.StandardCleanup + "++";

    protected override string Execute(string key, string input)
    {
      return _regex.Aggregate(_dictionary.Aggregate(input, (current, entry) => current.Replace(entry.Key, entry.Value)), (current, x) => x.Replace(current, ""));
    }

    public override string Bypass(string text)
    {
      return _regex.Aggregate(_dictionary.Aggregate(text, (current, entry) => current.Replace(entry.Key, entry.Value)), (current, x) => x.Replace(current, ""));
    }
  }
}
