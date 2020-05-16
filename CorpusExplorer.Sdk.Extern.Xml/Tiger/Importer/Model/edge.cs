namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Importer.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
  public partial class edge {
    
    private string idrefField;
    
    private string labelField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NCName")]
    public string idref {
      get {
        return this.idrefField;
      }
      set {
        this.idrefField = value;
      }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NCName")]
    public string label {
      get {
        return this.labelField;
      }
      set {
        this.labelField = value;
      }
    }
  }
}