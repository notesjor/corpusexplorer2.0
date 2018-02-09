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
  public class div
  {
    private string correspField;

    private string idField;

    private object[] itemsField;

    private string langField;

    private string nextField;

    private string nField;

    private string prevField;

    private string renditionField;

    private string typeField;

    /// <remarks />
    [XmlAttribute]
    public string corresp { get { return correspField; } set { correspField = value; } }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified,
       Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    [XmlElement("ab", typeof(ab))]
    [XmlElement("argument", typeof(argument))]
    [XmlElement("bibl", typeof(bibl))]
    [XmlElement("byline", typeof(byline))]
    [XmlElement("castList", typeof(castList))]
    [XmlElement("cb", typeof(cb))]
    [XmlElement("cit", typeof(cit))]
    [XmlElement("closer", typeof(closer))]
    [XmlElement("dateline", typeof(dateline))]
    [XmlElement("div", typeof(div))]
    [XmlElement("docAuthor", typeof(docAuthor))]
    [XmlElement("docDate", typeof(docDate))]
    [XmlElement("epigraph", typeof(epigraph))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("floatingText", typeof(floatingText))]
    [XmlElement("fw", typeof(fw))]
    [XmlElement("gap", typeof(gap))]
    [XmlElement("head", typeof(head))]
    [XmlElement("l", typeof(l))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("lg", typeof(lg))]
    [XmlElement("list", typeof(list))]
    [XmlElement("listBibl", typeof(listBibl))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("note", typeof(note))]
    [XmlElement("opener", typeof(opener))]
    [XmlElement("p", typeof(p))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("postscript", typeof(postscript))]
    [XmlElement("quote", typeof(quote))]
    [XmlElement("salute", typeof(salute))]
    [XmlElement("signed", typeof(signed))]
    [XmlElement("sp", typeof(sp))]
    [XmlElement("spGrp", typeof(spGrp))]
    [XmlElement("space", typeof(space))]
    [XmlElement("stage", typeof(stage))]
    [XmlElement("table", typeof(table))]
    [XmlElement("trailer", typeof(trailer))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified,
       Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string lang { get { return langField; } set { langField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string n { get { return nField; } set { nField = value; } }

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
    [XmlAttribute(DataType = "NCName")]
    public string type { get { return typeField; } set { typeField = value; } }
  }
}