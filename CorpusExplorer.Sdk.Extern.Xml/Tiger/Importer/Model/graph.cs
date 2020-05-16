namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Importer.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
  public partial class graph {
    
    private terminals terminalsField;
    
    private nt[] nonterminalsField;
    
    private string rootField;
    
    /// <remarks/>
    public terminals terminals {
      get {
        return this.terminalsField;
      }
      set {
        this.terminalsField = value;
      }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("nt", IsNullable=false)]
    public nt[] nonterminals {
      get {
        return this.nonterminalsField;
      }
      set {
        this.nonterminalsField = value;
      }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NCName")]
    public string root {
      get {
        return this.rootField;
      }
      set {
        this.rootField = value;
      }
    }
  }
}