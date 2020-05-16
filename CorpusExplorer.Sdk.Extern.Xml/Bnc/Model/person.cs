namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class person
  {

    private string ageField;

    private string persNameField;

    private string occupationField;

    private string itemField;

    private ItemChoiceType itemElementNameField;

    private string ageGroupField;

    private string dialectField;

    private string educField;

    private string firstLangField;

    private string nField;

    private string roleField;

    private string sexField;

    private string socField;

    private string idField;

    /// <remarks/>
    public string age
    {
      get { return this.ageField; }
      set { this.ageField = value; }
    }

    /// <remarks/>
    public string persName
    {
      get { return this.persNameField; }
      set { this.persNameField = value; }
    }

    /// <remarks/>
    public string occupation
    {
      get { return this.occupationField; }
      set { this.occupationField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("dialect", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("persNote", typeof(string))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
    public string Item
    {
      get { return this.itemField; }
      set { this.itemField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemChoiceType ItemElementName
    {
      get { return this.itemElementNameField; }
      set { this.itemElementNameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string ageGroup
    {
      get { return this.ageGroupField; }
      set { this.ageGroupField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string dialect
    {
      get { return this.dialectField; }
      set { this.dialectField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string educ
    {
      get { return this.educField; }
      set { this.educField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string firstLang
    {
      get { return this.firstLangField; }
      set { this.firstLangField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string n
    {
      get { return this.nField; }
      set { this.nField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string role
    {
      get { return this.roleField; }
      set { this.roleField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string sex
    {
      get { return this.sexField; }
      set { this.sexField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string soc
    {
      get { return this.socField; }
      set { this.socField = value; }
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