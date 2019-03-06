namespace CorpusExplorer.Sdk.Extern.Xml.CoraXml._0._8.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class token
  {

    private dipl[] diplField;

    private anno[] annoField;

    private string idField;

    private string transField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("dipl")]
    public dipl[] dipl
    {
      get { return this.diplField; }
      set { this.diplField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("anno")]
    public anno[] anno
    {
      get { return this.annoField; }
      set { this.annoField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string trans
    {
      get { return this.transField; }
      set { this.transField = value; }
    }
  }
}