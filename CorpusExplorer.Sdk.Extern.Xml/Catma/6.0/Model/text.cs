namespace CorpusExplorer.Sdk.Extern.Xml.Catma._6._0.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class text
  {

    private body bodyField;

    private fs[] fsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElement]
    public body body
    {
      get { return this.bodyField; }
      set { this.bodyField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("fs")]
    public fs[] fs
    {
      get { return this.fsField; }
      set { this.fsField = value; }
    }
  }
}