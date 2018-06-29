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
  public class teiHeader
  {
    private encodingDesc encodingDescField;

    private fileDesc fileDescField;

    private profileDesc profileDescField;

    /// <remarks />
    public encodingDesc encodingDesc
    {
      get => encodingDescField;
      set => encodingDescField = value;
    }

    /// <remarks />
    public fileDesc fileDesc
    {
      get => fileDescField;
      set => fileDescField = value;
    }

    /// <remarks />
    public profileDesc profileDesc
    {
      get => profileDescField;
      set => profileDescField = value;
    }
  }
}