namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class correspAction
  {

    private persName[] persNameField;

    private date[] dateField;

    private object[] itemsField;

    private string typeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("persName")]
    public persName[] persName
    {
      get { return this.persNameField; }
      set { this.persNameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("date")]
    public date[] date
    {
      get { return this.dateField; }
      set { this.dateField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("note", typeof(note))]
    [System.Xml.Serialization.XmlElementAttribute("placeName", typeof(placeName))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
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