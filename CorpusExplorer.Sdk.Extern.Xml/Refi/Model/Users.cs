namespace CorpusExplorer.Sdk.Extern.Xml.Refi.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:QDA-XML:project:1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:QDA-XML:project:1.0", IsNullable = false)]
  public partial class Users
  {

    private User[] userField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("User")]
    public User[] User
    {
      get
      {
        return this.userField;
      }
      set
      {
        this.userField = value;
      }
    }
  }
}