namespace CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml.Model
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
    private textClass textClassField;

    private textDesc textDescField;

    private creation creation;

    private langUsage langUsage;


    [System.Xml.Serialization.XmlElementAttribute("creation", typeof(creation))]
    public creation Creation
    {
      get { return this.creation; }
      set { this.creation = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("langUsage", typeof(langUsage))]
    public langUsage LangUsage
    {
      get { return this.langUsage; }
      set { this.langUsage = value; }
    }

    /// <remarks/>
    public textClass textClass
    {
      get { return this.textClassField; }
      set { this.textClassField = value; }
    }

    /// <remarks/>
    public textDesc textDesc
    {
      get { return this.textDescField; }
      set { this.textDescField = value; }
    }
  }
}