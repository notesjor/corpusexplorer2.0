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
  public class row
  {
    private cell[] cellField;

    private string roleField;

    /// <remarks />
    [XmlElement("cell")]
    public cell[] cell { get { return cellField; } set { cellField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string role { get { return roleField; } set { roleField = value; } }
  }
}