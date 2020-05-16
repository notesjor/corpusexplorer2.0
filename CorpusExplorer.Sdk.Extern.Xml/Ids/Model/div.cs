namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class div
  {

    private object[] itemsField;

    private object[] items1Field;

    private closer closerField;

    private string completeField;

    private string nField;

    private string orgField;

    private string partField;

    private string sampleField;

    private string typeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("figure", typeof(figure))]
    [System.Xml.Serialization.XmlElementAttribute("note", typeof(note))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("byline", typeof(byline))]
    [System.Xml.Serialization.XmlElementAttribute("div", typeof(div))]
    [System.Xml.Serialization.XmlElementAttribute("head", typeof(head))]
    [System.Xml.Serialization.XmlElementAttribute("opener", typeof(opener))]
    [System.Xml.Serialization.XmlElementAttribute("p", typeof(p))]
    [System.Xml.Serialization.XmlElementAttribute("ptr", typeof(ptr))]
    public object[] Items1
    {
      get { return this.items1Field; }
      set { this.items1Field = value; }
    }

    /// <remarks/>
    public closer closer
    {
      get { return this.closerField; }
      set { this.closerField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string complete
    {
      get { return this.completeField; }
      set { this.completeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
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