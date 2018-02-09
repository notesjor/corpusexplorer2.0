using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Kaf.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class dep
  {
    private string caseField;

    private string fromField;

    private string rfuncField;

    private string toField;

    /// <remarks />
    [XmlAttribute]
    public string @case { get { return caseField; } set { caseField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string from { get { return fromField; } set { fromField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string rfunc { get { return rfuncField; } set { rfuncField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string to { get { return toField; } set { toField = value; } }
  }
}