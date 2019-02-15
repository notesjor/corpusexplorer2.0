namespace CorpusExplorer.Sdk.Extern.Xml.Tei.P5Cal2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class profileDesc
  {

    private langUsage langUsageField;

    private textClass textClassField;

    /// <remarks/>
    public langUsage langUsage
    {
      get { return this.langUsageField; }
      set { this.langUsageField = value; }
    }

    /// <remarks/>
    public textClass textClass
    {
      get { return this.textClassField; }
      set { this.textClassField = value; }
    }
  }
}