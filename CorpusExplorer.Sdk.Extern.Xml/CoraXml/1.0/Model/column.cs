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
  public partial class column
  {

    private string countField;

    private string idField;

    private string rangeField;

    /// <remarks/>
    [XmlAttribute(DataType = "NCName")]
    public string count
    {
      get { return this.countField; }
      set { this.countField = value; }
    }

    /// <remarks/>
    [XmlAttribute(DataType = "NCName")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
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