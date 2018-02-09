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
  public class opener
  {
    private object[] itemsField;

    private string renditionField;

    private string[] textField;

    /// <remarks />
    [XmlElement("date", typeof(date))]
    [XmlElement("dateline", typeof(dateline))]
    [XmlElement("epigraph", typeof(epigraph))]
    [XmlElement("hi", typeof(hi))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("persName", typeof(persName))]
    [XmlElement("placeName", typeof(placeName))]
    [XmlElement("salute", typeof(salute))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string rendition { get { return renditionField; } set { renditionField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }
  }
}