namespace CorpusExplorer.Sdk.Extern.Xml.Elan.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class PROPERTY
  {

    private string nAMEField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string NAME
    {
      get { return this.nAMEField; }
      set { this.nAMEField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute(DataType = "NMTOKEN")]
    public string Value
    {
      get { return this.valueField; }
      set { this.valueField = value; }
    }
  }
}