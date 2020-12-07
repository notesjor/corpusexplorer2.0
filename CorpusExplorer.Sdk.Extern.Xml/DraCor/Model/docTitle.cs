namespace CorpusExplorer.Sdk.Extern.Xml.DraCor.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class docTitle
  {

    private titlePart[] titlePartField;

    private pb pbField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("titlePart")]
    public titlePart[] titlePart
    {
      get { return this.titlePartField; }
      set { this.titlePartField = value; }
    }

    /// <remarks/>
    public pb pb
    {
      get { return this.pbField; }
      set { this.pbField = value; }
    }
  }
}