namespace CorpusExplorer.Sdk.Extern.Xml.Brown.Model
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

    private object[] itemsField;

    private ItemsChoiceType[] itemsElementNameField;

    private availability availabilityField;

    private date dateField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("address", typeof(address))]
    [System.Xml.Serialization.XmlElementAttribute("distributor", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("idno", typeof(string), DataType = "NCName")]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public object[] Items
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
    public availability availability
    {
      get { return this.availabilityField; }
      set { this.availabilityField = value; }
    }

    /// <remarks/>
    public date date
    {
      get { return this.dateField; }
      set { this.dateField = value; }
    }
  }
}