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
  public class persName
  {
    private string addNameField;

    private string forenameField;

    private idno idnoField;

    private string surnameField;

    /// <remarks />
    public string addName
    {
      get => addNameField;
      set => addNameField = value;
    }

    /// <remarks />
    public string forename
    {
      get => forenameField;
      set => forenameField = value;
    }

    /// <remarks />
    public idno idno
    {
      get => idnoField;
      set => idnoField = value;
    }

    /// <remarks />
    public string surname
    {
      get => surnameField;
      set => surnameField = value;
    }
  }
}