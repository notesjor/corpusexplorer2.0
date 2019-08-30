namespace CorpusExplorer.Sdk.Extern.Xml.FoLiA.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ilk.uvt.nl/folia")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://ilk.uvt.nl/folia", IsNullable = false)]
  public partial class submetadata
  {

    private meta[] metaField;

    private System.Xml.XmlNode[] foreigndataField;

    private string idField;

    private string typeField;

    private string srcField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("meta")]
    public meta[] meta
    {
      get { return this.metaField; }
      set { this.metaField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("foreign-data")]
    public System.Xml.XmlNode[] foreigndata
    {
      get { return this.foreigndataField; }
      set { this.foreigndataField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified,
      Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type
    {
      get { return this.typeField; }
      set { this.typeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string src
    {
      get { return this.srcField; }
      set { this.srcField = value; }
    }
  }
}