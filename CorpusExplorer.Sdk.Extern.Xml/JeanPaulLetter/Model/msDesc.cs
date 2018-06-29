namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class msDesc
  {

    private msIdentifier msIdentifierField;

    private p pField;

    private string statusField;

    /// <remarks/>
    public msIdentifier msIdentifier
    {
      get { return this.msIdentifierField; }
      set { this.msIdentifierField = value; }
    }

    /// <remarks/>
    public p p
    {
      get { return this.pField; }
      set { this.pField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string status
    {
      get { return this.statusField; }
      set { this.statusField = value; }
    }
  }
}