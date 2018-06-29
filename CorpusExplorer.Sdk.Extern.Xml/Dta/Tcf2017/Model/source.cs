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
  [XmlRoot("MetaData", Namespace = "http://www.dspin.de/data/metadata", IsNullable = false)]
  public class source
  {
    private CMD source1Field;

    /// <remarks />
    [XmlElement("source", Namespace = "http://www.dspin.de/data/metadata")]
    public CMD source1
    {
      get => source1Field;
      set => source1Field = value;
    }
  }
}