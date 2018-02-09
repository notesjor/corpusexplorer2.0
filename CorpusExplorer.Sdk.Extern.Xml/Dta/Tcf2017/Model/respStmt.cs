namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438", IsNullable = false)]
  public partial class respStmt
  {

    private persName[] persNameField;

    private orgName orgNameField;

    private resp respField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("persName")]
    public persName[] persName
    {
      get
      {
        return this.persNameField;
      }
      set
      {
        this.persNameField = value;
      }
    }

    /// <remarks/>
    public orgName orgName
    {
      get
      {
        return this.orgNameField;
      }
      set
      {
        this.orgNameField = value;
      }
    }

    /// <remarks/>
    public resp resp
    {
      get
      {
        return this.respField;
      }
      set
      {
        this.respField = value;
      }
    }
  }
}