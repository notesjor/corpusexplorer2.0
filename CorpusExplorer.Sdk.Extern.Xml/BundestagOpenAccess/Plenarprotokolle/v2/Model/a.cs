namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class a
  {

    private string[] itemsField;

    private ItemsChoiceType3[] itemsElementNameField;

    private string[] textField;

    private aTyp typField;

    private bool typFieldSpecified;

    private string idField;

    private string nameField;

    private string hrefField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("seite", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("seitenbereich", typeof(string))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public string[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemsChoiceType3[] ItemsElementName
    {
      get { return this.itemsElementNameField; }
      set { this.itemsElementNameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text
    {
      get { return this.textField; }
      set { this.textField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public aTyp typ
    {
      get { return this.typField; }
      set { this.typField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool typSpecified
    {
      get { return this.typFieldSpecified; }
      set { this.typFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
    {
      get { return this.nameField; }
      set { this.nameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string href
    {
      get { return this.hrefField; }
      set { this.hrefField = value; }
    }
  }
}