#region

using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Meta
{
  public class StringCastMetaAutoFix : AbstractCastMetaAutoFix
  {
    protected override object Apply(object obj) => obj == null ? string.Empty : obj.ToString();
  }
}