namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Fln.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class speaker
  {

    private string nameField;

    private string dgdidField;

    private string speakeridField;

    /// <remarks/>
    public string name
    {
      get { return this.nameField; }
      set { this.nameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("dgd-id")]
    public string dgdid
    {
      get { return this.dgdidField; }
      set { this.dgdidField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("speaker-id", DataType = "NCName")]
    public string speakerid
    {
      get { return this.speakeridField; }
      set { this.speakeridField = value; }
    }
  }
}