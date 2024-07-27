#region

using System.Text.RegularExpressions;
using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Text
{
  public class TextAutoFixReplaceRegex : AbstractTextAutoFix
  {
    public Regex Find { get; set; }
    public string Replace { get; set; }

    protected override string Apply(string text)
    {
      int len;
      do
      {
        len = text.Length;
        text = Find.Replace(text, Replace);
      } while (len > text.Length);

      return text;
    }
  }
}