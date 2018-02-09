using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
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
  public class sp
  {
    private string correspField;

    private string idField;

    private object[] itemsField;

    private string nextField;

    private string prevField;

    private string renditionField;

    private string whoField;

    /// <remarks />
    [XmlAttribute]
    public string corresp { get { return correspField; } set { correspField = value; } }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified,
       Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    [XmlElement("cit", typeof(cit))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("floatingText", typeof(floatingText))]
    [XmlElement("fw", typeof(fw))]
    [XmlElement("l", typeof(l))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("lg", typeof(lg))]
    [XmlElement("list", typeof(list))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("note", typeof(note))]
    [XmlElement("p", typeof(p))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("quote", typeof(quote))]
    [XmlElement("space", typeof(space))]
    [XmlElement("speaker", typeof(speaker))]
    [XmlElement("stage", typeof(stage))]
    [XmlElement("table", typeof(table))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string next { get { return nextField; } set { nextField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string prev { get { return prevField; } set { prevField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string rendition { get { return renditionField; } set { renditionField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string who { get { return whoField; } set { whoField = value; } }
  }
}