namespace CorpusExplorer.Sdk.Extern.Xml.Catma._6._0.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class f
  {

    private string stringField;

    private string nameField;

    /// <remarks/>
    public string @string
    {
      get { return this.stringField; }
      set { this.stringField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttribute]
    public string name
    {
      get { return this.nameField; }
      set { this.nameField = value; }
    }
  }
}