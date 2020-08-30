namespace CorpusExplorer.Sdk.Extern.Xml.GermanParl.Model
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

    private string speakerField;

    private object[] itemsField;

    private string nameField;

    private string parliamentary_groupField;

    private string partyField;

    private string positionField;

    private string roleField;

    private string whoField;

    /// <remarks/>
    public string speaker
    {
      get { return this.speakerField; }
      set { this.speakerField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("p", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("stage", typeof(stage))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
    {
      get { return this.nameField; }
      set { this.nameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string parliamentary_group
    {
      get { return this.parliamentary_groupField; }
      set { this.parliamentary_groupField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string party
    {
      get { return this.partyField; }
      set { this.partyField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string position
    {
      get { return this.positionField; }
      set { this.positionField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string role
    {
      get { return this.roleField; }
      set { this.roleField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string who
    {
      get { return this.whoField; }
      set { this.whoField = value; }
    }
  }
}