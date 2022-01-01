#region

using CorpusExplorer.Sdk.Model;

#endregion

namespace CorpusExplorer.Sdk.Blocks.OverTime
{
  public delegate T OverTimeCalculateDelegate<out T>(Selection selection);
}