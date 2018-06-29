using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Gate.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class Annotation
  {
    private string endNodeField;

    private Feature[] featureField;

    private string idField;

    private string startNodeField;

    private string typeField;

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string EndNode
    {
      get => endNodeField;
      set => endNodeField = value;
    }

    /// <remarks />
    [XmlElement("Feature")]
    public Feature[] Feature
    {
      get => featureField;
      set => featureField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string Id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string StartNode
    {
      get => startNodeField;
      set => startNodeField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string Type
    {
      get => typeField;
      set => typeField = value;
    }
  }
}