namespace CorpusExplorer.Sdk.Extern.Xml.Bnc.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class settingDesc
  {

    private setting[] settingField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("setting")]
    public setting[] setting
    {
      get { return this.settingField; }
      set { this.settingField = value; }
    }
  }
}