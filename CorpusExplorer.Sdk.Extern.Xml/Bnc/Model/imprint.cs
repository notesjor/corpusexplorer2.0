namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
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

    private ItemsChoiceType[] itemsElementNameField;

    private string ppField;

    private string nField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("date", typeof(date))]
    [System.Xml.Serialization.XmlElementAttribute("pubPlace", typeof(pubPlace))]
    [System.Xml.Serialization.XmlElementAttribute("publisher", typeof(publisher))]
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
    public string pp
    {
      get { return this.ppField; }
      set { this.ppField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string n
    {
      get { return this.nField; }
      set { this.nField = value; }
    }
  }
}