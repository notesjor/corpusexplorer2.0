namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class bibl
  {

    private string authorField;

    private title titleField;

    private biblScope[] biblScopeField;

    private string anaField;

    private string correspField;

    private bool defaultField;

    private bool defaultFieldSpecified;

    private string nextField;

    private string rendField;

    private string statusField;

    /// <remarks/>
    public string author
    {
      get { return this.authorField; }
      set { this.authorField = value; }
    }

    /// <remarks/>
    public title title
    {
      get { return this.titleField; }
      set { this.titleField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("biblScope")]
    public biblScope[] biblScope
    {
      get { return this.biblScopeField; }
      set { this.biblScopeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ana
    {
      get { return this.anaField; }
      set { this.anaField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string corresp
    {
      get { return this.correspField; }
      set { this.correspField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool @default
    {
      get { return this.defaultField; }
      set { this.defaultField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool defaultSpecified
    {
      get { return this.defaultFieldSpecified; }
      set { this.defaultFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string next
    {
      get { return this.nextField; }
      set { this.nextField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string rend
    {
      get { return this.rendField; }
      set { this.rendField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string status
    {
      get { return this.statusField; }
      set { this.statusField = value; }
    }
  }
}