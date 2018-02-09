using System;
using System.Collections.Generic;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Universal.LayerState.Abstract;

namespace CorpusExplorer.Sdk.Utils.DocumentProcessing.Universal.Delegate
{
  public delegate AbstractCorpusAdapter CorpusBuildDelegate(string corpusDisplayname, Dictionary<string, AbstractLayerState> layers, Dictionary<Guid, Dictionary<string, object>> meta, IEnumerable<Concept> concepts = null);
}