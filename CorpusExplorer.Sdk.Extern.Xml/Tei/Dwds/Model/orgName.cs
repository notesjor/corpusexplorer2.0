using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Dwds.Model
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
    private string refField;

    private string roleField;

    private string[] textField;

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