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
  public class item
  {
    private string idField;

    private object[] itemsField;

    private string langField;

    private string nextField;

    private string prevField;

    private string rendField;

    private string renditionField;

    private string[] textField;

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified,
       Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    [XmlElement("add", typeof(add))]
    [XmlElement("bibl", typeof(bibl))]
    [XmlElement("cb", typeof(cb))]
    [XmlElement("choice", typeof(choice))]
    [XmlElement("cit", typeof(cit))]
    [XmlElement("corr", typeof(corr))]
    [XmlElement("date", typeof(date))]
    [XmlElement("del", typeof(del))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("floatingText", typeof(floatingText))]
    [XmlElement("foreign", typeof(foreign))]
    [XmlElement("formula", typeof(formula))]
    [XmlElement("fw", typeof(fw))]
    [XmlElement("g", typeof(g))]
    [XmlElement("gap", typeof(gap))]
    [XmlElement("hi", typeof(hi))]
    [XmlElement("l", typeof(l))]
    [XmlElement("label", typeof(label))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("lg", typeof(lg))]
    [XmlElement("list", typeof(list))]
    [XmlElement("metamark", typeof(metamark))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("name", typeof(name))]
    [XmlElement("note", typeof(note))]
    [XmlElement("p", typeof(p))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("persName", typeof(persName))]
    [XmlElement("placeName", typeof(placeName))]
    [XmlElement("quote", typeof(quote))]
    [XmlElement("ref", typeof(@ref))]
    [XmlElement("space", typeof(space))]
    [XmlElement("stage", typeof(stage))]
    [XmlElement("subst", typeof(subst))]
    [XmlElement("supplied", typeof(supplied))]
    [XmlElement("table", typeof(table))]
    [XmlElement("unclear", typeof(unclear))]
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
  }
}