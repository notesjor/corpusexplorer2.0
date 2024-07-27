using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Diagnostic;
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
          var corpus = Execute(path);
          if (corpus != null)
            res.AddRange(corpus);
        }
        catch (Exception ex)
        {
          InMemoryErrorConsole.Log(ex);
        }

      return PostProcessing(res);
    }

    protected virtual IEnumerable<AbstractCorpusAdapter> PostProcessing(IEnumerable<AbstractCorpusAdapter> corpora)
    {
      return corpora;
    }

    protected abstract IEnumerable<AbstractCorpusAdapter> Execute(string importFilePath);

    public virtual bool HasStaticGuids => false;
  }
}