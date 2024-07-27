#region

using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Text
{
  public class TextAutoFixLineBreaks : AbstractTextAutoFix
  {
    protected override string Apply(string text)
    {
      int len;
      do
      {
        len = text.Length;
        text = text.Replace("\r", " ").Replace("\n", " ");
      } while (len > text.Length);

      return text;
    }
  }
}