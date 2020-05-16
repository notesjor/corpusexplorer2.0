namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Importer.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
  public partial class nonterminals {
    
    private nt[] ntField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("nt")]
    public nt[] nt {
      get {
        return this.ntField;
      }
      set {
        this.ntField = value;
      }
    }
  }
}