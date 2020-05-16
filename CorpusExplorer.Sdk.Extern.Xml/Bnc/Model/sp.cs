namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class sp
  {

    private speaker speakerField;

    private l[] lField;

    private object[] itemsField;

    private string whoField;

    /// <remarks/>
    public speaker speaker
    {
      get { return this.speakerField; }
      set { this.speakerField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("l")]
    public l[] l
    {
      get { return this.lField; }
      set { this.lField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("p", typeof(p))]
    [System.Xml.Serialization.XmlElementAttribute("stage", typeof(stage))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string who
    {
      get { return this.whoField; }
      set { this.whoField = value; }
    }
  }
}