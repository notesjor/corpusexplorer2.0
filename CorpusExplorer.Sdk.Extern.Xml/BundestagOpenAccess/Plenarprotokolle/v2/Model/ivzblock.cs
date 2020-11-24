namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute("ivz-block", Namespace = "", IsNullable = false)]
  public partial class ivzblock
  {

    private string ivzblocktitelField;

    private object[] itemsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ivz-block-titel")]
    public string ivzblocktitel
    {
      get { return this.ivzblocktitelField; }
      set { this.ivzblocktitelField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ivz-block", typeof(ivzblock))]
    [System.Xml.Serialization.XmlElementAttribute("ivz-eintrag", typeof(ivzeintrag))]
    [System.Xml.Serialization.XmlElementAttribute("p", typeof(p))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }
  }
}