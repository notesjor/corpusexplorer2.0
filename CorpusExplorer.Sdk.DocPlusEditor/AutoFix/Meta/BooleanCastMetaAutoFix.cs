#region

using System;
using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Meta
{
  public class BooleanCastMetaAutoFix : AbstractCastMetaAutoFix
  {
    private static readonly BooleanCastMetaAutoFix _static = new BooleanCastMetaAutoFix { TrueExpression = "true" };

    public string TrueExpression { get; set; }

    protected override object Apply(object obj)
    {
      if (obj == null)
        return false;

      switch (obj)
      {
        case string s:
          return string.Equals(TrueExpression, s, StringComparison.InvariantCultureIgnoreCase);
        case int i:
          return i == 1;
        case long l:
          return l == 1;
        case float f:
          return Math.Abs(f - 1.0) < 0;
        case double d:
          return Math.Abs(d - 1.0) < 0;
        case uint ui:
          return ui == 1;
        case ulong ul:
          return ul == 1;
        case DateTime dt:
          return dt > DateTime.MinValue;
        case bool b:
          return b;
      }

      return false;
    }

    public static object Cast(object obj) => _static.Apply(obj);
  }
}