namespace CorpusExplorer.Sdk.Extern.Xml.JeanPaulLetter.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class row
  {

    private cell[] cellField;

    private string colsField;

    private string roleField;

    private string rowsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("cell")]
    public cell[] cell
    {
      get { return this.cellField; }
      set { this.cellField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
    public string cols
    {
      get { return this.colsField; }
      set { this.colsField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string role
    {
      get { return this.roleField; }
      set { this.roleField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
    public string rows
    {
      get { return this.rowsField; }
      set { this.rowsField = value; }
    }
  }
}