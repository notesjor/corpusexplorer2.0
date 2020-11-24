namespace CorpusExplorer.Sdk.Extern.Xml.BundestagOpenAccess.Plenarprotokolle.v2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class rolle
  {

    // private string[] itemsField;

    private ItemsChoiceType1[] itemsElementNameField;
    private string rollekurz;
    private string rollelang;

    /*
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("rolle_kurz", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("rolle_lang", typeof(string))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public string[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }
    */

    [System.Xml.Serialization.XmlElementAttribute("rolle_kurz", typeof(string))]
    public string RolleKurz
    {
      get { return this.rollekurz; }
      set { this.rollekurz = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("rolle_lang", typeof(string))]
    public string RolleLang
    {
      get { return this.rollelang; }
      set { this.rollelang = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemsChoiceType1[] ItemsElementName
    {
      get { return this.itemsElementNameField; }
      set { this.itemsElementNameField = value; }
    }
  }
}