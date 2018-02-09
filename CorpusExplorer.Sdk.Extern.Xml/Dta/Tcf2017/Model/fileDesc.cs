namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438", IsNullable = false)]
  public partial class fileDesc
  {

    private titleStmt titleStmtField;

    private edition editionStmtField;

    private measure[] extentField;

    private publicationStmt publicationStmtField;

    private sourceDesc sourceDescField;

    /// <remarks/>
    public titleStmt titleStmt
    {
      get
      {
        return this.titleStmtField;
      }
      set
      {
        this.titleStmtField = value;
      }
    }

    /// <remarks/>
    public edition editionStmt
    {
      get
      {
        return this.editionStmtField;
      }
      set
      {
        this.editionStmtField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("measure", IsNullable = false)]
    public measure[] extent
    {
      get
      {
        return this.extentField;
      }
      set
      {
        this.extentField = value;
      }
    }

    /// <remarks/>
    public publicationStmt publicationStmt
    {
      get
      {
        return this.publicationStmtField;
      }
      set
      {
        this.publicationStmtField = value;
      }
    }

    /// <remarks/>
    public sourceDesc sourceDesc
    {
      get
      {
        return this.sourceDescField;
      }
      set
      {
        this.sourceDescField = value;
      }
    }
  }
}