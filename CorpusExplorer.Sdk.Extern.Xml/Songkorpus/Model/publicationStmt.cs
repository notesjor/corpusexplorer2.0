namespace CorpusExplorer.Sdk.Extern.Xml.Songkorpus.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class publicationStmt
  {

    private object[] itemsField;

    private string dateField;

    private string publisherField;

    private ItemsChoiceType1[] itemsElementNameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("date", typeof(string), DataType = "integer")]
    public string Date
    {
      get
      {
        return this.dateField;
      }
      set
      {
        this.dateField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("publisher", typeof(string))]
    public string Publisher
    {
      get
      {
        return this.publisherField;
      }
      set
      {
        this.publisherField = value;
      }
    }

    private @ref refField;

    [System.Xml.Serialization.XmlElementAttribute("ref", typeof(@ref))]
    public @ref Reference
    {
      get
      {
        return this.refField;
      }
      set
      {
        this.refField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ab", typeof(ab))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public object[] Items
    {
      get
      {
        return this.itemsField;
      }
      set
      {
        this.itemsField = value;
      }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemsChoiceType1[] ItemsElementName
    {
      get
      {
        return this.itemsElementNameField;
      }
      set
      {
        this.itemsElementNameField = value;
      }
    }
  }
}