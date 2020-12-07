namespace CorpusExplorer.Sdk.Extern.Xml.Catma._6._0
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class fDecl
  {

    private vRange vRangeField;

    private string nameField;

    private string idField;

    /// <remarks/>
    public vRange vRange
    {
      get { return this.vRangeField; }
      set { this.vRangeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttribute]
    public string name
    {
      get { return this.nameField; }
      set { this.nameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttribute]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }
  }
}