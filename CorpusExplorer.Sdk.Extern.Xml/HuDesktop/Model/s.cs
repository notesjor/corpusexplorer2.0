using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.HuDesktop.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class s
  {
    private div divField;

    private string idField;

    private object[] itemsField;

    private string partField;

    /// <remarks />
    public div div { get { return divField; } set { divField = value; } }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    [XmlElement("c", typeof(c))]
    [XmlElement("seg", typeof(seg))]
    [XmlElement("w", typeof(w))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string part { get { return partField; } set { partField = value; } }
  }
}