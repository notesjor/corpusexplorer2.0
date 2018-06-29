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
  public class body
  {
    private object[] itemsField;

    private postscript postscriptField;

    /// <remarks />
    [XmlElement("bibl", typeof(bibl))]
    [XmlElement("castList", typeof(castList))]
    [XmlElement("cb", typeof(cb))]
    [XmlElement("cit", typeof(cit))]
    [XmlElement("closer", typeof(closer))]
    [XmlElement("dateline", typeof(dateline))]
    [XmlElement("div", typeof(div))]
    [XmlElement("epigraph", typeof(epigraph))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("floatingText", typeof(floatingText))]
    [XmlElement("fw", typeof(fw))]
    [XmlElement("gap", typeof(gap))]
    [XmlElement("head", typeof(head))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("lg", typeof(lg))]
    [XmlElement("list", typeof(list))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("note", typeof(note))]
    [XmlElement("opener", typeof(opener))]
    [XmlElement("p", typeof(p))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("salute", typeof(salute))]
    [XmlElement("sp", typeof(sp))]
    [XmlElement("space", typeof(space))]
    [XmlElement("stage", typeof(stage))]
    [XmlElement("table", typeof(table))]
    [XmlElement("trailer", typeof(trailer))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    public postscript postscript
    {
      get => postscriptField;
      set => postscriptField = value;
    }
  }
}