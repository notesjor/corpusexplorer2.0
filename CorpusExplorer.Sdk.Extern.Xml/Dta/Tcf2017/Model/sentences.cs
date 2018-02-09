namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.dspin.de/data/textcorpus", IsNullable = false)]
  public partial class sentences
  {

    private sentence[] sentenceField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("sentence")]
    public sentence[] sentence
    {
      get
      {
        return this.sentenceField;
      }
      set
      {
        this.sentenceField = value;
      }
    }
  }
}