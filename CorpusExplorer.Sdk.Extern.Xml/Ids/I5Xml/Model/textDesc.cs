namespace CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class textDesc
  {

    private string textTypeField;

    private string textTypeRefField;

    private string textTypeArtField;

    private string textDomainField;

    private string columnField;

    private string defaultField;

    /// <remarks/>
    public string textType
    {
      get { return this.textTypeField; }
      set { this.textTypeField = value; }
    }

    /// <remarks/>
    public string textTypeRef
    {
      get { return this.textTypeRefField; }
      set { this.textTypeRefField = value; }
    }

    /// <remarks/>
    public string textTypeArt
    {
      get { return this.textTypeArtField; }
      set { this.textTypeArtField = value; }
    }

    /// <remarks/>
    public string textDomain
    {
      get { return this.textDomainField; }
      set { this.textDomainField = value; }
    }

    /// <remarks/>
    public string column
    {
      get { return this.columnField; }
      set { this.columnField = value; }
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