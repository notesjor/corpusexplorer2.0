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
  public class msDesc
  {
    private msIdentifier msIdentifierField;

    private physDesc physDescField;

    /// <remarks />
    public msIdentifier msIdentifier { get { return msIdentifierField; } set { msIdentifierField = value; } }

    /// <remarks />
    public physDesc physDesc { get { return physDescField; } set { physDescField = value; } }
  }
}