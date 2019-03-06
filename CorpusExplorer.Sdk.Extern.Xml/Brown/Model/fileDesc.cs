namespace CorpusExplorer.Sdk.Extern.Xml.Brown.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class fileDesc
  {

    private titleStmt titleStmtField;

    private editionStmt editionStmtField;

    private string extentField;

    private publicationStmt publicationStmtField;

    private sourceDesc sourceDescField;

    /// <remarks/>
    public titleStmt titleStmt
    {
      get { return this.titleStmtField; }
      set { this.titleStmtField = value; }
    }

    /// <remarks/>
    public editionStmt editionStmt
    {
      get { return this.editionStmtField; }
      set { this.editionStmtField = value; }
    }

    /// <remarks/>
    public string extent
    {
      get { return this.extentField; }
      set { this.extentField = value; }
    }

    /// <remarks/>
    public publicationStmt publicationStmt
    {
      get { return this.publicationStmtField; }
      set { this.publicationStmtField = value; }
    }

    /// <remarks/>
    public sourceDesc sourceDesc
    {
      get { return this.sourceDescField; }
      set { this.sourceDescField = value; }
    }
  }
}