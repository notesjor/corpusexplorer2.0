namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class textDesc
  {

    private string[] itemsField;

    private ItemsChoiceType2[] itemsElementNameField;

    private string defaultField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("column", typeof(string), DataType = "NCName")]
    [System.Xml.Serialization.XmlElementAttribute("textDomain", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("textType", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("textTypeArt", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("textTypeRef", typeof(string), DataType = "NCName")]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public string[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemsChoiceType2[] ItemsElementName
    {
      get { return this.itemsElementNameField; }
      set { this.itemsElementNameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string Default
    {
      get { return this.defaultField; }
      set { this.defaultField = value; }
    }
  }
}