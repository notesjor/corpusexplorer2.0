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
  public class w
  {
    private string functionField;

    private string idField;

    private string lemmaField;

    private string partField;

    private string subtypeField;

    private string typeField;

    private string valueField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string function { get { return functionField; } set { functionField = value; } }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string lemma { get { return lemmaField; } set { lemmaField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string part { get { return partField; } set { partField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string subtype { get { return subtypeField; } set { subtypeField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string type { get { return typeField; } set { typeField = value; } }

    /// <remarks />
    [XmlText(DataType = "NMTOKEN")]
    public string Value { get { return valueField; } set { valueField = value; } }
  }
}