namespace CorpusExplorer.Sdk.Extern.Xml.Brown.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class s
  {

    private object[] itemsField;

    private string nField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("c", typeof(c))]
    [System.Xml.Serialization.XmlElementAttribute("mw", typeof(mw))]
    [System.Xml.Serialization.XmlElementAttribute("w", typeof(w))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
    public string n
    {
      get { return this.nField; }
      set { this.nField = value; }
    }
  }
}