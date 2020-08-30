namespace CorpusExplorer.Sdk.Extern.Xml.GermanParl.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class edition
  {

    private string packageField;

    private string versionField;

    private System.DateTime birthdayField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "NCName")]
    public string package
    {
      get { return this.packageField; }
      set { this.packageField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "NMTOKEN")]
    public string version
    {
      get { return this.versionField; }
      set { this.versionField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
    public System.DateTime birthday
    {
      get { return this.birthdayField; }
      set { this.birthdayField = value; }
    }
  }
}