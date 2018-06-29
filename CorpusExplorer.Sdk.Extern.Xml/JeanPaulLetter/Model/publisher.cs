namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class publisher
  {

    private string emailField;

    private string[] orgNameField;

    private address addressField;

    /// <remarks/>
    public string email
    {
      get { return this.emailField; }
      set { this.emailField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("orgName")]
    public string[] orgName
    {
      get { return this.orgNameField; }
      set { this.orgNameField = value; }
    }

    /// <remarks/>
    public address address
    {
      get { return this.addressField; }
      set { this.addressField = value; }
    }
  }
}