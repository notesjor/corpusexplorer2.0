using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Kaf.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class opinion_expression
  {
    private string polarityField;

    private string sentiment_product_featureField;

    private string sentiment_semantic_typeField;

    private span[] spanField;

    private string strengthField;

    private string subjectivityField;

    /// <remarks />
    [XmlAttribute]
    public string polarity
    {
      get => polarityField;
      set => polarityField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string sentiment_product_feature
    {
      get => sentiment_product_featureField;
      set => sentiment_product_featureField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string sentiment_semantic_type
    {
      get => sentiment_semantic_typeField;
      set => sentiment_semantic_typeField = value;
    }

    /// <remarks />
    [XmlElement("span")]
    public span[] span
    {
      get => spanField;
      set => spanField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string strength
    {
      get => strengthField;
      set => strengthField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string subjectivity
    {
      get => subjectivityField;
      set => subjectivityField = value;
    }
  }
}