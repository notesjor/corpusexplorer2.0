namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Fln.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class contribution
  {

    private object[] itemsField;

    private string endreferenceField;

    private string idField;

    private string parselevelField;

    private string speakerdgdidField;

    private string speakerreferenceField;

    private string startreferenceField;

    private decimal timeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("breathe", typeof(breathe))]
    [System.Xml.Serialization.XmlElementAttribute("non-phonological", typeof(nonphonological))]
    [System.Xml.Serialization.XmlElementAttribute("pause", typeof(pause))]
    [System.Xml.Serialization.XmlElementAttribute("time", typeof(time))]
    [System.Xml.Serialization.XmlElementAttribute("uncertain", typeof(uncertain))]
    [System.Xml.Serialization.XmlElementAttribute("w", typeof(w))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("end-reference", DataType = "NCName")]
    public string endreference
    {
      get { return this.endreferenceField; }
      set { this.endreferenceField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("parse-level", DataType = "integer")]
    public string parselevel
    {
      get { return this.parselevelField; }
      set { this.parselevelField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("speaker-dgd-id")]
    public string speakerdgdid
    {
      get { return this.speakerdgdidField; }
      set { this.speakerdgdidField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("speaker-reference", DataType = "NCName")]
    public string speakerreference
    {
      get { return this.speakerreferenceField; }
      set { this.speakerreferenceField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("start-reference", DataType = "NCName")]
    public string startreference
    {
      get { return this.startreferenceField; }
      set { this.startreferenceField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal time
    {
      get { return this.timeField; }
      set { this.timeField = value; }
    }
  }
}