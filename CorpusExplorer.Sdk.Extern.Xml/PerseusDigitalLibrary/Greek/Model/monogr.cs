namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class monogr
  {

    private object[] itemsField;

    private object itemField;

    private imprint imprintField;

    private biblScope biblScopeField;

    private string tEIformField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("author", typeof(author))]
    [System.Xml.Serialization.XmlElementAttribute("title", typeof(title))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("editor", typeof(editor))]
    [System.Xml.Serialization.XmlElementAttribute("respStmt", typeof(respStmt))]
    public object Item
    {
      get { return this.itemField; }
      set { this.itemField = value; }
    }

    /// <remarks/>
    public imprint imprint
    {
      get { return this.imprintField; }
      set { this.imprintField = value; }
    }

    /// <remarks/>
    public biblScope biblScope
    {
      get { return this.biblScopeField; }
      set { this.biblScopeField = value; }
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