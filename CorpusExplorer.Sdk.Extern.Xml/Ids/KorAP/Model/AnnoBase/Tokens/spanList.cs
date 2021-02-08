namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.AnnoBase.Tokens
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ids-mannheim.de/ns/KorAP")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://ids-mannheim.de/ns/KorAP", IsNullable = false)]
  public partial class spanList
  {

    private span[] spanField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("span")]
    public span[] span
    {
      get { return this.spanField; }
      set { this.spanField = value; }
    }
  }
}