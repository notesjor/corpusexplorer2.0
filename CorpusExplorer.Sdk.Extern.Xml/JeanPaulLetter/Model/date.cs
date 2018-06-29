namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class date
  {

    private object[] itemsField;

    private string[] textField;

    private string certField;

    private string correspField;

    private System.DateTime fromField;

    private bool fromFieldSpecified;

    private bool instantField;

    private bool instantFieldSpecified;

    private System.DateTime notAfterField;

    private bool notAfterFieldSpecified;

    private System.DateTime notBeforeField;

    private bool notBeforeFieldSpecified;

    private System.DateTime toField;

    private bool toFieldSpecified;

    private string typeField;

    private System.DateTime whenField;

    private bool whenFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("add", typeof(add))]
    [System.Xml.Serialization.XmlElementAttribute("hi", typeof(hi))]
    [System.Xml.Serialization.XmlElementAttribute("lb", typeof(lb))]
    [System.Xml.Serialization.XmlElementAttribute("metamark", typeof(string))]
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
    public string cert
    {
      get { return this.certField; }
      set { this.certField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string corresp
    {
      get { return this.correspField; }
      set { this.correspField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    public System.DateTime from
    {
      get { return this.fromField; }
      set { this.fromField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool fromSpecified
    {
      get { return this.fromFieldSpecified; }
      set { this.fromFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool instant
    {
      get { return this.instantField; }
      set { this.instantField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool instantSpecified
    {
      get { return this.instantFieldSpecified; }
      set { this.instantFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    public System.DateTime notAfter
    {
      get { return this.notAfterField; }
      set { this.notAfterField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool notAfterSpecified
    {
      get { return this.notAfterFieldSpecified; }
      set { this.notAfterFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    public System.DateTime notBefore
    {
      get { return this.notBeforeField; }
      set { this.notBeforeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool notBeforeSpecified
    {
      get { return this.notBeforeFieldSpecified; }
      set { this.notBeforeFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    public System.DateTime to
    {
      get { return this.toField; }
      set { this.toField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool toSpecified
    {
      get { return this.toFieldSpecified; }
      set { this.toFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string type
    {
      get { return this.typeField; }
      set { this.typeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    public System.DateTime when
    {
      get { return this.whenField; }
      set { this.whenField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool whenSpecified
    {
      get { return this.whenFieldSpecified; }
      set { this.whenFieldSpecified = value; }
    }
  }
}