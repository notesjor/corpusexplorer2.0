namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Importer.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
  public partial class s {
    
    private graph graphField;
    
    private string art_idField;
    
    private string idField;
    
    private string orig_idField;
    
    /// <remarks/>
    public graph graph {
      get {
        return this.graphField;
      }
      set {
        this.graphField = value;
      }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="integer")]
    public string art_id {
      get {
        return this.art_idField;
      }
      set {
        this.art_idField = value;
      }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NCName")]
    public string id {
      get {
        return this.idField;
      }
      set {
        this.idField = value;
      }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NCName")]
    public string orig_id {
      get {
        return this.orig_idField;
      }
      set {
        this.orig_idField = value;
      }
    }
  }
}