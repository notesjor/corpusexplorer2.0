namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438", IsNullable = false)]
  public partial class profileDesc
  {

    private @abstract abstractField;

    private language langUsageField;

    private classCode[] textClassField;

    /// <remarks/>
    public @abstract @abstract
    {
      get
      {
        return this.abstractField;
      }
      set
      {
        this.abstractField = value;
      }
    }

    /// <remarks/>
    public language langUsage
    {
      get
      {
        return this.langUsageField;
      }
      set
      {
        this.langUsageField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("classCode", IsNullable = false)]
    public classCode[] textClass
    {
      get
      {
        return this.textClassField;
      }
      set
      {
        this.textClassField = value;
      }
    }
  }
}