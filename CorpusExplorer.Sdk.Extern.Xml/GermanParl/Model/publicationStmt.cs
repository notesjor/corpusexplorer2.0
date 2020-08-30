namespace CorpusExplorer.Sdk.Extern.Xml.GermanParl.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class publicationStmt
  {

    private string publisherField;

    private date dateField;

    private page pageField;

    /// <remarks/>
    public string publisher
    {
      get { return this.publisherField; }
      set { this.publisherField = value; }
    }

    /// <remarks/>
    public date date
    {
      get { return this.dateField; }
      set { this.dateField = value; }
    }

    /// <remarks/>
    public page page
    {
      get { return this.pageField; }
      set { this.pageField = value; }
    }
  }
}