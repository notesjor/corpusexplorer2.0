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
  public class sourceDesc
  {
    private biblStruct biblStructField;

    private string defaultField;

    private reference[] referenceField;

    /// <remarks />
    public biblStruct biblStruct { get { return biblStructField; } set { biblStructField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string Default { get { return defaultField; } set { defaultField = value; } }

    /// <remarks />
    [XmlElement("reference")]
    public reference[] reference { get { return referenceField; } set { referenceField = value; } }
  }
}