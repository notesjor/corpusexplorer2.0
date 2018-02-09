using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Basisformat.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class reg
  {
    private object[] itemsField;

    private string respField;

    private string[] textField;

    /// <remarks />
    [XmlElement("add", typeof(add))]
    [XmlElement("choice", typeof(choice))]
    [XmlElement("del", typeof(del))]
    [XmlElement("hi", typeof(hi))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("note", typeof(note))]
    [XmlElement("persName", typeof(persName))]
    [XmlElement("placeName", typeof(placeName))]
    [XmlElement("space", typeof(space))]
    [XmlElement("subst", typeof(subst))]
    [XmlElement("supplied", typeof(supplied))]
    [XmlElement("unclear", typeof(unclear))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string resp { get { return respField; } set { respField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }
  }
}