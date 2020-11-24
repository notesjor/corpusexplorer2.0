namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Complex.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute("common-timeline", Namespace = "", IsNullable = false)]
  public partial class commontimeline
  {

    private tli[] tliField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("tli")]
    public tli[] tli
    {
      get { return this.tliField; }
      set { this.tliField = value; }
    }
  }
}