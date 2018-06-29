namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class person
  {

    private persName persNameField;

    private string anaField;

    private string correspField;

    private bool instantField;

    private bool instantFieldSpecified;

    private string nextField;

    private string rendField;

    /// <remarks/>
    public persName persName
    {
      get { return this.persNameField; }
      set { this.persNameField = value; }
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
  }
}