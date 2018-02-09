using System.Collections.Generic;
using System.IO;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Compatibility
{
  public class ImporterCorpusExplorerV1toV5 : AbstractImporter
  {
    protected override IEnumerable<AbstractCorpusAdapter> Execute(string inputPath)
    {
      return new[] {Ce1CompatibilityControler.Upgrade(Path.GetDirectoryName(inputPath))};
    }
  }
}