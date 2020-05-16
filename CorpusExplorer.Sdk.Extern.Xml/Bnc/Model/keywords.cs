namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class keywords
  {

    private string[] termField;

    private string schemeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("term")]
    public string[] term
    {
      get { return this.termField; }
      set { this.termField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string scheme
    {
      get { return this.schemeField; }
      set { this.schemeField = value; }
    }
  }
}