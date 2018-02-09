namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class div2
  {

    private object[] itemsField;

    private lg[] lgField;

    private object[] items1Field;

    private p[] pField;

    private div3[] div3Field;

    private string tEIformField;

    private string metField;

    private string nField;

    private string orgField;

    private string partField;

    private string sampleField;

    private string typeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("docAuthor", typeof(docAuthor))]
    [System.Xml.Serialization.XmlElementAttribute("head", typeof(head))]
    [System.Xml.Serialization.XmlElementAttribute("l", typeof(l))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("lg")]
    public lg[] lg
    {
      get { return this.lgField; }
      set { this.lgField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("label", typeof(label))]
    [System.Xml.Serialization.XmlElementAttribute("milestone", typeof(milestone))]
    [System.Xml.Serialization.XmlElementAttribute("sp", typeof(sp))]
    public object[] Items1
    {
      get { return this.items1Field; }
      set { this.items1Field = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("p")]
    public p[] p
    {
      get { return this.pField; }
      set { this.pField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("div3")]
    public div3[] div3
    {
      get { return this.div3Field; }
      set { this.div3Field = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string TEIform
    {
      get { return this.tEIformField; }
      set { this.tEIformField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string met
    {
      get { return this.metField; }
      set { this.metField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string n
    {
      get { return this.nField; }
      set { this.nField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string org
    {
      get { return this.orgField; }
      set { this.orgField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string part
    {
      get { return this.partField; }
      set { this.partField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string sample
    {
      get { return this.sampleField; }
      set { this.sampleField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string type
    {
      get { return this.typeField; }
      set { this.typeField = value; }
    }
  }
}