namespace CorpusExplorer.Sdk.Extern.Xml.Catma._6._0
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class fs
  {

    private f[] fField;

    private string typeField;

    private string idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("f")]
    public f[] f
    {
      get { return this.fField; }
      set { this.fField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type
    {
      get { return this.typeField; }
      set { this.typeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("xml:id")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }
  }
}