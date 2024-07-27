#region

using CorpusExplorer.Sdk.Utils.DocumentProcessing.Cleanup;
using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Text
{
  public class TextAutoFixHtmlEncodingFragments : AbstractTextAutoFix
  {
    private readonly StandardCleanup _cleanup = new StandardCleanup();

    protected override string Apply(string text) => _cleanup.Bypass(text);
  }
}