namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class closer
  {

    private object[] itemsField;

    private object itemField;

    private string renditionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("cb", typeof(cb))]
    [System.Xml.Serialization.XmlElementAttribute("dateline", typeof(dateline))]
    [System.Xml.Serialization.XmlElementAttribute("lb", typeof(lb))]
    [System.Xml.Serialization.XmlElementAttribute("note", typeof(note))]
    [System.Xml.Serialization.XmlElementAttribute("salute", typeof(salute))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("address", typeof(address))]
    [System.Xml.Serialization.XmlElementAttribute("hi", typeof(hi))]
    public object Item
    {
      get { return this.itemField; }
      set { this.itemField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string rendition
    {
      get { return this.renditionField; }
      set { this.renditionField = value; }
    }
  }
}