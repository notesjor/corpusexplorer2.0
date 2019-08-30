namespace CorpusExplorer.Sdk.Extern.Xml.FoLiA.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ilk.uvt.nl/folia")]
  [System.Xml.Serialization.XmlRootAttribute("t-gap", Namespace = "http://ilk.uvt.nl/folia", IsNullable = false)]
  public partial class tgap
  {

    private object[] itemsField;

    private string[] textField;

    private string idField;

    private string classField;

    private string setField;

    private string annotatorField;

    private string annotatortypeField;

    private string processorField;

    private double confidenceField;

    private bool confidenceFieldSpecified;

    private string nField;

    private System.DateTime datetimeField;

    private bool datetimeFieldSpecified;

    private string begintimeField;

    private string endtimeField;

    private string srcField;

    private string speakerField;

    private string metadataField;

    private string hrefField;

    private string typeField;

    private string roleField;

    private string titleField;

    private string labelField;

    private string showField;

    private string authField;

    private string id1Field;

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
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified,
      Namespace = "http://www.w3.org/XML/1998/namespace", DataType = "ID")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
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
    public string n
    {
      get { return this.nField; }
      set { this.nField = value; }
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
    public string begintime
    {
      get { return this.begintimeField; }
      set { this.begintimeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string endtime
    {
      get { return this.endtimeField; }
      set { this.endtimeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
    public string src
    {
      get { return this.srcField; }
      set { this.srcField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string speaker
    {
      get { return this.speakerField; }
      set { this.speakerField = value; }
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
    [System.Xml.Serialization.XmlAttributeAttribute("id")]
    public string id1
    {
      get { return this.id1Field; }
      set { this.id1Field = value; }
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