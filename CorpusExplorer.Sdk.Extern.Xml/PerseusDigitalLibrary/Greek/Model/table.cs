namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class table
  {

    private row[] rowField;

    private string tEIformField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("row")]
    public row[] row
    {
      get { return this.rowField; }
      set { this.rowField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string TEIform
    {
      get { return this.tEIformField; }
      set { this.tEIformField = value; }
    }
  }
}