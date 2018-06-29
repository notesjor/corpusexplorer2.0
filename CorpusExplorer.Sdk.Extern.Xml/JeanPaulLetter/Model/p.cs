namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class p
  {

    private object[] itemsField;

    private ItemsChoiceType1[] itemsElementNameField;

    private string[] textField;

    private string partField;

    private string renditionField;

    private string idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("add", typeof(add))]
    [System.Xml.Serialization.XmlElementAttribute("date", typeof(date))]
    [System.Xml.Serialization.XmlElementAttribute("formula", typeof(formula))]
    [System.Xml.Serialization.XmlElementAttribute("fw", typeof(fw))]
    [System.Xml.Serialization.XmlElementAttribute("hi", typeof(hi))]
    [System.Xml.Serialization.XmlElementAttribute("lb", typeof(lb))]
    [System.Xml.Serialization.XmlElementAttribute("list", typeof(list))]
    [System.Xml.Serialization.XmlElementAttribute("metamark", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("note", typeof(note))]
    [System.Xml.Serialization.XmlElementAttribute("persName", typeof(persName))]
    [System.Xml.Serialization.XmlElementAttribute("placeName", typeof(placeName))]
    [System.Xml.Serialization.XmlElementAttribute("ref", typeof(@ref))]
    [System.Xml.Serialization.XmlElementAttribute("space", typeof(space))]
    [System.Xml.Serialization.XmlElementAttribute("supplied", typeof(string), DataType = "NCName")]
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
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string part
    {
      get { return this.partField; }
      set { this.partField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string rendition
    {
      get { return this.renditionField; }
      set { this.renditionField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified,
      Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }
  }
}