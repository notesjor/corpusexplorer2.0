namespace CorpusExplorer.Sdk.Extern.Xml.Songkorpus.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class titleStmt
  {

    private string titleField;

    private author[] authorField;

    /// <remarks/>
    public string title
    {
      get
      {
        return this.titleField;
      }
      set
      {
        this.titleField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("author")]
    public author[] author
    {
      get
      {
        return this.authorField;
      }
      set
      {
        this.authorField = value;
      }
    }
  }
}