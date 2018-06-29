using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
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
  public class text
  {
    private cb cbField;

    private text[] groupField;

    private string idField;

    private object[] itemsField;

    private string nField;

    /// <remarks />
    public cb cb
    {
      get => cbField;
      set => cbField = value;
    }

    /// <remarks />
    [XmlArrayItem("text", IsNullable = false)]
    public text[] group
    {
      get => groupField;
      set => groupField = value;
    }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified,
      Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlElement("back", typeof(back))]
    [XmlElement("body", typeof(body))]
    [XmlElement("figure", typeof(figure))]
    [XmlElement("front", typeof(front))]
    [XmlElement("fw", typeof(fw))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("milestone", typeof(milestone))]
    [XmlElement("pb", typeof(pb))]
    [XmlElement("space", typeof(space))]
    [XmlElement("text", typeof(text))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string n
    {
      get => nField;
      set => nField = value;
    }
  }
}