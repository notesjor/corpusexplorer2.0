namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Model
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

    private catRef[] catRefField;

    private hkeywords hkeywordsField;

    private string defaultField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("catRef")]
    public catRef[] catRef
    {
      get { return this.catRefField; }
      set { this.catRefField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("h.keywords")]
    public hkeywords hkeywords
    {
      get { return this.hkeywordsField; }
      set { this.hkeywordsField = value; }
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