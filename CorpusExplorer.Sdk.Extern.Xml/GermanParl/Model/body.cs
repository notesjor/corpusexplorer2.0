namespace CorpusExplorer.Sdk.Extern.Xml.GermanParl.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class body
  {

    private div[] divField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("div")]
    public div[] div
    {
      get { return this.divField; }
      set { this.divField = value; }
    }
  }
}