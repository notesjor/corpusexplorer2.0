using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Light.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class note
  {
    private object[] itemsField;

    private string nField;

    private string placeField;

    private string[] textField;

    /// <remarks />
    [XmlElement("abbr", typeof(abbr))]
    [XmlElement("bibl", typeof(bibl))]
    [XmlElement("choice", typeof(choice))]
    [XmlElement("foreign", typeof(foreign))]
    [XmlElement("label", typeof(label))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("num", typeof(num))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string n
    {
      get => nField;
      set => nField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string place
    {
      get => placeField;
      set => placeField = value;
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