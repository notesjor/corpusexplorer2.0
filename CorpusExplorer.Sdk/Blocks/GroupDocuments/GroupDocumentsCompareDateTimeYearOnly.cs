#region

using System;
using CorpusExplorer.Sdk.Blocks.GroupDocuments.Abstract;

#endregion

namespace CorpusExplorer.Sdk.Blocks.GroupDocuments
{
  [Serializable]
  public class GroupDocumentsCompareDateTimeYearOnly : AbstractGroupDocumentsComparer
  {
    public override object Maximum => DateTime.MaxValue;
    public override object Minimum => DateTime.MinValue;

    protected override Type Type => typeof(DateTime);

    public override object Add(object obj, ulong span) => ((DateTime)obj).Add(new TimeSpan((int)span));

    public override double Difference(object objA, object objB) => ((DateTime)objA).Year - ((DateTime)objB).Year;

    public override bool IsBiggerOrEqual(object obj, object refernce) =>
      ((DateTime)obj).Year >= ((DateTime)refernce).Year;

    public override bool IsSmallerOrEqual(object obj, object refernce) =>
      ((DateTime)obj).Year <= ((DateTime)refernce).Year;

    public override object Substract(object obj, ulong span) => ((DateTime)obj).Add(new TimeSpan(-1 * (int)span));
  }
}