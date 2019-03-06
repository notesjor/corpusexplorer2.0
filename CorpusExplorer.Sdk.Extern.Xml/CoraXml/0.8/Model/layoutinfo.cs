namespace CorpusExplorer.Sdk.Extern.Xml.CoraXml._0._8.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class layoutinfo
  {

    private page[] pageField;

    private column[] columnField;

    private line[] lineField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("page")]
    public page[] page
    {
      get { return this.pageField; }
      set { this.pageField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("column")]
    public column[] column
    {
      get { return this.columnField; }
      set { this.columnField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("line")]
    public line[] line
    {
      get { return this.lineField; }
      set { this.lineField = value; }
    }
  }
}