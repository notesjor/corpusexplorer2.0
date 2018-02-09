namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438", IsNullable = false)]
  public partial class resp
  {

    private note[] noteField;

    private @ref refField;

    private date dateField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("note")]
    public note[] note
    {
      get
      {
        return this.noteField;
      }
      set
      {
        this.noteField = value;
      }
    }

    /// <remarks/>
    public @ref @ref
    {
      get
      {
        return this.refField;
      }
      set
      {
        this.refField = value;
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
  }
}