namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.TaggerFeature.Morpho
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ids-mannheim.de/ns/KorAP")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://ids-mannheim.de/ns/KorAP", IsNullable = false)]
  public partial class layer
  {

    private span[] spanListField;

    private string vERSIONField;

    private string docidField;

    private string versionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("span", IsNullable = false)]
    public span[] spanList
    {
      get { return this.spanListField; }
      set { this.spanListField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string VERSION
    {
      get { return this.vERSIONField; }
      set { this.vERSIONField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string docid
    {
      get { return this.docidField; }
      set { this.docidField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string version
    {
      get { return this.versionField; }
      set { this.versionField = value; }
    }
  }
}