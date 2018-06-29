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
  public class front
  {
    private object[] itemsField;

    /// <remarks />
    [XmlElement("castList", typeof(castList))]
    [XmlElement("cb", typeof(cb))]
    [XmlElement("closer", typeof(closer))]
    [XmlElement("div", typeof(div))]
    [XmlElement("docAuthor", typeof(docAuthor))]
    [XmlElement("docDate", typeof(docDate))]
    [XmlElement("docImprint", typeof(docImprint))]
    [XmlElement("docTitle", typeof(docTitle))]
    [XmlElement("epigraph", typeof(epigraph))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("fw", typeof(fw))]
    [XmlElement("gap", typeof(gap))]
    [XmlElement("head", typeof(head))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("note", typeof(note))]
    [XmlElement("p", typeof(p))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("space", typeof(space))]
    [XmlElement("titlePage", typeof(titlePage))]
    [XmlElement("titlePart", typeof(titlePart))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }
  }
}