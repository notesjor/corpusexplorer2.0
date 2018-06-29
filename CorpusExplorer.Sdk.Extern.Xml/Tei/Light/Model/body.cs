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
  public class body
  {
    private closer closerField;

    private object[] items1Field;

    private object[] itemsField;

    /// <remarks />
    public closer closer
    {
      get => closerField;
      set => closerField = value;
    }

    /// <remarks />
    [XmlElement("div", typeof(div))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("gap", typeof(gap))]
    [XmlElement("head", typeof(head))]
    [XmlElement("p", typeof(p))]
    [XmlElement("pb", typeof(pb))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlElement("dateline", typeof(dateline))]
    [XmlElement("lb", typeof(lb))]
    public object[] Items1
    {
      get => items1Field;
      set => items1Field = value;
    }
  }
}