#region

using System;
using System.Globalization;
using CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Abstract;

#endregion

namespace CorpusExplorer.Tool4.DocPlusEditor.AutoFix.Meta
{
  public class DateTimeCastMetaAutoFix : AbstractCastMetaAutoFix
  {
    private static readonly DateTimeCastMetaAutoFix _static = new DateTimeCastMetaAutoFix
      { DateTimeFormat = "yyyy-MM-dd" };

    public string DateTimeFormat { get; set; }

    protected override object Apply(object obj)
    {
      if (obj == null)
        return DateTime.MinValue;

      switch (obj)
      {
        case string s:
          return DateTime.ParseExact(s, DateTimeFormat, CultureInfo.CurrentCulture);
        case int i:
          return new DateTime(i);
        case long l:
          return new DateTime(l);
        case float f:
          return new DateTime((long)f);
        case double d:
          return new DateTime((long)d);
        case uint ui:
          return new DateTime(ui);
        case ulong ul:
          return new DateTime((long)ul);
        case DateTime dt:
          return dt;
        case bool b:
          return b ? DateTime.MinValue : DateTime.MaxValue;
      }

      return DateTime.MinValue;
    }

    public static object Cast(object obj) => _static.Apply(obj);
  }
}