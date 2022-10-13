﻿using System.Collections.Generic;
using CorpusExplorer.Sdk.Model.Adapter.Corpus;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Importer.CorpusExplorerV6
{
  public class ImporterCec6 : AbstractImporter
  {
    protected override IEnumerable<AbstractCorpusAdapter> Execute(string importFilePath)
    {
      return new[] {CorpusAdapterWriteDirect.Create(importFilePath)};
    }

    public override bool HasStaticGuids => true;
  }
}