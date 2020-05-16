namespace CorpusExplorer.Sdk.Extern.Xml.Ids.Model
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

    private object[] itemsField;

    private textDesc textDescField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("creation", typeof(creation))]
    [System.Xml.Serialization.XmlElementAttribute("langUsage", typeof(langUsage))]
    [System.Xml.Serialization.XmlElementAttribute("textClass", typeof(textClass))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    public textDesc textDesc
    {
      get { return this.textDescField; }
      set { this.textDescField = value; }
    }
  }
}