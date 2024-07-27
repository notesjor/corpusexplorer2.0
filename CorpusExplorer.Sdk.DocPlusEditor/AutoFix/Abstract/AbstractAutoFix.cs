#region

using System.Collections.Generic;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract
{
  public abstract class AbstractAutoFix
  {
    public abstract void Apply(ref List<Dictionary<string, object>> docs);
  }
}