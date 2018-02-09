namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438", IsNullable = false)]
  public partial class titleStmt
  {

    private title[] titleField;

    private author authorField;

    private editor[] editorField;

    private respStmt[] respStmtField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("title")]
    public title[] title
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
    public author author
    {
      get
      {
        return this.authorField;
      }
      set
      {
        this.authorField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("editor")]
    public editor[] editor
    {
      get
      {
        return this.editorField;
      }
      set
      {
        this.editorField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("respStmt")]
    public respStmt[] respStmt
    {
      get
      {
        return this.respStmtField;
      }
      set
      {
        this.respStmtField = value;
      }
    }
  }
}