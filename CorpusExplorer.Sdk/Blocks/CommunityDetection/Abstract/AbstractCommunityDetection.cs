using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Blocks.CommunityDetection.Abstract
{
  public abstract class AbstractCommunityDetection
  {
    protected AbstractCommunityDetection(){ }

    public abstract Community[] Calculate(Dictionary<string, Dictionary<string, double>> edges);
  }
}
