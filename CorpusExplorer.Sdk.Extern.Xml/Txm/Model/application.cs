namespace CorpusExplorer.Sdk.Extern.Xml.Txm.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://textometrie.org/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://textometrie.org/1.0", IsNullable = false)]
  public partial class application
  {

    private commandLine commandLineField;

    private ab abField;

    private string identField;

    private string respField;

    private decimal versionField;

    /// <remarks/>
    public commandLine commandLine
    {
      get { return this.commandLineField; }
      set { this.commandLineField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.tei-c.org/ns/1.0")]
    public ab ab
    {
      get { return this.abField; }
      set { this.abField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string ident
    {
      get { return this.identField; }
      set { this.identField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string resp
    {
      get { return this.respField; }
      set { this.respField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal version
    {
      get { return this.versionField; }
      set { this.versionField = value; }
    }
  }
}