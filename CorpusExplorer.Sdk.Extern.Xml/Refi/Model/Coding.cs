namespace CorpusExplorer.Sdk.Extern.Xml.Refi.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:QDA-XML:project:1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:QDA-XML:project:1.0", IsNullable = false)]
  public partial class Coding
  {

    private CodeRef codeRefField;

    private string creatingUserField;

    private System.DateTime creationDateTimeField;

    private string guidField;

    /// <remarks/>
    public CodeRef CodeRef
    {
      get
      {
        return this.codeRefField;
      }
      set
      {
        this.codeRefField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string creatingUser
    {
      get
      {
        return this.creatingUserField;
      }
      set
      {
        this.creatingUserField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public System.DateTime creationDateTime
    {
      get
      {
        return this.creationDateTimeField;
      }
      set
      {
        this.creationDateTimeField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string guid
    {
      get
      {
        return this.guidField;
      }
      set
      {
        this.guidField = value;
      }
    }
  }
}