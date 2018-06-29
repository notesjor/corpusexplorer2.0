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
  public class l
  {
    private object[] itemsField;

    private string metField;

    private string nField;

    private string partField;

    private string rendField;

    private string tEIformField;

    private string[] textField;

    /// <remarks />
    [XmlElement("add", typeof(add))]
    [XmlElement("gap", typeof(gap))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("pb", typeof(pb))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string met
    {
      get => metField;
      set => metField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string n
    {
      get => nField;
      set => nField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string part
    {
      get => partField;
      set => partField = value;
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