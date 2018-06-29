namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class address
  {

    private addrLine addrLineField;

    private note noteField;

    private object itemField;

    /// <remarks/>
    public addrLine addrLine
    {
      get { return this.addrLineField; }
      set { this.addrLineField = value; }
    }

    /// <remarks/>
    public note note
    {
      get { return this.noteField; }
      set { this.noteField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("country", typeof(string), DataType = "NCName")]
    [System.Xml.Serialization.XmlElementAttribute("lb", typeof(lb))]
    public object Item
    {
      get { return this.itemField; }
      set { this.itemField = value; }
    }
  }
}