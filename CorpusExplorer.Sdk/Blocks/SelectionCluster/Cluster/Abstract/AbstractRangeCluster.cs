namespace CorpusExplorer.Sdk.Blocks.SelectionCluster.Cluster.Abstract
{
  public abstract class AbstractRangeCluster<T> : AbstractCluster
  {
    protected T _valueEnd;
    protected T _valueStart;

    public AbstractRangeCluster(T valueStart, T valueEnd)
    {
      _valueStart = valueStart;
      _valueEnd = valueEnd;
    }
  }
}