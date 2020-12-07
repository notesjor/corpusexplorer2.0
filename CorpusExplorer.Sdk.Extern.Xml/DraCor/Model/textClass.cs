namespace CorpusExplorer.Sdk.Extern.Xml.DraCor.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class textClass
  {

    private keywords keywordsField;

    private classCode classCodeField;

    /// <remarks/>
    public keywords keywords
    {
      get { return this.keywordsField; }
      set { this.keywordsField = value; }
    }

    /// <remarks/>
    public classCode classCode
    {
      get { return this.classCodeField; }
      set { this.classCodeField = value; }
    }
  }
}