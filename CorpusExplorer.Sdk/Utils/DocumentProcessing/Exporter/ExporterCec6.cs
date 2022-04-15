using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Exporter
{
  public class ExporterCec6 : AbstractExporterSimpleGenericBase<CorpusBuilderWriteDirect, CorpusAdapterWriteDirect>
  {
    protected override void PreAction(string path)
    {
      if (path.EndsWith(".lz4"))
        UseCompression = true;
    }
  }
}