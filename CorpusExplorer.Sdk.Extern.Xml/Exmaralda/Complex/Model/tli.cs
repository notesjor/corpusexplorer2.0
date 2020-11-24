namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Complex.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class tli
  {

    private string bookmarkField;

    private string idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string bookmark
    {
      get { return this.bookmarkField; }
      set { this.bookmarkField = value; }
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