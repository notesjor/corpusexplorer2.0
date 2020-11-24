namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class inhaltsverzeichnis
  {

    private string ivztitelField;

    private object[] itemsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ivz-titel")]
    public string ivztitel
    {
      get { return this.ivztitelField; }
      set { this.ivztitelField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ivz-block", typeof(ivzblock))]
    [System.Xml.Serialization.XmlElementAttribute("ivz-eintrag", typeof(ivzeintrag))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }
  }
}