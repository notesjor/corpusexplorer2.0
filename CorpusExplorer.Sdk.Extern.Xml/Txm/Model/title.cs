namespace CorpusExplorer.Sdk.Extern.Xml.Txm.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute("titleStmt", Namespace = "http://www.tei-c.org/ns/1.0",
                                              IsNullable = false)]
  public partial class title
  {

    private string title1Field;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("title")]
    public string title1
    {
      get { return this.title1Field; }
      set { this.title1Field = value; }
    }
  }
}