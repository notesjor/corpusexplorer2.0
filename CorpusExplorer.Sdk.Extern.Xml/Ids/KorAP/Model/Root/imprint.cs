namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.Root
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class imprint
  {

    private string publisherField;

    private pubPlace pubPlaceField;

    /// <remarks/>
    public string publisher
    {
      get { return this.publisherField; }
      set { this.publisherField = value; }
    }

    /// <remarks/>
    public pubPlace pubPlace
    {
      get { return this.pubPlaceField; }
      set { this.pubPlaceField = value; }
    }
  }
}