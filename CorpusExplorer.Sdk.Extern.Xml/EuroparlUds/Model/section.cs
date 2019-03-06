namespace CorpusExplorer.Sdk.Extern.Xml.EuroparlUds.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class section
  {

    private intervention[] interventionField;

    private string idField;

    private string titleField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("intervention")]
    public intervention[] intervention
    {
      get { return this.interventionField; }
      set { this.interventionField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string title
    {
      get { return this.titleField; }
      set { this.titleField = value; }
    }
  }
}