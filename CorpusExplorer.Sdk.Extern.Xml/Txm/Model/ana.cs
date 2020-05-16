namespace CorpusExplorer.Sdk.Extern.Xml.Txm.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://textometrie.org/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://textometrie.org/1.0", IsNullable = false)]
  public partial class ana
  {

    private string respField;

    private string typeField;

    private string textField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string resp
    {
      get { return this.respField; }
      set { this.respField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type
    {
      get { return this.typeField; }
      set { this.typeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Text
    {
      get { return this.textField; }
      set { this.textField = value; }
    }
  }
}