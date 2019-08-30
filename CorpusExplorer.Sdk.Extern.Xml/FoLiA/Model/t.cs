namespace CorpusExplorer.Sdk.Extern.Xml.FoLiA.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ilk.uvt.nl/folia")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://ilk.uvt.nl/folia", IsNullable = false)]
  public partial class t
  {

    private object[] itemsField;

    private string[] textField;

    private string classField;

    private string setField;

    private string annotatorField;

    private string annotatortypeField;

    private string processorField;

    private double confidenceField;

    private bool confidenceFieldSpecified;

    private System.DateTime datetimeField;

    private bool datetimeFieldSpecified;

    private string metadataField;

    private string hrefField;

    private string typeField;

    private string roleField;

    private string titleField;

    private string labelField;

    private string showField;

    private string authField;

    private string offsetField;

    private string refField;

    private System.Xml.XmlAttribute[] anyAttrField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("br", typeof(br))]
    [System.Xml.Serialization.XmlElementAttribute("comment", typeof(comment))]
    [System.Xml.Serialization.XmlElementAttribute("desc", typeof(desc))]
    [System.Xml.Serialization.XmlElementAttribute("t-correction", typeof(tcorrection))]
    [System.Xml.Serialization.XmlElementAttribute("t-error", typeof(terror))]
    [System.Xml.Serialization.XmlElementAttribute("t-gap", typeof(tgap))]
    [System.Xml.Serialization.XmlElementAttribute("t-hbr", typeof(thbr))]
    [System.Xml.Serialization.XmlElementAttribute("t-str", typeof(tstr))]
    [System.Xml.Serialization.XmlElementAttribute("t-style", typeof(tstyle))]
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string @class
    {
      get { return this.classField; }
      set { this.classField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string set
    {
      get { return this.setField; }
      set { this.setField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string annotator
    {
      get { return this.annotatorField; }
      set { this.annotatorField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string annotatortype
    {
      get { return this.annotatortypeField; }
      set { this.annotatortypeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "IDREF")]
    public string processor
    {
      get { return this.processorField; }
      set { this.processorField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public double confidence
    {
      get { return this.confidenceField; }
      set { this.confidenceField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool confidenceSpecified
    {
      get { return this.confidenceFieldSpecified; }
      set { this.confidenceFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public System.DateTime datetime
    {
      get { return this.datetimeField; }
      set { this.datetimeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool datetimeSpecified
    {
      get { return this.datetimeFieldSpecified; }
      set { this.datetimeFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string metadata
    {
      get { return this.metadataField; }
      set { this.metadataField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified,
      Namespace = "http://www.w3.org/1999/xlink")]
    public string href
    {
      get { return this.hrefField; }
      set { this.hrefField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified,
      Namespace = "http://www.w3.org/1999/xlink")]
    public string type
    {
      get { return this.typeField; }
      set { this.typeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified,
      Namespace = "http://www.w3.org/1999/xlink")]
    public string role
    {
      get { return this.roleField; }
      set { this.roleField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified,
      Namespace = "http://www.w3.org/1999/xlink")]
    public string title
    {
      get { return this.titleField; }
      set { this.titleField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified,
      Namespace = "http://www.w3.org/1999/xlink")]
    public string label
    {
      get { return this.labelField; }
      set { this.labelField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified,
      Namespace = "http://www.w3.org/1999/xlink")]
    public string show
    {
      get { return this.showField; }
      set { this.showField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string auth
    {
      get { return this.authField; }
      set { this.authField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string offset
    {
      get { return this.offsetField; }
      set { this.offsetField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string @ref
    {
      get { return this.refField; }
      set { this.refField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAnyAttributeAttribute()]
    public System.Xml.XmlAttribute[] AnyAttr
    {
      get { return this.anyAttrField; }
      set { this.anyAttrField = value; }
    }
  }
}