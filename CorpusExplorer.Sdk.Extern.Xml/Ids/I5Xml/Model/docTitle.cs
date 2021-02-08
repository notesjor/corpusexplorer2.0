namespace CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class docTitle
  {

    private titlePart[] titlePartField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("titlePart")]
    public titlePart[] titlePart
    {
      get { return this.titlePartField; }
      set { this.titlePartField = value; }
    }
  }
}