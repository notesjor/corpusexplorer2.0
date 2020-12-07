namespace CorpusExplorer.Sdk.Extern.Xml.Catma._6._0
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class vColl
  {

    private string[] stringField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("string")]
    public string[] @string
    {
      get { return this.stringField; }
      set { this.stringField = value; }
    }
  }
}