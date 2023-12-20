#region

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;
using CorpusExplorer.Sdk.Model.Adapter.Corpus.Abstract;
using CorpusExplorer.Sdk.Properties;
using CorpusExplorer.Sdk.Utils.Filter.Queries;

#endregion

namespace CorpusExplorer.Sdk.Utils.Filter.Abstract
{
  /// <summary>
  ///   The abstract meta filter query.
  /// </summary>
  [XmlRoot]
  [XmlInclude(typeof(FilterQueryCorpusComplete))]
  [XmlInclude(typeof(FilterQueryMetaContains))]
  [XmlInclude(typeof(FilterQueryMetaContainsCaseSensitive))]
  [XmlInclude(typeof(FilterQueryMetaEndsWith))]
  [XmlInclude(typeof(FilterQueryMetaExactMatch))]
  [XmlInclude(typeof(FilterQueryMetaExactMatchCaseSensitive))]
  [XmlInclude(typeof(FilterQueryMetaIsEmpty))]
  [XmlInclude(typeof(FilterQueryMetaRegex))]
  [XmlInclude(typeof(FilterQueryMetaStartsWith))]
  [XmlInclude(typeof(FilterQueryUnsupportedParserFeature))]
  [Serializable]
  public abstract class AbstractFilterQueryMeta : AbstractFilterQueryCompleteDocumentIndexing
  {
    [XmlArray("values")] private IEnumerable<object> _metaObjects;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AbstractFilterQueryMeta" /> class.
    /// </summary>
    [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    protected AbstractFilterQueryMeta()
    {
      MetaLabel = Resources.Title;
      MetaValues = new object[0];
    }

    /// <summary>
    ///   Gets or sets the meta label.
    /// </summary>
    [XmlAttribute("label")]
    public string MetaLabel { get; set; }

    /// <summary>
    ///   Gets or sets the meta value.
    /// </summary>
    [XmlIgnore]
    public IEnumerable<object> MetaValues
    {
      get => _metaObjects;
      set
      {
        _metaObjects = value;
        TransformMetaValues(_metaObjects);
      }
    }

    protected abstract void TransformMetaValues(IEnumerable<object> metaValues);

    protected override bool ValidateCall(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      return ValidateCallCall(ValidateGetValue(corpus, documentGuid) ?? "");
    }

    protected abstract bool ValidateCallCall(string value);

    private string ValidateGetValue(AbstractCorpusAdapter corpus, Guid documentGuid)
    {
      var metas = corpus.GetDocumentMetadata(documentGuid);
      return metas == null ||
             metas.Count == 0 ||
             !metas.ContainsKey(MetaLabel)
               ? null
               : ValueFix(metas[MetaLabel]);
    }

    private string ValueFix(object obj)
    {
      if(obj == null)
        return null;
      if (obj is DateTime dt)
        return dt.ToString("yyyy-MM-dd HH:mm:ss");
      return obj.ToString();
    }
  }
}