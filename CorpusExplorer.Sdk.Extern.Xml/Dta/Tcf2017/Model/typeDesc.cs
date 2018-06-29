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
  [XmlType(Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [XmlRoot("physDesc", Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438",
    IsNullable = false)]
  public class typeDesc
  {
    private typeDesc1 typeDesc1Field;

    /// <remarks />
    [XmlElement("typeDesc")]
    public typeDesc1 typeDesc1
    {
      get => typeDesc1Field;
      set => typeDesc1Field = value;
    }
  }
}