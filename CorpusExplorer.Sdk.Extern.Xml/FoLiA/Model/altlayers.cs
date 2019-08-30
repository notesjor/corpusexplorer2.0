namespace CorpusExplorer.Sdk.Extern.Xml.FoLiA.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ilk.uvt.nl/folia")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://ilk.uvt.nl/folia", IsNullable = false)]
  public partial class altlayers
  {

    private object[] itemsField;

    private string idField;

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

    private string authField;

    private string exclusiveField;

    private System.Xml.XmlAttribute[] anyAttrField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("chunking", typeof(chunking))]
    [System.Xml.Serialization.XmlElementAttribute("comment", typeof(comment))]
    [System.Xml.Serialization.XmlElementAttribute("complexalignments", typeof(complexalignments))]
    [System.Xml.Serialization.XmlElementAttribute("coreferences", typeof(coreferences))]
    [System.Xml.Serialization.XmlElementAttribute("dependencies", typeof(dependencies))]
    [System.Xml.Serialization.XmlElementAttribute("desc", typeof(desc))]
    [System.Xml.Serialization.XmlElementAttribute("entities", typeof(entities))]
    [System.Xml.Serialization.XmlElementAttribute("foreign-data", typeof(System.Xml.XmlNode))]
    [System.Xml.Serialization.XmlElementAttribute("morphology", typeof(morphology))]
    [System.Xml.Serialization.XmlElementAttribute("observations", typeof(observations))]
    [System.Xml.Serialization.XmlElementAttribute("phonology", typeof(phonology))]
    [System.Xml.Serialization.XmlElementAttribute("semroles", typeof(semroles))]
    [System.Xml.Serialization.XmlElementAttribute("sentiments", typeof(sentiments))]
    [System.Xml.Serialization.XmlElementAttribute("spanrelations", typeof(spanrelations))]
    [System.Xml.Serialization.XmlElementAttribute("statements", typeof(statements))]
    [System.Xml.Serialization.XmlElementAttribute("syntax", typeof(syntax))]
    [System.Xml.Serialization.XmlElementAttribute("timing", typeof(timing))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string auth
    {
      get { return this.authField; }
      set { this.authField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string exclusive
    {
      get { return this.exclusiveField; }
      set { this.exclusiveField = value; }
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