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
  public class sic
  {
    private object[] itemsField;

    private string[] textField;

    /// <remarks />
    [XmlElement("add", typeof(add))]
    [XmlElement("choice", typeof(choice))]
    [XmlElement("corr", typeof(corr))]
    [XmlElement("del", typeof(del))]
    [XmlElement("foreign", typeof(foreign))]
    [XmlElement("gap", typeof(gap))]
    [XmlElement("hi", typeof(hi))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("metamark", typeof(metamark))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("note", typeof(note))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("persName", typeof(persName))]
    [XmlElement("placeName", typeof(placeName))]
    [XmlElement("ref", typeof(@ref))]
    [XmlElement("space", typeof(space))]
    [XmlElement("subst", typeof(subst))]
    [XmlElement("supplied", typeof(supplied))]
    [XmlElement("table", typeof(table))]
    [XmlElement("unclear", typeof(unclear))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }
  }
}