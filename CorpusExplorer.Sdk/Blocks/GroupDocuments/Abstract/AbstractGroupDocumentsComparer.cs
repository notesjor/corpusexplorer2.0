using System;

namespace CorpusExplorer.Sdk.Blocks.GroupDocuments.Abstract
{
  [Serializable]
  public abstract class AbstractGroupDocumentsComparer
  {
    public abstract object Maximum { get; }
    public abstract object Minimum { get; }

    protected abstract Type Type { get; }

    public abstract object Add(object obj, ulong span);

    public abstract double Difference(object objA, object objB);

    public abstract bool IsBiggerOrEqual(object obj, object refernce);

    public bool IsInRange(object rangeLow, object obj, object rangeHigh)
    {
      return IsBiggerOrEqual(obj, rangeLow) && IsSmallerOrEqual(obj, rangeHigh);
    }

    public abstract bool IsSmallerOrEqual(object obj, object refernce);

    public bool IsTypeValid(object obj) { return obj.GetType() == Type; }

    public abstract object Substract(object obj, ulong span);
  }
}