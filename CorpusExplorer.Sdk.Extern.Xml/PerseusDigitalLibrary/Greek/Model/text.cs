using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class text
  {
    private body bodyField;

    private object itemField;

    private string langField;

    private string nField;

    private string tEIformField;

    /// <remarks />
    public body body
    {
      get => bodyField;
      set => bodyField = value;
    }

    /// <remarks />
    [XmlElement("front", typeof(front))]
    [XmlElement("group", typeof(group))]
    public object Item
    {
      get => itemField;
      set => itemField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string lang
    {
      get => langField;
      set => langField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string n
    {
      get => nField;
      set => nField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string TEIform
    {
      get => tEIformField;
      set => tEIformField = value;
    }
  }
}