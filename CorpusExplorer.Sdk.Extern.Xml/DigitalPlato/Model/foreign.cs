namespace CorpusExplorer.Sdk.Extern.Xml.DigitalPlato.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class foreign
  {

    private object[] itemsField;

    private ItemsChoiceType[] itemsElementNameField;

    private string[] textField;

    private bool is_a_numberField;

    private bool is_a_numberFieldSpecified;

    private string langField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("hi", typeof(hi))]
    [System.Xml.Serialization.XmlElementAttribute("speaker", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("title", typeof(string))]
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
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text
    {
      get { return this.textField; }
      set { this.textField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool is_a_number
    {
      get { return this.is_a_numberField; }
      set { this.is_a_numberField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool is_a_numberSpecified
    {
      get { return this.is_a_numberFieldSpecified; }
      set { this.is_a_numberFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified,
      Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string lang
    {
      get { return this.langField; }
      set { this.langField = value; }
    }
  }
}