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
  public class floatingText
  {
    private object[] frontField;

    private string idField;

    private object itemField;

    private object[] itemsField;

    private string nextField;

    private string prevField;

    private string renditionField;

    /// <remarks />
    [XmlElement("front", typeof(front))]
    public object[] front { get { return frontField; } set { frontField = value; } }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified,
       Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    [XmlElement("body", typeof(body))]
    [XmlElement("lb", typeof(lb))]
    [XmlElement("pb", typeof(pb))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlElement("back", typeof(back))]
    [XmlElement("cb", typeof(cb))]
    public object Item { get { return itemField; } set { itemField = value; } }


    /// <remarks />
    [XmlAttribute]
    public string next { get { return nextField; } set { nextField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string prev { get { return prevField; } set { prevField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string rendition { get { return renditionField; } set { renditionField = value; } }
  }
}