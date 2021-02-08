namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.Root
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class profileDesc
  {

    private langUsage langUsageField;

    private textDesc textDescField;

    /// <remarks/>
    public langUsage langUsage
    {
      get { return this.langUsageField; }
      set { this.langUsageField = value; }
    }

    /// <remarks/>
    public textDesc textDesc
    {
      get { return this.textDescField; }
      set { this.textDescField = value; }
    }
  }
}