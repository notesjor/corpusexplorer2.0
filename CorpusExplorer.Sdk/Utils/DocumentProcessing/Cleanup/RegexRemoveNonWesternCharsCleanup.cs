using System.Linq;
using System.Text.RegularExpressions;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup
{
  public class RegexRemoveNonWesternCharsCleanup : AbstractCleanup
  {
    private static Regex[] _rulesRegex 
      = { new Regex("[\u0000-\u0009]"), new Regex("[\u000B-\u000C]"), new Regex("[\u000E-\u001F]"), new Regex("[\u00FF-\u20AB]"), new Regex("[\u20AD-\uFFFF]") };
   
    public override string DisplayName 
      => "Regex Non-Latin Symbol Cleaner";

    protected override string Execute(string input) 
      => _rulesRegex.Aggregate(input, (current, regex) => regex.Replace(current, string.Empty));
  }
}