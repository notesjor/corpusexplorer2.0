namespace CorpusExplorer.Sdk.Extern.Xml.Txm.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://textometrie.org/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://textometrie.org/1.0", IsNullable = false)]
  public partial class osSeparator
  {

    private string fileField;

    private string lineField;

    private string pathField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string file
    {
      get { return this.fileField; }
      set { this.fileField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string line
    {
      get { return this.lineField; }
      set { this.lineField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string path
    {
      get { return this.pathField; }
      set { this.pathField = value; }
    }
  }
}