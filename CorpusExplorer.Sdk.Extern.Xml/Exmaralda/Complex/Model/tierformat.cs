namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Complex.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute("tier-format", Namespace = "", IsNullable = false)]
  public partial class tierformat
  {

    private property[] propertyField;

    private string tierrefField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("property")]
    public property[] property
    {
      get { return this.propertyField; }
      set { this.propertyField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string tierref
    {
      get { return this.tierrefField; }
      set { this.tierrefField = value; }
    }
  }
}