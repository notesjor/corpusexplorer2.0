namespace CorpusExplorer.Sdk.Extern.Xml.PostgreSqlDump.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class records
  {

    private column[][] rowField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("column", typeof(column), IsNullable = false)]
    public column[][] row
    {
      get { return this.rowField; }
      set { this.rowField = value; }
    }
  }
}