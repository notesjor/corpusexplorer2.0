namespace CorpusExplorer.Sdk.Extern.Xml.DigitalPlato.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class ab
  {

    private object[] itemsField;

    private ItemsChoiceType1[] itemsElementNameField;

    private string[] textField;

    private string l0Field;

    private string l1Field;

    private string l2Field;

    private string l6Field;

    private string l7Field;

    private string l8Field;

    private string l9Field;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("foreign", typeof(foreign))]
    [System.Xml.Serialization.XmlElementAttribute("hi", typeof(hi))]
    [System.Xml.Serialization.XmlElementAttribute("lb", typeof(lb))]
    [System.Xml.Serialization.XmlElementAttribute("note", typeof(note))]
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
    public ItemsChoiceType1[] ItemsElementName
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
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
    public string l0
    {
      get { return this.l0Field; }
      set { this.l0Field = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
    public string l1
    {
      get { return this.l1Field; }
      set { this.l1Field = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string l2
    {
      get { return this.l2Field; }
      set { this.l2Field = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string l6
    {
      get { return this.l6Field; }
      set { this.l6Field = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string l7
    {
      get { return this.l7Field; }
      set { this.l7Field = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string l8
    {
      get { return this.l8Field; }
      set { this.l8Field = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string l9
    {
      get { return this.l9Field; }
      set { this.l9Field = value; }
    }
  }
}