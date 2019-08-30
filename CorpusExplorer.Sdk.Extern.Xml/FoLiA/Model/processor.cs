namespace CorpusExplorer.Sdk.Extern.Xml.FoLiA.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ilk.uvt.nl/folia")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://ilk.uvt.nl/folia", IsNullable = false)]
  public partial class processor
  {

    private object[] itemsField;

    private string idField;

    private string nameField;

    private string typeField;

    private string versionField;

    private string document_versionField;

    private string commandField;

    private string hostField;

    private string userField;

    private string folia_versionField;

    private string srcField;

    private string formatField;

    private System.DateTime begindatetimeField;

    private bool begindatetimeFieldSpecified;

    private System.DateTime enddatetimeField;

    private bool enddatetimeFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("meta", typeof(meta))]
    [System.Xml.Serialization.XmlElementAttribute("processor", typeof(processor))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified,
      Namespace = "http://www.w3.org/XML/1998/namespace", DataType = "ID")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
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
    public string type
    {
      get { return this.typeField; }
      set { this.typeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string version
    {
      get { return this.versionField; }
      set { this.versionField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string document_version
    {
      get { return this.document_versionField; }
      set { this.document_versionField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string command
    {
      get { return this.commandField; }
      set { this.commandField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string host
    {
      get { return this.hostField; }
      set { this.hostField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string user
    {
      get { return this.userField; }
      set { this.userField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string folia_version
    {
      get { return this.folia_versionField; }
      set { this.folia_versionField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string src
    {
      get { return this.srcField; }
      set { this.srcField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string format
    {
      get { return this.formatField; }
      set { this.formatField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public System.DateTime begindatetime
    {
      get { return this.begindatetimeField; }
      set { this.begindatetimeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool begindatetimeSpecified
    {
      get { return this.begindatetimeFieldSpecified; }
      set { this.begindatetimeFieldSpecified = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public System.DateTime enddatetime
    {
      get { return this.enddatetimeField; }
      set { this.enddatetimeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool enddatetimeSpecified
    {
      get { return this.enddatetimeFieldSpecified; }
      set { this.enddatetimeFieldSpecified = value; }
    }
  }
}