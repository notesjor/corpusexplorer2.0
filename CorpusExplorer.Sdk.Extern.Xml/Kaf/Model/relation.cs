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
  public class relation
  {
    private string confidenceField;

    private string fromField;

    private string ridField;

    private string toField;

    /// <remarks />
    [XmlAttribute]
    public string confidence { get { return confidenceField; } set { confidenceField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string from { get { return fromField; } set { fromField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string rid { get { return ridField; } set { ridField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string to { get { return toField; } set { toField = value; } }
  }
}