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
  public class supplied
  {
    private string certField;

    private object[] itemsField;

    private string reasonField;

    private string respField;

    private string[] textField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string cert { get { return certField; } set { certField = value; } }

    /// <remarks />
    [XmlElement("choice", typeof(choice))]
    [XmlElement("corr", typeof(corr))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("foreign", typeof(foreign))]
    [XmlElement("formula", typeof(formula))]
    [XmlElement("gap", typeof(gap))]
    [XmlElement("hi", typeof(hi))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("note", typeof(note))]
    [XmlElement("persName", typeof(persName))]
    [XmlElement("placeName", typeof(placeName))]
    [XmlElement("sic", typeof(sic))]
    [XmlElement("supplied", typeof(supplied))]
    [XmlElement("unclear", typeof(unclear))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string reason { get { return reasonField; } set { reasonField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string resp { get { return respField; } set { respField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }
  }
}