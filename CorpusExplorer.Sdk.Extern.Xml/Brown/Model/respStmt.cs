namespace CorpusExplorer.Sdk.Extern.Xml.Brown.Model
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

    private string[] nameField;

    /// <remarks/>
    public string resp
    {
      get { return this.respField; }
      set { this.respField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("name")]
    public string[] name
    {
      get { return this.nameField; }
      set { this.nameField = value; }
    }
  }
}