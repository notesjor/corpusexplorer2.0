#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Speech.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class timeline
  {
    private string originField;
    private string unitField;
    private when[] whenField;

    /// <remarks />
    [XmlAttribute]
    public string origin { get { return originField; } set { originField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string unit { get { return unitField; } set { unitField = value; } }

    /// <remarks />
    [XmlElement("when")]
    public when[] when { get { return whenField; } set { whenField = value; } }
  }
}