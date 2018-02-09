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
  public class div
  {
    private string completeField;

    private string idField;

    private object[] itemsField;

    private string nField;

    private string typeField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string complete { get { return completeField; } set { completeField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    [XmlElement("bibl", typeof(bibl))]
    [XmlElement("byline", typeof(byline))]
    [XmlElement("caption", typeof(caption))]
    [XmlElement("closer", typeof(closer))]
    [XmlElement("div", typeof(div))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("head", typeof(head))]
    [XmlElement("list", typeof(list))]
    [XmlElement("note", typeof(note))]
    [XmlElement("opener", typeof(opener))]
    [XmlElement("p", typeof(p))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("poem", typeof(poem))]
    [XmlElement("ptr", typeof(ptr))]
    [XmlElement("quote", typeof(quote))]
    [XmlElement("sp", typeof(sp))]
    [XmlElement("table", typeof(table))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string n { get { return nField; } set { nField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string type { get { return typeField; } set { typeField = value; } }
  }
}