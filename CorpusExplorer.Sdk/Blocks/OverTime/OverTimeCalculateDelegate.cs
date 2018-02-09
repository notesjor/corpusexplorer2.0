using CorpusExplorer.Sdk.Model;

namespace CorpusExplorer.Sdk.Blocks.OverTime
{
  public delegate T OverTimeCalculateDelegate<out T>(Selection selection);
}