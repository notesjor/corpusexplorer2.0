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
  public partial class layoutinfo
  {

    private page[] pageField;

    private column[] columnField;

    private line[] lineField;

    /// <remarks/>
    [XmlElement("page")]
    public page[] page
    {
      get { return this.pageField; }
      set { this.pageField = value; }
    }

    /// <remarks/>
    [XmlElement("column")]
    public column[] column
    {
      get { return this.columnField; }
      set { this.columnField = value; }
    }

    /// <remarks/>
    [XmlElement("line")]
    public line[] line
    {
      get { return this.lineField; }
      set { this.lineField = value; }
    }
  }
}