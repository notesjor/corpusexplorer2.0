namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [System.Xml.Serialization.XmlRootAttribute("encodingDesc", Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438", IsNullable = false)]
  public partial class editorialDecl
  {

    private string[] editorialDecl1Field;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute("editorialDecl")]
    [System.Xml.Serialization.XmlArrayItemAttribute("p", IsNullable = false)]
    public string[] editorialDecl1
    {
      get
      {
        return this.editorialDecl1Field;
      }
      set
      {
        this.editorialDecl1Field = value;
      }
    }
  }
}