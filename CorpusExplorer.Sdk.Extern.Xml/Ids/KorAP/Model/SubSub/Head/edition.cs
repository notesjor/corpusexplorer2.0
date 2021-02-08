namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.SubSub.Head
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class edition
  {

    private string furtherField;

    private kind kindField;

    private appearance appearanceField;

    /// <remarks/>
    public string further
    {
      get { return this.furtherField; }
      set { this.furtherField = value; }
    }

    /// <remarks/>
    public kind kind
    {
      get { return this.kindField; }
      set { this.kindField = value; }
    }

    /// <remarks/>
    public appearance appearance
    {
      get { return this.appearanceField; }
      set { this.appearanceField = value; }
    }
  }
}