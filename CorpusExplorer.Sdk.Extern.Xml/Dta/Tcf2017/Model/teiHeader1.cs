namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [System.Xml.Serialization.XmlRootAttribute("teiHeader", Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438", IsNullable = false)]
  public partial class teiHeader1
  {

    private fileDesc fileDescField;

    private editorialDecl encodingDescField;

    private profileDesc profileDescField;

    /// <remarks/>
    public fileDesc fileDesc
    {
      get
      {
        return this.fileDescField;
      }
      set
      {
        this.fileDescField = value;
      }
    }

    /// <remarks/>
    public editorialDecl encodingDesc
    {
      get
      {
        return this.encodingDescField;
      }
      set
      {
        this.encodingDescField = value;
      }
    }

    /// <remarks/>
    public profileDesc profileDesc
    {
      get
      {
        return this.profileDescField;
      }
      set
      {
        this.profileDescField = value;
      }
    }
  }
}