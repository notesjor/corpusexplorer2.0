namespace CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class classCode
  {

    private @ref[] refField;

    private string schemeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ref")]
    public @ref[] @ref
    {
      get { return this.refField; }
      set { this.refField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
    public string scheme
    {
      get { return this.schemeField; }
      set { this.schemeField = value; }
    }
  }
}