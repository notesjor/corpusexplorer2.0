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
  public class profileDesc
  {
    private @abstract abstractField;

    private language langUsageField;

    private classCode[] textClassField;

    /// <remarks />
    public @abstract @abstract
    {
      get => abstractField;
      set => abstractField = value;
    }

    /// <remarks />
    public language langUsage
    {
      get => langUsageField;
      set => langUsageField = value;
    }

    /// <remarks />
    [XmlArrayItem("classCode", IsNullable = false)]
    public classCode[] textClass
    {
      get => textClassField;
      set => textClassField = value;
    }
  }
}