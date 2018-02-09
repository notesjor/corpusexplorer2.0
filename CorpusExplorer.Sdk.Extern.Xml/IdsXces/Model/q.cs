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
  public class q
  {
    private string brokenField;

    private string directField;

    private string idField;

    private object[] itemsField;

    private string nextField;

    private string prevField;

    private string[] textField;

    private string typeField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string broken { get { return brokenField; } set { brokenField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string direct { get { return directField; } set { directField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    [XmlElement("distinct", typeof(distinct))]
    [XmlElement("foreign", typeof(foreign))]
    [XmlElement("gap", typeof(gap))]
    [XmlElement("hi", typeof(hi))]
    [XmlElement("list", typeof(list))]
    [XmlElement("orig", typeof(orig))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("ptr", typeof(ptr))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string next { get { return nextField; } set { nextField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string prev { get { return prevField; } set { prevField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string type { get { return typeField; } set { typeField = value; } }
  }
}