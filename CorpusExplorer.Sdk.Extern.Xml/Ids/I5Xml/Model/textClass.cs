namespace CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class textClass
  {

    private classCode classCodeField;

    private object[] itemsField;

    private string defaultField;

    /// <remarks/>
    public classCode classCode
    {
      get { return this.classCodeField; }
      set { this.classCodeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("catRef", typeof(catRef))]
    [System.Xml.Serialization.XmlElementAttribute("h.keywords", typeof(hkeywords))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string Default
    {
      get { return this.defaultField; }
      set { this.defaultField = value; }
    }
  }
}