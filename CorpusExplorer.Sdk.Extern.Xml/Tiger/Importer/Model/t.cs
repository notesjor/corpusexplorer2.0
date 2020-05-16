namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Importer.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
  public partial class t {
    
    private secedge[] secedgeField;
    
    private string commentField;
    
    private string idField;
    
    private string lemmaField;
    
    private string morphField;
    
    private string posField;
    
    private string wordField;
    
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string comment {
      get {
        return this.commentField;
      }
      set {
        this.commentField = value;
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string lemma {
      get {
        return this.lemmaField;
      }
      set {
        this.lemmaField = value;
      }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string morph {
      get {
        return this.morphField;
      }
      set {
        this.morphField = value;
      }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string pos {
      get {
        return this.posField;
      }
      set {
        this.posField = value;
      }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string word {
      get {
        return this.wordField;
      }
      set {
        this.wordField = value;
      }
    }
  }
}