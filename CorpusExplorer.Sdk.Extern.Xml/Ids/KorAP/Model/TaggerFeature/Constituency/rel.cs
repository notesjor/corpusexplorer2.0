namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.TaggerFeature.Constituency
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ids-mannheim.de/ns/KorAP")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://ids-mannheim.de/ns/KorAP", IsNullable = false)]
  public partial class rel
  {

    private string labelField;

    private string targetField;

    private string uriField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string label
    {
      get { return this.labelField; }
      set { this.labelField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string target
    {
      get { return this.targetField; }
      set { this.targetField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string uri
    {
      get { return this.uriField; }
      set { this.uriField = value; }
    }
  }
}