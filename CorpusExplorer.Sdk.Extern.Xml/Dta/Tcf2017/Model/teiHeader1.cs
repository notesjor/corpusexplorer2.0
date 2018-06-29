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
  [XmlRoot("teiHeader", Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438",
    IsNullable = false)]
  public class teiHeader1
  {
    private editorialDecl encodingDescField;

    private fileDesc fileDescField;

    private profileDesc profileDescField;

    /// <remarks />
    public editorialDecl encodingDesc
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