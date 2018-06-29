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
  public class item
  {
    private object[] itemsField;

    private string[] textField;

    /// <remarks />
    [XmlElement("hi", typeof(hi))]
    [XmlElement("list", typeof(list))]
    [XmlElement("orig", typeof(orig))]
    [XmlElement("p", typeof(p))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("ptr", typeof(ptr))]
    [XmlElement("q", typeof(q))]
    [XmlElement("s", typeof(s))]
    [XmlElement("title", typeof(title))]
    [XmlElement("xptr", typeof(xptr))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
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