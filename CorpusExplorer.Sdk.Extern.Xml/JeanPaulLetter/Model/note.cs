namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class note
  {

    private object[] itemsField;

    private string[] textField;

    private bool anchoredField;

    private bool anchoredFieldSpecified;

    private string correspField;

    private string nField;

    private string placeField;

    private string typeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("choice", typeof(choice))]
    [System.Xml.Serialization.XmlElementAttribute("date", typeof(date))]
    [System.Xml.Serialization.XmlElementAttribute("hi", typeof(hi))]
    [System.Xml.Serialization.XmlElementAttribute("lb", typeof(lb))]
    [System.Xml.Serialization.XmlElementAttribute("listBibl", typeof(listBibl))]
    [System.Xml.Serialization.XmlElementAttribute("listPerson", typeof(listPerson))]
    [System.Xml.Serialization.XmlElementAttribute("listPlace", typeof(listPlace))]
    [System.Xml.Serialization.XmlElementAttribute("metamark", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("note", typeof(note))]
    [System.Xml.Serialization.XmlElementAttribute("ref", typeof(@ref))]
    [System.Xml.Serialization.XmlElementAttribute("space", typeof(space))]
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
    public bool anchored
    {
      get { return this.anchoredField; }
      set { this.anchoredField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool anchoredSpecified
    {
      get { return this.anchoredFieldSpecified; }
      set { this.anchoredFieldSpecified = value; }
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
    public string n
    {
      get { return this.nField; }
      set { this.nField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string place
    {
      get { return this.placeField; }
      set { this.placeField = value; }
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