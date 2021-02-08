namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.TaggerFeature.Dependency
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

    private span spanField;

    private string labelField;

    /// <remarks/>
    public span span
    {
      get { return this.spanField; }
      set { this.spanField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string label
    {
      get { return this.labelField; }
      set { this.labelField = value; }
    }
  }
}