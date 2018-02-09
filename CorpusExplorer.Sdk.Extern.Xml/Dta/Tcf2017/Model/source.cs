namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.clarin.eu/cmd/1/profiles/clarin.eu:cr1:p_1381926654438")]
  [System.Xml.Serialization.XmlRootAttribute("MetaData", Namespace = "http://www.dspin.de/data/metadata", IsNullable = false)]
  public partial class source
  {

    private CMD source1Field;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("source", Namespace = "http://www.dspin.de/data/metadata")]
    public CMD source1
    {
      get
      {
        return this.source1Field;
      }
      set
      {
        this.source1Field = value;
      }
    }
  }
}