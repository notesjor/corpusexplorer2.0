namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438", IsNullable = false)]
  public partial class seriesStmt
  {

    private title titleField;

    private biblScope[] biblScopeField;

    /// <remarks/>
    public title title
    {
      get
      {
        return this.titleField;
      }
      set
      {
        this.titleField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("biblScope")]
    public biblScope[] biblScope
    {
      get
      {
        return this.biblScopeField;
      }
      set
      {
        this.biblScopeField = value;
      }
    }
  }
}