#region

using System.Text.RegularExpressions;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup
{
  public class RegexXmlMarkupCleanup : AbstractCleanup
  {
    private readonly Regex _r1 = new Regex(@"<[^>]*>");

    public override string DisplayName => "HTML Standardbereinigung mittels REGEX";

    public string ReplaceWith { get; set; } = string.Empty;

    protected override string Execute(string input)
    {
      return _r1.Replace(input, ReplaceWith);
    }
  }
}