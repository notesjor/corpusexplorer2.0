using CorpusExplorer.Sdk.Blocks.Range.Abstract;

namespace CorpusExplorer.Sdk.Blocks.Range
{
  public class RangeSimple : AbstractRange
  {
    public RangeSimple(){}

    public RangeSimple(int from, int to)
    {
      From = from;
      To = to;
    }

    public int From { get; set; }
    public int To { get; set; }

    public override bool IsInRange(int indexMatch, int indexCurrent)
    {
      return indexCurrent >= (indexMatch + From) && indexCurrent <= (indexMatch + To);
    }
  }
}
