using System.Collections.Generic;
using CorpusExplorer.Sdk.EchtzeitEngine.Model.LightweightFile.Corpus;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Importer
{
  public class ImporterEchtzeitEngine : AbstractImporter
  {
    protected override IEnumerable<AbstractCorpusAdapter> Execute(string importFilePath)
    {
      return new[] {CorpusAdapterEchtzeitEngine.Create(importFilePath)};
    }
  }
}