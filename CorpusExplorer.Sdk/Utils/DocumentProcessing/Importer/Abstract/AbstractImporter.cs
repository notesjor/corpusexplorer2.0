using System.Collections.Generic;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.CorpusManipulation;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Builder;

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
          var corpus = Execute(path);
          if (corpus != null)
            res.AddRange(corpus);
        }
        catch
        {
          // ignore
        }

      return PostProcessing(res);
    }

    protected virtual IEnumerable<AbstractCorpusAdapter> PostProcessing(IEnumerable<AbstractCorpusAdapter> corpora)
      => corpora;

    protected abstract IEnumerable<AbstractCorpusAdapter> Execute(string importFilePath);
  }
}