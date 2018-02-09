namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class div1
  {

    private label labelField;

    private object[] itemsField;

    private string tEIformField;

    private string langField;

    private string nField;

    private string orgField;

    private string partField;

    private string sampleField;

    private string typeField;

    /// <remarks/>
    public label label
    {
      get { return this.labelField; }
      set { this.labelField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("div2", typeof(div2))]
    [System.Xml.Serialization.XmlElementAttribute("head", typeof(head))]
    [System.Xml.Serialization.XmlElementAttribute("l", typeof(l))]
    [System.Xml.Serialization.XmlElementAttribute("lb", typeof(lb))]
    [System.Xml.Serialization.XmlElementAttribute("milestone", typeof(milestone))]
    [System.Xml.Serialization.XmlElementAttribute("opener", typeof(opener))]
    [System.Xml.Serialization.XmlElementAttribute("p", typeof(p))]
    [System.Xml.Serialization.XmlElementAttribute("pb", typeof(pb))]
    [System.Xml.Serialization.XmlElementAttribute("sp", typeof(sp))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
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
    public string lang
    {
      get { return this.langField; }
      set { this.langField = value; }
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