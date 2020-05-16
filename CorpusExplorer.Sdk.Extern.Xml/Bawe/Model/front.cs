namespace CorpusExplorer.Sdk.Extern.Xml.Bawe.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class front
  {

    private figure figureField;

    private object[] itemsField;

    private string tEIformField;

    /// <remarks/>
    public figure figure
    {
      get { return this.figureField; }
      set { this.figureField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("div1", typeof(div1))]
    [System.Xml.Serialization.XmlElementAttribute("titlePage", typeof(titlePage))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string TEIform
    {
      get { return this.tEIformField; }
      set { this.tEIformField = value; }
    }
  }
}