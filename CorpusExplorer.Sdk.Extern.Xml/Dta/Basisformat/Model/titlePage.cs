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
  public class titlePage
  {
    private gap gapField;

    private object[] itemsField;

    private string nField;

    private string renditionField;

    private string typeField;

    /// <remarks />
    public gap gap { get { return gapField; } set { gapField = value; } }

    /// <remarks />
    [XmlElement("byline", typeof(byline))]
    [XmlElement("docAuthor", typeof(docAuthor))]
    [XmlElement("docDate", typeof(docDate))]
    [XmlElement("docEdition", typeof(docEdition))]
    [XmlElement("docImprint", typeof(docImprint))]
    [XmlElement("docTitle", typeof(docTitle))]
    [XmlElement("epigraph", typeof(epigraph))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("fw", typeof(fw))]
    [XmlElement("imprimatur", typeof(imprimatur))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("note", typeof(note))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("space", typeof(space))]
    [XmlElement("titlePart", typeof(titlePart))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string n { get { return nField; } set { nField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string rendition { get { return renditionField; } set { renditionField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string type { get { return typeField; } set { typeField = value; } }
  }
}