namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class titleStmt
  {

    private title[] titleField;

    private object[] itemsField;

    private string tEIformField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("title")]
    public title[] title
    {
      get { return this.titleField; }
      set { this.titleField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("author", typeof(author))]
    [System.Xml.Serialization.XmlElementAttribute("editor", typeof(editor))]
    [System.Xml.Serialization.XmlElementAttribute("funder", typeof(funder))]
    [System.Xml.Serialization.XmlElementAttribute("principal", typeof(principal))]
    [System.Xml.Serialization.XmlElementAttribute("respStmt", typeof(respStmt))]
    [System.Xml.Serialization.XmlElementAttribute("sponsor", typeof(sponsor))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string TEIform
    {
      get { return this.tEIformField; }
      set { this.tEIformField = value; }
    }
  }
}