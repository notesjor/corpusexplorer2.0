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
  public class title
  {
    private string[] textField;

    private string typeField;

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string type { get { return typeField; } set { typeField = value; } }
  }
}