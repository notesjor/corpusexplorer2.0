using System.Text.RegularExpressions;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup
{
  public class RegexHyphenationCleanup : AbstractCleanup
  {
    private readonly Regex _r1 = new Regex(@"(\w)(-[\r\n\s\t]+)", RegexOptions.Compiled);

    public override string DisplayName => Resources.CorpusCleanup;

    protected override string Execute(string key, string input)
    {
      return _r1.Replace(input, "$1");
    }
  }
}