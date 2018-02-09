#region

using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Interface;

#endregion

namespace CorpusExplorer.Sdk.Model.Export.Abstract
{
  public abstract class AbstractExporter
  {
    public void Export(AbstractCorpusAdapter corpus, string path) { Export((IHydra) corpus, path); }

    public void Export(Selection selection, string path) { Export((IHydra) selection, path); }

    public void Export(Project project, string path) { Export((IHydra) project, path); }

    public abstract void Export(IHydra hydra, string path);
  }
}