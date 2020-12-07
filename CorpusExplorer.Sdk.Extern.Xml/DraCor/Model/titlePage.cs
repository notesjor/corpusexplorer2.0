namespace CorpusExplorer.Sdk.Extern.Xml.DraCor.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class titlePage
  {

    private docTitle docTitleField;

    private byline bylineField;

    private docImprint docImprintField;

    /// <remarks/>
    public docTitle docTitle
    {
      get { return this.docTitleField; }
      set { this.docTitleField = value; }
    }

    /// <remarks/>
    public byline byline
    {
      get { return this.bylineField; }
      set { this.bylineField = value; }
    }

    /// <remarks/>
    public docImprint docImprint
    {
      get { return this.docImprintField; }
      set { this.docImprintField = value; }
    }
  }
}