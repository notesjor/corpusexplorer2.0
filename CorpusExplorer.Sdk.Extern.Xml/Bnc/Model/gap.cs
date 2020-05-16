namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class gap
  {

    private string descField;

    private string reasonField;

    private string respField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string desc
    {
      get { return this.descField; }
      set { this.descField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string reason
    {
      get { return this.reasonField; }
      set { this.reasonField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string resp
    {
      get { return this.respField; }
      set { this.respField = value; }
    }
  }
}