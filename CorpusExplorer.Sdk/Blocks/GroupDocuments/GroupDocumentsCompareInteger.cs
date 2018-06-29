using System;
using CorpusExplorer.Sdk.Blocks.GroupDocuments.Abstract;

namespace CorpusExplorer.Sdk.Blocks.GroupDocuments
{
  [Serializable]
  public class GroupDocumentsCompareInteger : AbstractGroupDocumentsComparer
  {
    public override object Maximum => int.MaxValue;
    public override object Minimum => int.MinValue;

    protected override Type Type => typeof(int);

    public override object Add(object obj, ulong span)
    {
      return (int) obj + (int) span;
    }

    public override double Difference(object objA, object objB)
    {
      return (int) objA - (int) objB;
    }

    public override bool IsBiggerOrEqual(object obj, object refernce)
    {
      return (int) obj >= (int) refernce;
    }

    public override bool IsSmallerOrEqual(object obj, object refernce)
    {
      return (int) obj <= (int) refernce;
    }

    public override object Substract(object obj, ulong span)
    {
      return (int) obj - (int) span;
    }
  }
}