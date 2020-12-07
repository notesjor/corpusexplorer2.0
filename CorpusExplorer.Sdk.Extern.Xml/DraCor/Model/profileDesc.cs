namespace CorpusExplorer.Sdk.Extern.Xml.DraCor.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class profileDesc
  {

    private particDesc particDescField;

    private textClass textClassField;

    /// <remarks/>
    public particDesc particDesc
    {
      get { return this.particDescField; }
      set { this.particDescField = value; }
    }

    /// <remarks/>
    public textClass textClass
    {
      get { return this.textClassField; }
      set { this.textClassField = value; }
    }
  }
}