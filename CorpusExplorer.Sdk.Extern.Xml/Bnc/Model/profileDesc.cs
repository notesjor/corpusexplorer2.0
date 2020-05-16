namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
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

    private creation creationField;

    private particDesc particDescField;

    private setting[] settingDescField;

    private textClass textClassField;

    /// <remarks/>
    public creation creation
    {
      get { return this.creationField; }
      set { this.creationField = value; }
    }

    /// <remarks/>
    public particDesc particDesc
    {
      get { return this.particDescField; }
      set { this.particDescField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("setting", IsNullable = false)]
    public setting[] settingDesc
    {
      get { return this.settingDescField; }
      set { this.settingDescField = value; }
    }

    /// <remarks/>
    public textClass textClass
    {
      get { return this.textClassField; }
      set { this.textClassField = value; }
    }
  }
}