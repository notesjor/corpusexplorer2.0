namespace CorpusExplorer.Sdk.Extern.Xml.CoraXml._0._8.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute("cora-header", Namespace = "", IsNullable = false)]
  public partial class coraheader
  {

    private string nameField;

    private string sigleField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
    {
      get { return this.nameField; }
      set { this.nameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
    public string sigle
    {
      get { return this.sigleField; }
      set { this.sigleField = value; }
    }
  }
}