namespace CorpusExplorer.Sdk.Extern.Xml.Txm.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class w
  {

    private string formField;

    private ana[] anaField;

    private string idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://textometrie.org/1.0")]
    public string form
    {
      get { return this.formField; }
      set { this.formField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ana", Namespace = "http://textometrie.org/1.0")]
    public ana[] ana
    {
      get { return this.anaField; }
      set { this.anaField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }
  }
}