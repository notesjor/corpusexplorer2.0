namespace CorpusExplorer.Sdk.Extern.Xml.GermanParl.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class titleStmt
  {

    private string titleField;

    private string legislativePeriodField;

    private string sessionNoField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "NCName")]
    public string title
    {
      get { return this.titleField; }
      set { this.titleField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
    public string legislativePeriod
    {
      get { return this.legislativePeriodField; }
      set { this.legislativePeriodField = value; }
    }

    /// <remarks/>
    public string sessionNo
    {
      get { return this.sessionNoField; }
      set { this.sessionNoField = value; }
    }
  }
}