namespace CorpusExplorer.Sdk.Extern.Xml.Catma._6._0.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class fsdDecl
  {

    private fsDecl[] fsDeclField;

    private string nField;

    private string idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("fsDecl")]
    public fsDecl[] fsDecl
    {
      get { return this.fsDeclField; }
      set { this.fsDeclField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string n
    {
      get { return this.nField; }
      set { this.nField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttribute("xml:id")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }
  }
}