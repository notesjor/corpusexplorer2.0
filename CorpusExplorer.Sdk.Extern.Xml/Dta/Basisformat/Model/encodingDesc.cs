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
  public class encodingDesc
  {
    private p[] editorialDeclField;

    private rendition[] tagsDeclField;

    /// <remarks />
    [XmlArrayItem("p", IsNullable = false)]
    public p[] editorialDecl { get { return editorialDeclField; } set { editorialDeclField = value; } }

    /// <remarks />
    [XmlArrayItem("rendition", IsNullable = false)]
    public rendition[] tagsDecl { get { return tagsDeclField; } set { tagsDeclField = value; } }
  }
}