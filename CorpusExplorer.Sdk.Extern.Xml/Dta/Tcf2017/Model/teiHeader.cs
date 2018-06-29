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
  [XmlRoot("Components", Namespace = "http://www.clarin.eu/cmd/1", IsNullable = false)]
  public class teiHeader
  {
    private teiHeader1 teiHeader1Field;

    /// <remarks />
    [XmlElement("teiHeader")]
    public teiHeader1 teiHeader1
    {
      get => teiHeader1Field;
      set => teiHeader1Field = value;
    }
  }
}