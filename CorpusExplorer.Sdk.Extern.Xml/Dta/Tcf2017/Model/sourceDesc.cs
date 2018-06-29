using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [XmlRoot(Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438", IsNullable = false)]
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