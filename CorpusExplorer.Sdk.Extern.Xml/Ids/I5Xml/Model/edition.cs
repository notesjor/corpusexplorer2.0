namespace CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml.Model
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

    private string appearanceField;

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
    public string appearance
    {
      get { return this.appearanceField; }
      set { this.appearanceField = value; }
    }
  }
}