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
  public class del
  {
    private string handField;

    private object[] itemsField;

    private string renditionField;

    private string[] textField;

    /// <remarks />
    [XmlAttribute]
    public string hand
    {
      get => handField;
      set => handField = value;
    }

    /// <remarks />
    [XmlElement("add", typeof(add))]
    [XmlElement("choice", typeof(choice))]
    [XmlElement("del", typeof(del))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("gap", typeof(gap))]
    [XmlElement("hi", typeof(hi))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("metamark", typeof(metamark))]
    [XmlElement("note", typeof(note))]
    [XmlElement("orig", typeof(orig))]
    [XmlElement("persName", typeof(persName))]
    [XmlElement("subst", typeof(subst))]
    [XmlElement("supplied", typeof(supplied))]
    [XmlElement("unclear", typeof(unclear))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string rendition
    {
      get => renditionField;
      set => renditionField = value;
    }

    /// <remarks />
    [XmlText]
    public string[] Text
    {
      get => textField;
      set => textField = value;
    }
  }
}