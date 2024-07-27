using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Helper;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Model.CorpusExplorer;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

namespace CorpusExplorer.Sdk.Utils.Filter.Abstract
{
  [XmlRoot]
  [XmlInclude(typeof(FilterQuerySingleLayerRegexFulltext))]
  [Serializable] 
  public abstract class AbstractFilterQuerySingleLayerFulltext : AbstractFilterQuery
  {
    /// <summary>
    ///   Gets or sets the layer displayname.
    /// </summary>
    [XmlAttribute("layer")]
    public string LayerDisplayname { get; set; }


    protected override CeRange? GetSentenceFirstIndexCall(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      return new CeRange(0, corpus.GetDocumentSentencesLength(documentGuid, sentence));
    }

    protected override IEnumerable<int> GetSentencesCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      var layer = corpus.GetLayers(LayerDisplayname).FirstOrDefault();
      return layer == null ? null : GetSentencesCall(layer.GetReadableDocumentByGuid(documentGuid).ReduceToSentences());
    }

    protected abstract IEnumerable<int> GetSentencesCall(IEnumerable<string> sentences);

    public override IEnumerable<CeRange> GetWordIndices(AbstractCorpusAdapter corpus, Guid documentGuid, int sentence)
    {
      var layer = corpus.GetLayers(LayerDisplayname).FirstOrDefault();
      if(layer == null)
        return null;
      return new[] { new CeRange(0, layer[documentGuid][sentence].Length) };
    }

    protected override bool ValidateCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      var layer = corpus.GetLayers(LayerDisplayname).FirstOrDefault();
      return layer != null && ValidateCall(layer.GetReadableDocumentByGuid(documentGuid).ReduceDocumentToText());
    }

    protected abstract bool ValidateCall(string document);
  }
}