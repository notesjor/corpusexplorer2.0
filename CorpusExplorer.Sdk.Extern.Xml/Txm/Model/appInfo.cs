namespace CorpusExplorer.Sdk.Extern.Xml.Txm.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class appInfo
  {

    private application applicationField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://textometrie.org/1.0")]
    public application application
    {
      get { return this.applicationField; }
      set { this.applicationField = value; }
    }
  }
}