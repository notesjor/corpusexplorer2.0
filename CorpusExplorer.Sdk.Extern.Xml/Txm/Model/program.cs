namespace CorpusExplorer.Sdk.Extern.Xml.Txm.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://textometrie.org/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://textometrie.org/1.0", IsNullable = false)]
  public partial class program
  {

    private string descField;

    private string nameField;

    private string pathField;

    private decimal versionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string desc
    {
      get { return this.descField; }
      set { this.descField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string name
    {
      get { return this.nameField; }
      set { this.nameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string path
    {
      get { return this.pathField; }
      set { this.pathField = value; }
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