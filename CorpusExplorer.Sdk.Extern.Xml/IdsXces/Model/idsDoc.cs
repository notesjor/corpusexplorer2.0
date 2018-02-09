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
  public class idsDoc
  {
    private idsHeader idsHeaderField;

    private idsText[] idsTextField;

    private string tEIformField;

    private string typeField;

    private decimal versionField;

    /// <remarks />
    public idsHeader idsHeader { get { return idsHeaderField; } set { idsHeaderField = value; } }

    /// <remarks />
    [XmlElement("idsText")]
    public idsText[] idsText { get { return idsTextField; } set { idsTextField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string TEIform { get { return tEIformField; } set { tEIformField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string type { get { return typeField; } set { typeField = value; } }

    /// <remarks />
    [XmlAttribute]
    public decimal version { get { return versionField; } set { versionField = value; } }
  }
}