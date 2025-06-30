namespace CorpusExplorer.Sdk.Extern.Xml.Refi.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:QDA-XML:project:1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:QDA-XML:project:1.0", IsNullable = false)]
  public partial class TextSource
  {

    private string descriptionField;

    private PlainTextSelection[] plainTextSelectionField;

    private string creatingUserField;

    private System.DateTime creationDateTimeField;

    private string guidField;

    private System.DateTime modifiedDateTimeField;

    private string modifyingUserField;

    private string nameField;

    private string plainTextPathField;

    /// <remarks/>
    public string Description
    {
      get
      {
        return this.descriptionField;
      }
      set
      {
        this.descriptionField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PlainTextSelection")]
    public PlainTextSelection[] PlainTextSelection
    {
      get
      {
        return this.plainTextSelectionField;
      }
      set
      {
        this.plainTextSelectionField = value;
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

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public System.DateTime modifiedDateTime
    {
      get
      {
        return this.modifiedDateTimeField;
      }
      set
      {
        this.modifiedDateTimeField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string modifyingUser
    {
      get
      {
        return this.modifyingUserField;
      }
      set
      {
        this.modifyingUserField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
    {
      get
      {
        return this.nameField;
      }
      set
      {
        this.nameField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
    public string plainTextPath
    {
      get
      {
        return this.plainTextPathField;
      }
      set
      {
        this.plainTextPathField = value;
      }
    }
  }
}