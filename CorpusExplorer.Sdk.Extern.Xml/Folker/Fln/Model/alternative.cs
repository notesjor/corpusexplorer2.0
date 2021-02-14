namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Fln.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class alternative
  {

    private w[] wField;

    private string idField;

    private string olField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("w")]
    public w[] w
    {
      get { return this.wField; }
      set { this.wField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string ol
    {
      get { return this.olField; }
      set { this.olField = value; }
    }
  }
}