#region

using System;
using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Meta
{
  public class IntCastMetaAutoFix : AbstractCastMetaAutoFix
  {
    private static readonly IntCastMetaAutoFix _static = new IntCastMetaAutoFix();

    protected override object Apply(object obj)
    {
      if (obj == null)
        return 0;

      switch (obj)
      {
        case string s:
          return int.Parse(s);
        case int i:
          return i;
        case long l:
          return (int)l;
        case float f:
          return (int)f;
        case double d:
          return (int)d;
        case uint ui:
          return (int)ui;
        case ulong ul:
          return (int)ul;
        case DateTime dt:
          return dt.Ticks;
        case bool b:
          return b ? 1 : 0;
      }

      return 0;
    }

    public static object Cast(object obj) => _static.Apply(obj);
  }
}