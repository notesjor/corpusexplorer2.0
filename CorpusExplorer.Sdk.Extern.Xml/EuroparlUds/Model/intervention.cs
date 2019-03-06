namespace CorpusExplorer.Sdk.Extern.Xml.EuroparlUds.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class intervention
  {

    private object[] itemsField;

    private System.DateTime birth_dateField;

    private bool birth_dateFieldSpecified;

    private string birth_placeField;

    private string idField;

    private string is_mepField;

    private string m_stateField;

    private string modeField;

    private string n_partyField;

    private string nameField;

    private string nationalityField;

    private string p_groupField;

    private string roleField;

    private string speaker_idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("a", typeof(a))]
    [System.Xml.Serialization.XmlElementAttribute("p", typeof(p))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    public System.DateTime birth_date
    {
      get { return this.birth_dateField; }
      set { this.birth_dateField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool birth_dateSpecified
    {
      get { return this.birth_dateFieldSpecified; }
      set { this.birth_dateFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string birth_place
    {
      get { return this.birth_placeField; }
      set { this.birth_placeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string is_mep
    {
      get { return this.is_mepField; }
      set { this.is_mepField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string m_state
    {
      get { return this.m_stateField; }
      set { this.m_stateField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string mode
    {
      get { return this.modeField; }
      set { this.modeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string n_party
    {
      get { return this.n_partyField; }
      set { this.n_partyField = value; }
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
    public string nationality
    {
      get { return this.nationalityField; }
      set { this.nationalityField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string p_group
    {
      get { return this.p_groupField; }
      set { this.p_groupField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string role
    {
      get { return this.roleField; }
      set { this.roleField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string speaker_id
    {
      get { return this.speaker_idField; }
      set { this.speaker_idField = value; }
    }
  }
}