namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class taxonomy
  {

    private string hbiblField;

    private category[] categoryField;

    private string idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("h.bibl")]
    public string hbibl
    {
      get { return this.hbiblField; }
      set { this.hbiblField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("category")]
    public category[] category
    {
      get { return this.categoryField; }
      set { this.categoryField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }
  }
}