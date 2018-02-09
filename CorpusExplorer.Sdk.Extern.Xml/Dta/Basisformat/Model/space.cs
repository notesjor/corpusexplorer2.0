using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Basisformat.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class space
  {
    private string dimField;

    private string quantityField;

    private string unitField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string dim { get { return dimField; } set { dimField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "integer")]
    public string quantity { get { return quantityField; } set { quantityField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string unit { get { return unitField; } set { unitField = value; } }
  }
}