namespace CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class front
  {

    private titlePage titlePageField;

    private div[] divField;

    /// <remarks/>
    public titlePage titlePage
    {
      get { return this.titlePageField; }
      set { this.titlePageField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("div")]
    public div[] div
    {
      get { return this.divField; }
      set { this.divField = value; }
    }
  }
}