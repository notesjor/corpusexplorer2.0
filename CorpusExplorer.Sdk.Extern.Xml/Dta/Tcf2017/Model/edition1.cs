namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [System.Xml.Serialization.XmlRootAttribute("edition", Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438", IsNullable = false)]
  public partial class edition1
  {

    private string nField;

    private string[] textField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string n
    {
      get
      {
        return this.nField;
      }
      set
      {
        this.nField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text
    {
      get
      {
        return this.textField;
      }
      set
      {
        this.textField = value;
      }
    }
  }
}