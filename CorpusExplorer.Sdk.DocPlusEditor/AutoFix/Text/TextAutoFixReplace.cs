#region

using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Text
{
  public class TextAutoFixReplace : AbstractTextAutoFix
  {
    public string Find { get; set; }
    public string Replace { get; set; }

    protected override string Apply(string text)
    {
      int len;
      do
      {
        len = text.Length;
        text = text.Replace(Find, Replace);
      } while (len > text.Length);

      return text;
    }
  }
}