using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;

namespace CorpusExplorer.Sdk.Utils.Filter.Abstract
{
  [XmlRoot]
  [Serializable]
  public abstract class AbstractFilterQuerySingleLayerFulltext : AbstractFilterQuery
  {
    /// <summary>
    ///   Gets or sets the layer displayname.
    /// </summary>
    [XmlAttribute("layer")]
    public string LayerDisplayname { get; set; }


    protected override int GetSentenceFirstIndexCall(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      var layer = corpus.GetLayers(LayerDisplayname).FirstOrDefault();
      return layer == null ? -1 : GetSentenceFirstIndexCall(corpus, documentGuid, layer.GetReadableDocumentByGuid(documentGuid).ReduceToSentences().ToArray()[sentence]);
    }

    protected abstract int GetSentenceFirstIndexCall(AbstractCorpusAdapter corpus, Guid documentGuid, string sentence);

    protected override IEnumerable<int> GetSentencesCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      var layer = corpus.GetLayers(LayerDisplayname).FirstOrDefault();
      return layer == null ? null : GetSentencesCall(layer.GetReadableDocumentByGuid(documentGuid).ReduceToSentences());
    }

    protected abstract IEnumerable<int> GetSentencesCall(IEnumerable<string> sentences);

    public override IEnumerable<int> GetWordIndices(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      var layer = corpus.GetLayers(LayerDisplayname).FirstOrDefault();
      return layer == null ? null : GetWordIndices(corpus, documentGuid, layer.GetReadableDocumentByGuid(documentGuid).ReduceToSentences().ToArray()[sentence]);
    }

    protected abstract IEnumerable<int> GetWordIndices(AbstractCorpusAdapter corpus, Guid documentGuid, string sentence);

    protected override bool ValidateCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      var layer = corpus.GetLayers(LayerDisplayname).FirstOrDefault();
      return layer != null && ValidateCall(layer.GetReadableDocumentByGuid(documentGuid).ReduceDocumentToText());
    }

    protected abstract bool ValidateCall(string document);
  }
}