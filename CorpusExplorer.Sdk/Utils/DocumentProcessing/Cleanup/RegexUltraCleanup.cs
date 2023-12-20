using CorpusExplorer.Sdk.Properties;

#region

using System.Text.RegularExpressions;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup
{
  public class RegexUltraCleanup : AbstractCleanup
  {
    private readonly Regex _r1 = new Regex(@"[^a-zA-ZßäöüÄÖÜ\.\?\(\)\[\]\{\}0-9,;:\-'&\%`\s" + "\" ]", RegexOptions.Compiled);

    public override string DisplayName => Resources.CorpusCleanup;

    protected override string Execute(string key, string input)
    {
      return _r1.Replace(input, string.Empty);
    }
  }
}