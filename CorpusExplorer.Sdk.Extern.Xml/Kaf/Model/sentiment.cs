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
  public class sentiment
  {
    private string polarityField;

    private string resourceField;

    private string sentiment_markerField;

    private string sentiment_modifierField;

    private string sentiment_product_featureField;

    private string sentiment_semantic_typeField;

    private string strengthField;

    private string subjectivityField;

    /// <remarks />
    [XmlAttribute]
    public string polarity { get { return polarityField; } set { polarityField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string resource { get { return resourceField; } set { resourceField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string sentiment_marker { get { return sentiment_markerField; } set { sentiment_markerField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string sentiment_modifier
    {
      get { return sentiment_modifierField; }
      set { sentiment_modifierField = value; }
    }

    /// <remarks />
    [XmlAttribute]
    public string sentiment_product_feature
    {
      get { return sentiment_product_featureField; }
      set { sentiment_product_featureField = value; }
    }

    /// <remarks />
    [XmlAttribute]
    public string sentiment_semantic_type
    {
      get { return sentiment_semantic_typeField; }
      set { sentiment_semantic_typeField = value; }
    }

    /// <remarks />
    [XmlAttribute]
    public string strength { get { return strengthField; } set { strengthField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string subjectivity { get { return subjectivityField; } set { subjectivityField = value; } }
  }
}