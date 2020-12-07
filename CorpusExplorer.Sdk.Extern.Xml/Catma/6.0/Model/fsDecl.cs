namespace CorpusExplorer.Sdk.Extern.Xml.Catma._6._0
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class fsDecl
  {

    private string fsDescrField;

    private fDecl[] fDeclField;

    private string baseTypesField;

    private string nField;

    private string typeField;

    private string idField;

    /// <remarks/>
    public string fsDescr
    {
      get { return this.fsDescrField; }
      set { this.fsDescrField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("fDecl")]
    public fDecl[] fDecl
    {
      get { return this.fDeclField; }
      set { this.fDeclField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string baseTypes
    {
      get { return this.baseTypesField; }
      set { this.baseTypesField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string n
    {
      get { return this.nField; }
      set { this.nField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type
    {
      get { return this.typeField; }
      set { this.typeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttribute]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }
  }
}