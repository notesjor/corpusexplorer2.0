namespace CorpusExplorer.Sdk.Extern.Xml.Perseus.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class titleStmt
  {

    private string titleField;

    private string authorField;

    /// <remarks/>
    public string title
    {
      get { return this.titleField; }
      set { this.titleField = value; }
    }

    /// <remarks/>
    public string author
    {
      get { return this.authorField; }
      set { this.authorField = value; }
    }
  }
}