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
  public class reference
  {
    private string assemblageField;

    private string existenceField;

    private string originField;

    private string[] textField;

    private string typeField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string assemblage { get { return assemblageField; } set { assemblageField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string existence { get { return existenceField; } set { existenceField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string origin { get { return originField; } set { originField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string type { get { return typeField; } set { typeField = value; } }
  }
}