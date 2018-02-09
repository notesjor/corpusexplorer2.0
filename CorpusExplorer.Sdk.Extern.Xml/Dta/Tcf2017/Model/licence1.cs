namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [System.Xml.Serialization.XmlRootAttribute("licence", Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438", IsNullable = false)]
  public partial class licence1
  {

    private string pField;

    private string targetField;

    /// <remarks/>
    public string p
    {
      get
      {
        return this.pField;
      }
      set
      {
        this.pField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string target
    {
      get
      {
        return this.targetField;
      }
      set
      {
        this.targetField = value;
      }
    }
  }
}