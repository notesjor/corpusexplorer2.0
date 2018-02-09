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
  public class docTitle
  {
    private fw fwField;

    private object[] itemsField;

    private string renditionField;

    /// <remarks />
    public fw fw { get { return fwField; } set { fwField = value; } }

    /// <remarks />
    [XmlElement("figure", typeof(figure))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("space", typeof(space))]
    [XmlElement("titlePart", typeof(titlePart))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string rendition { get { return renditionField; } set { renditionField = value; } }
  }
}