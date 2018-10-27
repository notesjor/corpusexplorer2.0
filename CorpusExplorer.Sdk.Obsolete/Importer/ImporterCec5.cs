using System.Collections.Generic;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Importer
{
  internal sealed class ImporterCec5 : AbstractImporter
  {
    protected override IEnumerable<AbstractCorpusAdapter> Execute(string inputPath)
    {
      return new[] {CorpusAdapterSingleFile.Create(inputPath)};
    }
  }
}