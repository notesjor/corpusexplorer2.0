using System.Linq;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Universal.Delegate
{
  public static class PredefinedCorpusBuildDelegates
  {
    public static CorpusBuildDelegate BuildSingleFileCorpus = (n, l, m, c) => { return CorpusAdapterSingleFile.Create(n, l.Select(layer => layer.Value.ToSingleFileLayer()), m, c); };

    public static CorpusBuildDelegate BuildFileSystemCorpus = (n, l, m, c) => { return CorpusAdapterFileSystem.Create(n, l.Select(layer => layer.Value), m, c); };
  }
}