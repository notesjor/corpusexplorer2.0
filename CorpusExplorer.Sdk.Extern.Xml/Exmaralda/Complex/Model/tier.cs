namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Complex.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class tier
  {

    private @event[] eventField;

    private string categoryField;

    private string displaynameField;

    private string idField;

    private string speakerField;

    private string typeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("event")]
    public @event[] @event
    {
      get { return this.eventField; }
      set { this.eventField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string category
    {
      get { return this.categoryField; }
      set { this.categoryField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("display-name")]
    public string displayname
    {
      get { return this.displaynameField; }
      set { this.displaynameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string speaker
    {
      get { return this.speakerField; }
      set { this.speakerField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string type
    {
      get { return this.typeField; }
      set { this.typeField = value; }
    }
  }
}