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
  public class sourceDesc
  {
    private bibl biblField;

    private biblFull biblFullField;

    private msDesc msDescField;

    /// <remarks />
    public bibl bibl
    {
      get => biblField;
      set => biblField = value;
    }

    /// <remarks />
    public biblFull biblFull
    {
      get => biblFullField;
      set => biblFullField = value;
    }

    /// <remarks />
    public msDesc msDesc
    {
      get => msDescField;
      set => msDescField = value;
    }
  }
}