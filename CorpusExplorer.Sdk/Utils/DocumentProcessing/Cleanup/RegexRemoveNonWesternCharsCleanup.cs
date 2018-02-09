using System.Text.RegularExpressions;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup
{
  public class RegexRemoveNonWesternCharsCleanup : AbstractCleanup
  {
    private readonly Regex _r1 = new Regex("[\u0000-\u0009]");
    private readonly Regex _r2 = new Regex("[\u000B-\u000C]");
    private readonly Regex _r3 = new Regex("[\u000E-\u001F]");
    private readonly Regex _r4 = new Regex("[\u00FF-\uFFFF]");
    public override string DisplayName => "Regex Non-Latin Symbol Cleaner";

    protected override string Execute(string input)
    {
      input = _r1.Replace(input, string.Empty);
      input = _r2.Replace(input, string.Empty);
      input = _r3.Replace(input, string.Empty);
      return _r4.Replace(input, string.Empty);
    }
  }
}