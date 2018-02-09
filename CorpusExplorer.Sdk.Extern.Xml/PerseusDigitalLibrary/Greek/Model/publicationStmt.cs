namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class publicationStmt
  {

    private publisher publisherField;

    private pubPlace pubPlaceField;

    private authority authorityField;

    private string tEIformField;

    /// <remarks/>
    public publisher publisher
    {
      get { return this.publisherField; }
      set { this.publisherField = value; }
    }

    /// <remarks/>
    public pubPlace pubPlace
    {
      get { return this.pubPlaceField; }
      set { this.pubPlaceField = value; }
    }

    /// <remarks/>
    public authority authority
    {
      get { return this.authorityField; }
      set { this.authorityField = value; }
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