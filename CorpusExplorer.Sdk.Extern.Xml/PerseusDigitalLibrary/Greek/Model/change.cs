namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class change
  {

    private date dateField;

    private respStmt respStmtField;

    private item itemField;

    private string tEIformField;

    /// <remarks/>
    public date date
    {
      get { return this.dateField; }
      set { this.dateField = value; }
    }

    /// <remarks/>
    public respStmt respStmt
    {
      get { return this.respStmtField; }
      set { this.respStmtField = value; }
    }

    /// <remarks/>
    public item item
    {
      get { return this.itemField; }
      set { this.itemField = value; }
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