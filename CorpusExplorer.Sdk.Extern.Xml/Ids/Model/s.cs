namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class s
  {

    private object[] itemsField;

    private string[] textField;

    private string partField;

    private string typeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("distinct", typeof(distinct))]
    [System.Xml.Serialization.XmlElementAttribute("foreign", typeof(foreign))]
    [System.Xml.Serialization.XmlElementAttribute("gap", typeof(gap))]
    [System.Xml.Serialization.XmlElementAttribute("hi", typeof(hi))]
    [System.Xml.Serialization.XmlElementAttribute("list", typeof(list))]
    [System.Xml.Serialization.XmlElementAttribute("name", typeof(name))]
    [System.Xml.Serialization.XmlElementAttribute("orig", typeof(orig))]
    [System.Xml.Serialization.XmlElementAttribute("ptr", typeof(ptr))]
    [System.Xml.Serialization.XmlElementAttribute("q", typeof(q))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
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
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string type
    {
      get { return this.typeField; }
      set { this.typeField = value; }
    }
  }
}