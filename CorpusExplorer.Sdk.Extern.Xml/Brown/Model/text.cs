namespace CorpusExplorer.Sdk.Extern.Xml.Brown.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class text
  {

    private p[] bodyField;

    private string declsField;

    private string idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("p", IsNullable = false)]
    public p[] body
    {
      get { return this.bodyField; }
      set { this.bodyField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string decls
    {
      get { return this.declsField; }
      set { this.declsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified,
      Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }
  }
}