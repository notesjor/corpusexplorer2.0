namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class textClass
  {

    private catRef catRefField;

    private classCode classCodeField;

    private keywords[] keywordsField;

    /// <remarks/>
    public catRef catRef
    {
      get { return this.catRefField; }
      set { this.catRefField = value; }
    }

    /// <remarks/>
    public classCode classCode
    {
      get { return this.classCodeField; }
      set { this.classCodeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("keywords")]
    public keywords[] keywords
    {
      get { return this.keywordsField; }
      set { this.keywordsField = value; }
    }
  }
}