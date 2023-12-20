using System.Linq;
using System.Text.RegularExpressions;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup
{
  public class RegexRemoveNonWesternCharsCleanup : AbstractCleanup
  {
    private static Regex[] _rulesRegex 
      = { new Regex("[\u0000-\u0009]", RegexOptions.Compiled), 
      new Regex("[\u000B-\u000C]", RegexOptions.Compiled), 
      new Regex("[\u000E-\u001F]", RegexOptions.Compiled), 
      new Regex("[\u00FF-\u20AB]", RegexOptions.Compiled), 
      new Regex("[\u20AD-\uFFFF]", RegexOptions.Compiled) };
   
    public override string DisplayName 
      => "Regex Non-Latin Symbol Cleaner";

    protected override string Execute(string key, string input) 
      => _rulesRegex.Aggregate(input, (current, regex) => regex.Replace(current, string.Empty));
  }
}