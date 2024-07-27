#region

using System;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract
{
  public abstract class AbstractCastMetaAutoFix : AbstractMetaAutoFix
  {
    protected override bool IsApplicable(object obj)
    {
      if (obj == null)
        return true;

      return obj is string
          || obj is int
          || obj is long
          || obj is float
          || obj is double
          || obj is uint
          || obj is ulong
          || obj is DateTime
          || obj is bool;
    }
  }
}