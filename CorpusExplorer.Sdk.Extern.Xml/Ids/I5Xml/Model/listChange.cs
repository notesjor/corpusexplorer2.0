namespace CorpusExplorer.Sdk.Extern.Xml.Ids.I5Xml.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class listChange
  {

    private change[] changeField;

    private bool orderedField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("change")]
    public change[] change
    {
      get { return this.changeField; }
      set { this.changeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool ordered
    {
      get { return this.orderedField; }
      set { this.orderedField = value; }
    }
  }
}