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
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class artikel
  {
    private inhalt inhaltField;

    private metadaten metadatenField;

    /// <remarks />
    public inhalt inhalt { get { return inhaltField; } set { inhaltField = value; } }

    /// <remarks />
    public metadaten metadaten { get { return metadatenField; } set { metadatenField = value; } }
  }
}