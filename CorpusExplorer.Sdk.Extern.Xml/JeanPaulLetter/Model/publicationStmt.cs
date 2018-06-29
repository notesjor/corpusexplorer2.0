namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class publicationStmt
  {

    private publisher publisherField;

    private string pubPlaceField;

    private date dateField;

    private availability availabilityField;

    private idno idnoField;

    /// <remarks/>
    public publisher publisher
    {
      get { return this.publisherField; }
      set { this.publisherField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "NCName")]
    public string pubPlace
    {
      get { return this.pubPlaceField; }
      set { this.pubPlaceField = value; }
    }

    /// <remarks/>
    public date date
    {
      get { return this.dateField; }
      set { this.dateField = value; }
    }

    /// <remarks/>
    public availability availability
    {
      get { return this.availabilityField; }
      set { this.availabilityField = value; }
    }

    /// <remarks/>
    public idno idno
    {
      get { return this.idnoField; }
      set { this.idnoField = value; }
    }
  }
}