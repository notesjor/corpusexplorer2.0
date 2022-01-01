#region

using System.Collections.Generic;

#endregion

namespace CorpusExplorer.Sdk.Blocks.OverTime
{
  public delegate T OverTimeAggregationDelegate<T>(IEnumerable<T> data);
}