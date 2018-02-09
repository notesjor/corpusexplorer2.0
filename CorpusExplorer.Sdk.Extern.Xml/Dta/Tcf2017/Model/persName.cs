namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438", IsNullable = false)]
  public partial class persName
  {

    private string surnameField;

    private string forenameField;

    private string addNameField;

    private idno idnoField;

    /// <remarks/>
    public string surname
    {
      get
      {
        return this.surnameField;
      }
      set
      {
        this.surnameField = value;
      }
    }

    /// <remarks/>
    public string forename
    {
      get
      {
        return this.forenameField;
      }
      set
      {
        this.forenameField = value;
      }
    }

    /// <remarks/>
    public string addName
    {
      get
      {
        return this.addNameField;
      }
      set
      {
        this.addNameField = value;
      }
    }

    /// <remarks/>
    public idno idno
    {
      get
      {
        return this.idnoField;
      }
      set
      {
        this.idnoField = value;
      }
    }
  }
}