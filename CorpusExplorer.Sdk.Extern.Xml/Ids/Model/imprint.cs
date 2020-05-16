namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class imprint
  {

    private object[] itemsField;

    private ItemsChoiceType1[] itemsElementNameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("pubDate", typeof(pubDate))]
    [System.Xml.Serialization.XmlElementAttribute("pubPlace", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("publisher", typeof(string))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemsChoiceType1[] ItemsElementName
    {
      get { return this.itemsElementNameField; }
      set { this.itemsElementNameField = value; }
    }
  }
}