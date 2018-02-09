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
  public class quote
  {
    private string correspField;

    private string idField;

    private object[] itemsField;

    private string langField;

    private string nextField;

    private string prevField;

    private string rendField;

    private string renditionField;

    private string[] textField;

    private string typeField;

    /// <remarks />
    [XmlAttribute]
    public string corresp { get { return correspField; } set { correspField = value; } }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified,
       Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    [XmlElement("bibl", typeof(bibl))]
    [XmlElement("cb", typeof(cb))]
    [XmlElement("choice", typeof(choice))]
    [XmlElement("cit", typeof(cit))]
    [XmlElement("date", typeof(date))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("foreign", typeof(foreign))]
    [XmlElement("formula", typeof(formula))]
    [XmlElement("fw", typeof(fw))]
    [XmlElement("gap", typeof(gap))]
    [XmlElement("hi", typeof(hi))]
    [XmlElement("l", typeof(l))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("lg", typeof(lg))]
    [XmlElement("list", typeof(list))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("note", typeof(note))]
    [XmlElement("orig", typeof(orig))]
    [XmlElement("p", typeof(p))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("persName", typeof(persName))]
    [XmlElement("placeName", typeof(placeName))]
    [XmlElement("q", typeof(q))]
    [XmlElement("quote", typeof(quote))]
    [XmlElement("sp", typeof(sp))]
    [XmlElement("space", typeof(space))]
    [XmlElement("stage", typeof(stage))]
    [XmlElement("supplied", typeof(supplied))]
    [XmlElement("table", typeof(table))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified,
       Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string lang { get { return langField; } set { langField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string next { get { return nextField; } set { nextField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string prev { get { return prevField; } set { prevField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string rend { get { return rendField; } set { rendField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string rendition { get { return renditionField; } set { renditionField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string type { get { return typeField; } set { typeField = value; } }
  }
}