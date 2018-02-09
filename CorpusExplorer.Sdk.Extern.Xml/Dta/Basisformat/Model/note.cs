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
  public class note
  {
    private bool anchoredField;

    private bool anchoredFieldSpecified;

    private string correspField;

    private string handField;

    private string idField;

    private object[] itemsField;

    private string langField;

    private string nextField;

    private string nField;

    private string placeField;

    private string prevField;

    private string renditionField;

    private string respField;

    private string sameAsField;

    private string[] textField;

    private string typeField;

    /// <remarks />
    [XmlAttribute]
    public bool anchored { get { return anchoredField; } set { anchoredField = value; } }

    /// <remarks />
    [XmlIgnore]
    public bool anchoredSpecified { get { return anchoredFieldSpecified; } set { anchoredFieldSpecified = value; } }

    /// <remarks />
    [XmlAttribute]
    public string corresp { get { return correspField; } set { correspField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string hand { get { return handField; } set { handField = value; } }

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
    [XmlElement("date", typeof(date))]
    [XmlElement("del", typeof(del))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("floatingText", typeof(floatingText))]
    [XmlElement("foreign", typeof(foreign))]
    [XmlElement("formula", typeof(formula))]
    [XmlElement("fw", typeof(fw))]
    [XmlElement("gap", typeof(gap))]
    [XmlElement("hi", typeof(hi))]
    [XmlElement("l", typeof(l))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("lg", typeof(lg))]
    [XmlElement("list", typeof(list))]
    [XmlElement("metamark", typeof(metamark))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("name", typeof(name))]
    [XmlElement("note", typeof(note))]
    [XmlElement("orgName", typeof(orgName))]
    [XmlElement("p", typeof(p))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("persName", typeof(persName))]
    [XmlElement("placeName", typeof(placeName))]
    [XmlElement("quote", typeof(quote))]
    [XmlElement("ref", typeof(@ref))]
    [XmlElement("sic", typeof(sic))]
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
    public string n { get { return nField; } set { nField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string next { get { return nextField; } set { nextField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string place { get { return placeField; } set { placeField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string prev { get { return prevField; } set { prevField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string rendition { get { return renditionField; } set { renditionField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string resp { get { return respField; } set { respField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string sameAs { get { return sameAsField; } set { sameAsField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string type { get { return typeField; } set { typeField = value; } }
  }
}