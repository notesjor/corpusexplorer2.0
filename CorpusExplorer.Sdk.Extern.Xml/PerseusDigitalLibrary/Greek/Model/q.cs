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
  public class q
  {
    private string directField;

    private object[] itemsField;

    private string rendField;

    private string tEIformField;

    private string[] textField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string direct
    {
      get => directField;
      set => directField = value;
    }

    /// <remarks />
    [XmlElement("del", typeof(del))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("q", typeof(q))]
    [XmlElement("quote", typeof(quote))]
    [XmlElement("term", typeof(term))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string rend
    {
      get => rendField;
      set => rendField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string TEIform
    {
      get => tEIformField;
      set => tEIformField = value;
    }

    /// <remarks />
    [XmlText]
    public string[] Text
    {
      get => textField;
      set => textField = value;
    }
  }
}