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
  public class availability
  {
    private string regionField;

    private string statusField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string region { get { return regionField; } set { regionField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string status { get { return statusField; } set { statusField = value; } }
  }
}