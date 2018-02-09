using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Pmg.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot("table-fix", Namespace = "", IsNullable = false)]
  public class tablefix
  {
    private Flow[] trfixField;

    /// <remarks />
    [XmlElement("tr-fix")]
    public Flow[] trfix { get { return trfixField; } set { trfixField = value; } }
  }
}