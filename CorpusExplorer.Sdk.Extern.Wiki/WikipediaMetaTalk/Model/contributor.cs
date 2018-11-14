namespace CorpusExplorer.Sdk.Extern.Wiki.WikipediaMetaTalk
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
    Namespace = "http://www.mediawiki.org/xml/export-0.10/")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.mediawiki.org/xml/export-0.10/",
    IsNullable = false)]
  public partial class contributor
  {

    private string[] itemsField;

    private ItemsChoiceType[] itemsElementNameField;

    private string deletedField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("id", typeof(string), DataType = "integer")]
    [System.Xml.Serialization.XmlElementAttribute("ip", typeof(string), DataType = "NMTOKEN")]
    [System.Xml.Serialization.XmlElementAttribute("username", typeof(string))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public string[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemsChoiceType[] ItemsElementName
    {
      get { return this.itemsElementNameField; }
      set { this.itemsElementNameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string deleted
    {
      get { return this.deletedField; }
      set { this.deletedField = value; }
    }
  }
}