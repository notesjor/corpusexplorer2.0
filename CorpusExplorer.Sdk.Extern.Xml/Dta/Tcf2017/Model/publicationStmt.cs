namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438", IsNullable = false)]
  public partial class publicationStmt
  {

    private string[] pubPlaceField;

    private date dateField;

    private publisher[] publisherField;

    private licence availabilityField;

    private idno idnoField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("pubPlace")]
    public string[] pubPlace
    {
      get
      {
        return this.pubPlaceField;
      }
      set
      {
        this.pubPlaceField = value;
      }
    }

    /// <remarks/>
    public date date
    {
      get
      {
        return this.dateField;
      }
      set
      {
        this.dateField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("publisher")]
    public publisher[] publisher
    {
      get
      {
        return this.publisherField;
      }
      set
      {
        this.publisherField = value;
      }
    }

    /// <remarks/>
    public licence availability
    {
      get
      {
        return this.availabilityField;
      }
      set
      {
        this.availabilityField = value;
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