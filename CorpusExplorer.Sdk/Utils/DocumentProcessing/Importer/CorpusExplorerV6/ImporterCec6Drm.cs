using System.Collections.Generic;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.CorpusExplorerV6
{
  public class ImporterCec6Drm : AbstractImporter
  {
    protected override IEnumerable<AbstractCorpusAdapter> Execute(string importFilePath)
    {
      var user = "";
      var password = "";
      if (importFilePath.StartsWith("%"))
      {
        var split = importFilePath.Split(new[] { "%" }, System.StringSplitOptions.RemoveEmptyEntries);
        user = split[0];
        password = split[1];
        importFilePath = split[2];
      }
      return new[] { CorpusAdapterWriteDirect.Create(importFilePath, user, password) };
    }

    public override bool HasStaticGuids => true;
  }
}