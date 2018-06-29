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
  [XmlRoot("encodingDesc", Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438",
    IsNullable = false)]
  public class editorialDecl
  {
    private string[] editorialDecl1Field;

    /// <remarks />
    [XmlArray("editorialDecl")]
    [XmlArrayItem("p", IsNullable = false)]
    public string[] editorialDecl1
    {
      get => editorialDecl1Field;
      set => editorialDecl1Field = value;
    }
  }
}