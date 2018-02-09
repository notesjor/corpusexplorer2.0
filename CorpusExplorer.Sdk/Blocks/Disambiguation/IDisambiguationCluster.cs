using System.Collections.Generic;

namespace CorpusExplorer.Sdk.Blocks.Disambiguation
{
  public interface IDisambiguationCluster
  {
    string Label { get; }
    IEnumerable<string> LabelItems { get; }
    double Value { get; }
    IEnumerable<IDisambiguationCluster> GetClusters();
  }
}