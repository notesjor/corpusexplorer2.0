namespace CorpusExplorer.Sdk.Extern.Xml.Dta.Tcf2017.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.dspin.de/data/textcorpus", IsNullable = false)]
  public partial class orthography
  {

    private correction[] correctionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("correction")]
    public correction[] correction
    {
      get
      {
        return this.correctionField;
      }
      set
      {
        this.correctionField = value;
      }
    }
  }
}