namespace CorpusExplorer.Sdk.Extern.Xml.DigitalPlato.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class hi
  {

    private object[] itemsField;

    private string[] textField;

    private string rendField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("hi", typeof(hi))]
    [System.Xml.Serialization.XmlElementAttribute("note", typeof(note))]
    [System.Xml.Serialization.XmlElementAttribute("title", typeof(string))]
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
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
    public string rend
    {
      get { return this.rendField; }
      set { this.rendField = value; }
    }
  }
}