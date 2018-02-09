using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.HuDesktop.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "http://www.tei-c.org/ns/1.0")]
  public class p
  {
    private p1 p1Field;

    /// <remarks />
    [XmlElement("p")]
    public p1 p1 { get { return p1Field; } set { p1Field = value; } }
  }
}