namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438", IsNullable = false)]
  public partial class msDesc
  {

    private msIdentifier msIdentifierField;

    private typeDesc physDescField;

    /// <remarks/>
    public msIdentifier msIdentifier
    {
      get
      {
        return this.msIdentifierField;
      }
      set
      {
        this.msIdentifierField = value;
      }
    }

    /// <remarks/>
    public typeDesc physDesc
    {
      get
      {
        return this.physDescField;
      }
      set
      {
        this.physDescField = value;
      }
    }
  }
}