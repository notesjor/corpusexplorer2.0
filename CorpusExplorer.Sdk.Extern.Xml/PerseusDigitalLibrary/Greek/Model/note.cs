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
  public class note
  {
    private string anchoredField;

    private object[] itemsField;

    private string nField;

    private string placeField;

    private string respField;

    private string tEIformField;

    private string[] textField;

    private string typeField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string anchored
    {
      get => anchoredField;
      set => anchoredField = value;
    }

    /// <remarks />
    [XmlElement("bibl", typeof(bibl))]
    [XmlElement("foreign", typeof(foreign))]
    [XmlElement("p", typeof(p))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
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
    public string place
    {
      get => placeField;
      set => placeField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string resp
    {
      get => respField;
      set => respField = value;
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

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string type
    {
      get => typeField;
      set => typeField = value;
    }
  }
}