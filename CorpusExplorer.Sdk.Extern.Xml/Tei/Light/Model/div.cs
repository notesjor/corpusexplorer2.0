using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Light.Model
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
    private object itemField;

    private object[] itemsField;

    private lg lgField;

    private string nField;

    private string rendField;

    private string typeField;

    /// <remarks />
    [XmlElement("bibl", typeof(bibl))]
    [XmlElement("opener", typeof(opener))]
    public object Item
    {
      get => itemField;
      set => itemField = value;
    }

    /// <remarks />
    [XmlElement("closer", typeof(closer))]
    [XmlElement("dateline", typeof(dateline))]
    [XmlElement("div", typeof(div))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("gap", typeof(gap))]
    [XmlElement("head", typeof(head))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("p", typeof(p))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("q", typeof(q))]
    [XmlElement("signed", typeof(signed))]
    [XmlElement("sp", typeof(sp))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    public lg lg
    {
      get => lgField;
      set => lgField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string n
    {
      get => nField;
      set => nField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string rend
    {
      get => rendField;
      set => rendField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string type
    {
      get => typeField;
      set => typeField = value;
    }
  }
}