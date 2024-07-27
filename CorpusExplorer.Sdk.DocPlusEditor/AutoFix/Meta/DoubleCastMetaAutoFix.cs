#region

using System;
using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Meta
{
  public class DoubleCastMetaAutoFix : AbstractCastMetaAutoFix
  {
    private static readonly DoubleCastMetaAutoFix _static = new DoubleCastMetaAutoFix();

    protected override object Apply(object obj)
    {
      if (obj == null)
        return 0d;

      switch (obj)
      {
        case string s:
          return double.Parse(s);
        case int i:
          return (double)i;
        case long l:
          return (double)l;
        case float f:
          return (double)f;
        case double d:
          return d;
        case uint ui:
          return (double)ui;
        case ulong ul:
          return (double)ul;
        case DateTime dt:
          return (double)dt.Ticks;
        case bool b:
          return b ? 1d : 0d;
      }

      return 0d;
    }

    public static object Cast(object obj) => _static.Apply(obj);
  }
}