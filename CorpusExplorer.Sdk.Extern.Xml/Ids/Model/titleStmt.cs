namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class titleStmt
  {

    private object[] itemsField;

    private ItemsChoiceType[] itemsElementNameField; private string titleD;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("c.title", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("dokumentSigle", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("korpusSigle", typeof(string), DataType = "NCName")]
    [System.Xml.Serialization.XmlElementAttribute("t.title", typeof(ttitle))]
    [System.Xml.Serialization.XmlElementAttribute("textSigle", typeof(string))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("d.title", typeof(string))]
    public string TitleD
    {
      get { return this.titleD; }
      set { this.titleD = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemsChoiceType[] ItemsElementName
    {
      get { return this.itemsElementNameField; }
      set { this.itemsElementNameField = value; }
    }
  }
}