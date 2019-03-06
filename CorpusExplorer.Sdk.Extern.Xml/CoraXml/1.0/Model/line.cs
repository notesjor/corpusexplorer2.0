using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.CoraXml._1._0.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public partial class line
  {

    private string idField;

    private string locField;

    private string nameField;

    private string rangeField;

    /// <remarks/>
    [XmlAttribute(DataType = "NCName")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }

    /// <remarks/>
    [XmlAttribute()]
    public string loc
    {
      get { return this.locField; }
      set { this.locField = value; }
    }

    /// <remarks/>
    [XmlAttribute()]
    public string name
    {
      get { return this.nameField; }
      set { this.nameField = value; }
    }

    /// <remarks/>
    [XmlAttribute(DataType = "NCName")]
    public string range
    {
      get { return this.rangeField; }
      set { this.rangeField = value; }
    }
  }
}