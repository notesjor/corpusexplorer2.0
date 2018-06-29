namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class respStmt
  {

    private string respField;

    private persName persNameField;

    /// <remarks/>
    public string resp
    {
      get { return this.respField; }
      set { this.respField = value; }
    }

    /// <remarks/>
    public persName persName
    {
      get { return this.persNameField; }
      set { this.persNameField = value; }
    }
  }
}