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
  public class l
  {
    private string idField;

    private object[] itemsField;

    private string nextField;

    private decimal nField;

    private bool nFieldSpecified;

    private string prevField;

    private string renditionField;

    private string[] textField;

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified,
       Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    [XmlElement("bibl", typeof(bibl))]
    [XmlElement("cb", typeof(cb))]
    [XmlElement("choice", typeof(choice))]
    [XmlElement("cit", typeof(cit))]
    [XmlElement("corr", typeof(corr))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("foreign", typeof(foreign))]
    [XmlElement("fw", typeof(fw))]
    [XmlElement("gap", typeof(gap))]
    [XmlElement("hi", typeof(hi))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("list", typeof(list))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("name", typeof(name))]
    [XmlElement("note", typeof(note))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("persName", typeof(persName))]
    [XmlElement("placeName", typeof(placeName))]
    [XmlElement("q", typeof(q))]
    [XmlElement("ref", typeof(@ref))]
    [XmlElement("reg", typeof(reg))]
    [XmlElement("space", typeof(space))]
    [XmlElement("stage", typeof(stage))]
    [XmlElement("supplied", typeof(supplied))]
    [XmlElement("table", typeof(table))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlAttribute]
    public decimal n { get { return nField; } set { nField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string next { get { return nextField; } set { nextField = value; } }

    /// <remarks />
    [XmlIgnore]
    public bool nSpecified { get { return nFieldSpecified; } set { nFieldSpecified = value; } }

    /// <remarks />
    [XmlAttribute]
    public string prev { get { return prevField; } set { prevField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string rendition { get { return renditionField; } set { renditionField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }
  }
}