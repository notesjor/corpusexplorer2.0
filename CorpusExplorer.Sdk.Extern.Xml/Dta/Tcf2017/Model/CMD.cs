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
  [XmlRoot("source", Namespace = "http://www.dspin.de/data/metadata", IsNullable = false)]
  public class CMD
  {
    private CMD1 cMD1Field;

    /// <remarks />
    [XmlElement("CMD", Namespace = "http://www.clarin.eu/cmd/1")]
    public CMD1 CMD1
    {
      get => cMD1Field;
      set => cMD1Field = value;
    }
  }
}