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
  public class resp
  {
    private date dateField;

    private note[] noteField;

    private @ref[] refField;

    /// <remarks />
    public date date
    {
      get => dateField;
      set => dateField = value;
    }

    /// <remarks />
    [XmlElement("note")]
    public note[] note
    {
      get => noteField;
      set => noteField = value;
    }

    /// <remarks />
    [XmlElement("ref")]
    public @ref[] @ref
    {
      get => refField;
      set => refField = value;
    }
  }
}