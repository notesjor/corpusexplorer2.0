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
  public partial class quote
  {

    private string rangeField;

    /// <remarks/>
    [XmlAttribute(DataType = "NCName")]
    public string range
    {
      get { return this.rangeField; }
      set { this.rangeField = value; }
    }
  }
}