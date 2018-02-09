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
  public class profileDesc
  {
    private langUsage langUsageField;

    private classCode[] textClassField;

    /// <remarks />
    public langUsage langUsage { get { return langUsageField; } set { langUsageField = value; } }

    /// <remarks />
    [XmlArrayItem("classCode", IsNullable = false)]
    public classCode[] textClass { get { return textClassField; } set { textClassField = value; } }
  }
}