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
  public partial class page
  {

    private string idField;

    private string noField;

    private string rangeField;

    private string sideField;

    /// <remarks/>
    [XmlAttribute(DataType = "NCName")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }

    /// <remarks/>
    [XmlAttribute()]
    public string no
    {
      get { return this.noField; }
      set { this.noField = value; }
    }

    /// <remarks/>
    [XmlAttribute(DataType = "NCName")]
    public string range
    {
      get { return this.rangeField; }
      set { this.rangeField = value; }
    }

    /// <remarks/>
    [XmlAttribute(DataType = "NCName")]
    public string side
    {
      get { return this.sideField; }
      set { this.sideField = value; }
    }
  }
}