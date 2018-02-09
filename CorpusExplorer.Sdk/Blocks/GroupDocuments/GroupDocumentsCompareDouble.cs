using System;
using CorpusExplorer.Sdk.Blocks.GroupDocuments.Abstract;

namespace CorpusExplorer.Sdk.Blocks.GroupDocuments
{
  [Serializable]
  public class GroupDocumentsCompareDouble : AbstractGroupDocumentsComparer
  {
    public override object Maximum => double.MaxValue;
    public override object Minimum => double.MinValue;

    protected override Type Type => typeof(double);

    public override object Add(object obj, ulong span) { return (double) obj + span; }

    public override double Difference(object objA, object objB) { return (double) objA - (double) objB; }

    public override bool IsBiggerOrEqual(object obj, object refernce) { return (double) obj >= (double) refernce; }

    public override bool IsSmallerOrEqual(object obj, object refernce) { return (double) obj <= (double) refernce; }

    public override object Substract(object obj, ulong span) { return (double) obj - span; }
  }
}