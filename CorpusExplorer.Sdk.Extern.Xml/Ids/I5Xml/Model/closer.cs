namespace CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class closer
  {

    private salute saluteField;

    private object[] itemsField;

    /// <remarks/>
    public salute salute
    {
      get { return this.saluteField; }
      set { this.saluteField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("dateline", typeof(dateline))]
    [System.Xml.Serialization.XmlElementAttribute("signed", typeof(signed))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }
  }
}