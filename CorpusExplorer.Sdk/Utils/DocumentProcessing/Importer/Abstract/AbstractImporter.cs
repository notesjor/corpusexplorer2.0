using System.Collections.Generic;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract
{
  public abstract class AbstractImporter
  {
    public IEnumerable<AbstractCorpusAdapter> Execute(IEnumerable<string> importFilePaths)
    {
      var res = new List<AbstractCorpusAdapter>();

      foreach (var path in importFilePaths)
        try
        {
          res.AddRange(Execute(path));
        }
        catch
        {
          // ignore
        }
      return res;
    }

    protected abstract IEnumerable<AbstractCorpusAdapter> Execute(string importFilePath);
  }
}