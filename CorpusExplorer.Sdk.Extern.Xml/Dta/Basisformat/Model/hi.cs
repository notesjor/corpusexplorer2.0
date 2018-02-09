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
  public class hi
  {
    private string handField;

    private object[] itemsField;

    private string rendField;

    private string renditionField;

    private string[] textField;

    /// <remarks />
    [XmlAttribute]
    public string hand { get { return handField; } set { handField = value; } }

    /// <remarks />
    [XmlElement("abbr", typeof(abbr))]
    [XmlElement("add", typeof(add))]
    [XmlElement("bibl", typeof(bibl))]
    [XmlElement("cb", typeof(cb))]
    [XmlElement("choice", typeof(choice))]
    [XmlElement("cit", typeof(cit))]
    [XmlElement("corr", typeof(corr))]
    [XmlElement("date", typeof(date))]
    [XmlElement("del", typeof(del))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("foreign", typeof(foreign))]
    [XmlElement("formula", typeof(formula))]
    [XmlElement("fw", typeof(fw))]
    [XmlElement("g", typeof(g))]
    [XmlElement("gap", typeof(gap))]
    [XmlElement("hi", typeof(hi))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("lg", typeof(lg))]
    [XmlElement("list", typeof(list))]
    [XmlElement("metamark", typeof(metamark))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("name", typeof(name))]
    [XmlElement("note", typeof(note))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("persName", typeof(persName))]
    [XmlElement("placeName", typeof(placeName))]
    [XmlElement("q", typeof(q))]
    [XmlElement("quote", typeof(quote))]
    [XmlElement("ref", typeof(@ref))]
    [XmlElement("reg", typeof(reg))]
    [XmlElement("space", typeof(space))]
    [XmlElement("stage", typeof(stage))]
    [XmlElement("subst", typeof(subst))]
    [XmlElement("supplied", typeof(supplied))]
    [XmlElement("table", typeof(table))]
    [XmlElement("unclear", typeof(unclear))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

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