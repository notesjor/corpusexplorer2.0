namespace CorpusExplorer.Sdk.Extern.Xml.Tei.P5Cal2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class titleStmt
  {

    private title[] titleField;

    private string funderField;

    private respStmt[] respStmtField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("title")]
    public title[] title
    {
      get { return this.titleField; }
      set { this.titleField = value; }
    }

    /// <remarks/>
    public string funder
    {
      get { return this.funderField; }
      set { this.funderField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("respStmt")]
    public respStmt[] respStmt
    {
      get { return this.respStmtField; }
      set { this.respStmtField = value; }
    }
  }
}