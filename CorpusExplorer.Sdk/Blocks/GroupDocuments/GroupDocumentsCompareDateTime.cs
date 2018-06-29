using System;
using CorpusExplorer.Sdk.Blocks.GroupDocuments.Abstract;

namespace CorpusExplorer.Sdk.Blocks.GroupDocuments
{
  [Serializable]
  public class GroupDocumentsCompareDateTime : AbstractGroupDocumentsComparer
  {
    public override object Maximum => DateTime.MaxValue;
    public override object Minimum => DateTime.MinValue;

    protected override Type Type => typeof(DateTime);

    public override object Add(object obj, ulong span)
    {
      return ((DateTime) obj).Add(new TimeSpan((int) span));
    }

    public override double Difference(object objA, object objB)
    {
      return ((DateTime) objA).Ticks - ((DateTime) objB).Ticks;
    }

    public override bool IsBiggerOrEqual(object obj, object refernce)
    {
      return (DateTime) obj >= (DateTime) refernce;
    }

    public override bool IsSmallerOrEqual(object obj, object refernce)
    {
      return (DateTime) obj <= (DateTime) refernce;
    }

    public override object Substract(object obj, ulong span)
    {
      return ((DateTime) obj).Add(new TimeSpan(-1 * (int) span));
    }
  }
}