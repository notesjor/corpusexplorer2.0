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
  public partial class tok_dipl
  {

    private string idField;

    private string transField;

    private string utfField;

    /// <remarks/>
    [XmlAttribute(DataType = "NCName")]
    public string id
    {
      get { return this.idField; }
      set { this.idField = value; }
    }

    /// <remarks/>
    [XmlAttribute()]
    public string trans
    {
      get { return this.transField; }
      set { this.transField = value; }
    }

    /// <remarks/>
    [XmlAttribute()]
    public string utf
    {
      get { return this.utfField; }
      set { this.utfField = value; }
    }
  }
}