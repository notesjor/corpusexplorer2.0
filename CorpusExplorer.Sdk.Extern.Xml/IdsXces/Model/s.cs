using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.IdsXces.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.81.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class s
  {
    private string brokenField;

    private object[] itemsField;

    private string[] textField;

    private string typeField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string broken { get { return brokenField; } set { brokenField = value; } }

    /// <remarks />
    [XmlElement("distinct", typeof(distinct))]
    [XmlElement("foreign", typeof(foreign))]
    [XmlElement("gap", typeof(gap))]
    [XmlElement("hi", typeof(hi))]
    [XmlElement("list", typeof(list))]
    [XmlElement("name", typeof(name))]
    [XmlElement("orig", typeof(orig))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("ptr", typeof(ptr))]
    [XmlElement("q", typeof(q))]
    [XmlElement("ref", typeof(@ref))]
    [XmlElement("stage", typeof(stage))]
    [XmlElement("title", typeof(title))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string type { get { return typeField; } set { typeField = value; } }
  }
}