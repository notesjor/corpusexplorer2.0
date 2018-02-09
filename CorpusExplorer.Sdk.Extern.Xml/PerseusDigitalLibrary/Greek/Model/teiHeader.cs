namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class teiHeader
  {

    private fileDesc fileDescField;

    private object[] itemsField;

    private revisionDesc revisionDescField;

    private string tEIformField;

    private string statusField;

    private string typeField;

    /// <remarks/>
    public fileDesc fileDesc
    {
      get { return this.fileDescField; }
      set { this.fileDescField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("encodingDesc", typeof(encodingDesc))]
    [System.Xml.Serialization.XmlElementAttribute("profileDesc", typeof(profileDesc))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    public revisionDesc revisionDesc
    {
      get { return this.revisionDescField; }
      set { this.revisionDescField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string TEIform
    {
      get { return this.tEIformField; }
      set { this.tEIformField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string status
    {
      get { return this.statusField; }
      set { this.statusField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string type
    {
      get { return this.typeField; }
      set { this.typeField = value; }
    }
  }
}