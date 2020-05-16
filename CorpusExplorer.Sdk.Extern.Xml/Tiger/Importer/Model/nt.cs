namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Importer.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
  public partial class nt {
    
    private edge[] edgeField;
    
    private secedge[] secedgeField;
    
    private string catField;
    
    private string idField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("edge")]
    public edge[] edge {
      get {
        return this.edgeField;
      }
      set {
        this.edgeField = value;
      }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("secedge")]
    public secedge[] secedge {
      get {
        return this.secedgeField;
      }
      set {
        this.secedgeField = value;
      }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="NCName")]
    public string cat {
      get {
        return this.catField;
      }
      set {
        this.catField = value;
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
  }
}