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
  public partial class token
  {

    private tok_dipl[] tok_diplField;

    private tok_anno[] tok_annoField;

    private string idField;

    private string transField;

    private string typeField;

    /// <remarks/>
    [XmlElement("tok_dipl")]
    public tok_dipl[] tok_dipl
    {
      get { return this.tok_diplField; }
      set { this.tok_diplField = value; }
    }

    /// <remarks/>
    [XmlElement("tok_anno")]
    public tok_anno[] tok_anno
    {
      get { return this.tok_annoField; }
      set { this.tok_annoField = value; }
    }

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
    [XmlAttribute(DataType = "NCName")]
    public string type
    {
      get { return this.typeField; }
      set { this.typeField = value; }
    }
  }
}