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
  public class quote
  {
    private string brokenField;

    private object[] itemsField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string broken { get { return brokenField; } set { brokenField = value; } }

    /// <remarks />
    [XmlElement("pb", typeof(pb))]
    [XmlElement("ptr", typeof(ptr))]
    [XmlElement("s", typeof(s))]
    [XmlElement("title", typeof(title))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }
  }
}