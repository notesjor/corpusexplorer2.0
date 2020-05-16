namespace CorpusExplorer.Sdk.Extern.Xml.Bawe.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class fileDesc
  {

    private titleStmt titleStmtField;

    private extent extentField;

    private publicationStmt publicationStmtField;

    private notesStmt notesStmtField;

    private sourceDesc sourceDescField;

    private string tEIformField;

    /// <remarks/>
    public titleStmt titleStmt
    {
      get { return this.titleStmtField; }
      set { this.titleStmtField = value; }
    }

    /// <remarks/>
    public extent extent
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
    public notesStmt notesStmt
    {
      get { return this.notesStmtField; }
      set { this.notesStmtField = value; }
    }

    /// <remarks/>
    public sourceDesc sourceDesc
    {
      get { return this.sourceDescField; }
      set { this.sourceDescField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string TEIform
    {
      get { return this.tEIformField; }
      set { this.tEIformField = value; }
    }
  }
}