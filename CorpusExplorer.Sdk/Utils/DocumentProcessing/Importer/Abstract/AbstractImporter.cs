using System.Collections.Generic;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract
{
  public abstract class AbstractImporter
  {
    protected abstract IEnumerable<AbstractCorpusAdapter> Execute(string importFilePath);

    public IEnumerable<AbstractCorpusAdapter> Execute(IEnumerable<string> importFilePaths)
    {
      var res = new List<AbstractCorpusAdapter>();

      foreach (var path in importFilePaths)
        res.AddRange(Execute(path));
      return res;
    }
  }
}