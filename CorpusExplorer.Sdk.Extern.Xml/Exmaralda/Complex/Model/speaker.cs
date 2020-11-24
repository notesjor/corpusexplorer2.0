namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Complex.Model
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

    private string abbreviationField;

    private sex sexField;

    private language[] languagesusedField;

    private l1 l1Field;

    private l2 l2Field;

    private udinformation[] udspeakerinformationField;

    private string commentField;

    private string idField;

    /// <remarks/>
    public string abbreviation
    {
      get { return this.abbreviationField; }
      set { this.abbreviationField = value; }
    }

    /// <remarks/>
    public sex sex
    {
      get { return this.sexField; }
      set { this.sexField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute("languages-used")]
    [System.Xml.Serialization.XmlArrayItemAttribute("language", IsNullable = false)]
    public language[] languagesused
    {
      get { return this.languagesusedField; }
      set { this.languagesusedField = value; }
    }

    /// <remarks/>
    public l1 l1
    {
      get { return this.l1Field; }
      set { this.l1Field = value; }
    }

    /// <remarks/>
    public l2 l2
    {
      get { return this.l2Field; }
      set { this.l2Field = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute("ud-speaker-information")]
    [System.Xml.Serialization.XmlArrayItemAttribute("ud-information", IsNullable = false)]
    public udinformation[] udspeakerinformation
    {
      get { return this.udspeakerinformationField; }
      set { this.udspeakerinformationField = value; }
    }

    /// <remarks/>
    public string comment
    {
      get { return this.commentField; }
      set { this.commentField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }
  }
}