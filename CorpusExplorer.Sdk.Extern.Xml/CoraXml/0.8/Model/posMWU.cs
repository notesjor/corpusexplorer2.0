namespace CorpusExplorer.Sdk.Extern.Xml.CoraXml._0._8.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class posMWU
  {

    private string spanidField;

    private string tagField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("span-id", DataType = "integer")]
    public string spanid
    {
      get { return this.spanidField; }
      set { this.spanidField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string tag
    {
      get { return this.tagField; }
      set { this.tagField = value; }
    }
  }
}