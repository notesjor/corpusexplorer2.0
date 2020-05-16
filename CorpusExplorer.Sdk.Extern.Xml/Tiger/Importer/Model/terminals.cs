namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Importer.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
  public partial class terminals {
    
    private t[] tField;
    
    private string[] textField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("t")]
    public t[] t {
      get {
        return this.tField;
      }
      set {
        this.tField = value;
      }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text {
      get {
        return this.textField;
      }
      set {
        this.textField = value;
      }
    }
  }
}