namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.dspin.de/data/textcorpus", IsNullable = false)]
  public partial class lemmas
  {

    private lemma[] lemmaField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("lemma")]
    public lemma[] lemma
    {
      get
      {
        return this.lemmaField;
      }
      set
      {
        this.lemmaField = value;
      }
    }
  }
}