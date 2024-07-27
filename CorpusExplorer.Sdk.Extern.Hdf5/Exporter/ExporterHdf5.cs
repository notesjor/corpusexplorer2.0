using CorpusExplorer.Sdk.Extern.Hdf5.Builder;
using CorpusExplorer.Sdk.Model.Extension;
using CorpusExplorer.Sdk.Model.Interface;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

namespace CorpusExplorer.Sdk.Extern.Hdf5.Exporter
{
  public class ExporterHdf5: AbstractExporter
  {
    public override void Export(IHydra hydra, string path)
    {
      hydra.ToCorpus(new CorpusBuilderHdf5()).Save(path);
    }
  }
}
