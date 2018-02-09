namespace CorpusExplorer.Sdk.Extern.Xml.PostgreSqlDump.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class header
  {

    private column[] columnField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("column")]
    public column[] column
    {
      get { return this.columnField; }
      set { this.columnField = value; }
    }
  }
}