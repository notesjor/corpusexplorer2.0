using System.Collections.Generic;
using CorpusExplorer.Sdk.Extern.HdfFive.Adapter;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Extern.HdfFive.Importer
{
  public class ImporterHdf5: AbstractImporter
  {
    protected override IEnumerable<AbstractCorpusAdapter> Execute(string importFilePath)
    {
      return CorpusAdapterHdf5.Create(importFilePath);
    }
  }
}
