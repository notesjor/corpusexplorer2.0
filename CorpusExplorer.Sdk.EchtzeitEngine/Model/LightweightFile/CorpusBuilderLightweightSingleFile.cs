using System;
using System.Collections.Generic;
using System.Linq;
using CorpusExplorer.Sdk.EchtzeitEngine.Model.LightweightFile.Corpus;
using CorpusExplorer.Sdk.EchtzeitEngine.Model.LightweightFile.Layer;
using CorpusExplorer.Sdk.EchtzeitEngine.Model.LightweightFile.Layer.Model;
using CorpusExplorer.Sdk.Model;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.Adapter.Layer.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract;
using CorpusExplorer.Sdk.Utils.DocumentProcessing.Abstract.Model.Abstract;

namespace CorpusExplorer.Sdk.EchtzeitEngine.Model.LightweightFile
{
  public class CorpusBuilderLightweightSingleFile : AbstractLightweightCorpusBuilder
  {
    public string CorpusDisplayname { get; set; } = "EchtzeitEngine";

    protected override AbstractCorpusAdapter CreateCorpus(
      Dictionary<Guid, Dictionary<string, object>> documentMetadata,
      Dictionary<string, object> corpusMetadata,
      List<Concept> concepts)
    {
      var doc = documentMetadata.FirstOrDefault();
      return CorpusAdapterEchtzeitEngine.Create(CorpusDisplayname, doc.Value, doc.Key);
    }

    protected override AbstractLayerAdapter CreateLayer(AbstractCorpusAdapter corpus, AbstractLayerState layer)
    {
      return LayerAdapterEchtzeitEngine.Create(EchtzeitLayer.Create(layer));
    }
  }
}