using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.PromXes.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.xes-standard.org/")]
  [XmlRoot(Namespace = "http://www.xes-standard.org/", IsNullable = false)]
  public class @int
  {
    private @int int1Field;

    private string keyField;

    private @string stringField;

    private string valueField;

    /// <remarks />
    [XmlElement("int")]
    public @int int1 { get { return int1Field; } set { int1Field = value; } }

    /// <remarks />
    [XmlAttribute]
    public string key { get { return keyField; } set { keyField = value; } }

    /// <remarks />
    public @string @string { get { return stringField; } set { stringField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string value { get { return valueField; } set { valueField = value; } }
  }
}