namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class div
  {

    private object[] itemsField;

    private string nField;

    private string orgField;

    private string partField;

    private string renditionField;

    private string sampleField;

    private string typeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("byline", typeof(byline))]
    [System.Xml.Serialization.XmlElementAttribute("cb", typeof(cb))]
    [System.Xml.Serialization.XmlElementAttribute("cit", typeof(cit))]
    [System.Xml.Serialization.XmlElementAttribute("closer", typeof(closer))]
    [System.Xml.Serialization.XmlElementAttribute("dateline", typeof(dateline))]
    [System.Xml.Serialization.XmlElementAttribute("div", typeof(div))]
    [System.Xml.Serialization.XmlElementAttribute("figure", typeof(figure))]
    [System.Xml.Serialization.XmlElementAttribute("floatingText", typeof(body))]
    [System.Xml.Serialization.XmlElementAttribute("head", typeof(head))]
    [System.Xml.Serialization.XmlElementAttribute("lb", typeof(lb))]
    [System.Xml.Serialization.XmlElementAttribute("lg", typeof(lg))]
    [System.Xml.Serialization.XmlElementAttribute("list", typeof(list))]
    [System.Xml.Serialization.XmlElementAttribute("milestone", typeof(milestone))]
    [System.Xml.Serialization.XmlElementAttribute("note", typeof(note))]
    [System.Xml.Serialization.XmlElementAttribute("opener", typeof(opener))]
    [System.Xml.Serialization.XmlElementAttribute("p", typeof(p))]
    [System.Xml.Serialization.XmlElementAttribute("postscript", typeof(postscript))]
    [System.Xml.Serialization.XmlElementAttribute("salute", typeof(salute))]
    [System.Xml.Serialization.XmlElementAttribute("space", typeof(space))]
    [System.Xml.Serialization.XmlElementAttribute("table", typeof(table))]
    [System.Xml.Serialization.XmlElementAttribute("trailer", typeof(trailer))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string rendition
    {
      get { return this.renditionField; }
      set { this.renditionField = value; }
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