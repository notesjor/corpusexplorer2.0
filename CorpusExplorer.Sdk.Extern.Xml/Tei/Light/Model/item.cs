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
  public class item
  {
    private object[] itemsField;

    private string nField;

    private string[] textField;

    /// <remarks />
    [XmlElement("choice", typeof(choice))]
    [XmlElement("foreign", typeof(foreign))]
    [XmlElement("hi", typeof(hi))]
    [XmlElement("label", typeof(label))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("unclear", typeof(string))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string n
    {
      get => nField;
      set => nField = value;
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