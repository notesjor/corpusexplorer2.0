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
  public class orgName
  {
    private string idField;

    private string langField;

    private lb[] lbField;

    private string refField;

    private string roleField;

    private string[] textField;

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified,
       Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified,
       Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string lang { get { return langField; } set { langField = value; } }

    /// <remarks />
    [XmlElement("lb")]
    public lb[] lb { get { return lbField; } set { lbField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "anyURI")]
    public string @ref { get { return refField; } set { refField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string role { get { return roleField; } set { roleField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }
  }
}