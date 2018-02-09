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
  public class stage
  {
    private string correspField;

    private object[] itemsField;

    private string renditionField;

    private string[] textField;

    /// <remarks />
    [XmlAttribute]
    public string corresp { get { return correspField; } set { correspField = value; } }

    /// <remarks />
    [XmlElement("castList", typeof(castList))]
    [XmlElement("choice", typeof(choice))]
    [XmlElement("fw", typeof(fw))]
    [XmlElement("gap", typeof(gap))]
    [XmlElement("hi", typeof(hi))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("list", typeof(list))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("note", typeof(note))]
    [XmlElement("p", typeof(p))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("sp", typeof(sp))]
    [XmlElement("supplied", typeof(supplied))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string rendition { get { return renditionField; } set { renditionField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }
  }
}