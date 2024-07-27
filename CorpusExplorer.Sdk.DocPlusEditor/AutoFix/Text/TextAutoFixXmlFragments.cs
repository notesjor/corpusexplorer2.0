#region

using System.Text.RegularExpressions;
using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Text
{
  public class TextAutoFixXmlFragments : AbstractTextAutoFix
  {
    private readonly Regex _r1 = new Regex(@"<[^>]*>", RegexOptions.Compiled);

    protected override string Apply(string text) => _r1.Replace(text, " ");
  }
}