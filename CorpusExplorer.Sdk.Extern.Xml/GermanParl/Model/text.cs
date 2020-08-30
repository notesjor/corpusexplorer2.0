namespace CorpusExplorer.Sdk.Extern.Xml.GermanParl.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class text
  {

    private div[] bodyField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("div", IsNullable = false)]
    public div[] body
    {
      get { return this.bodyField; }
      set { this.bodyField = value; }
    }
  }
}