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
  public class hi
  {
    private object[] itemsField;

    private string rendField;

    private string[] textField;

    /// <remarks />
    [XmlElement("foreign", typeof(foreign))]
    [XmlElement("orig", typeof(orig))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("ptr", typeof(ptr))]
    [XmlElement("q", typeof(q))]
    [XmlElement("ref", typeof(@ref))]
    [XmlElement("title", typeof(title))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string rend
    {
      get => rendField;
      set => rendField = value;
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