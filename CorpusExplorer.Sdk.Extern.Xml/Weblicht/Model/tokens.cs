namespace CorpusExplorer.Sdk.Extern.Xml.Weblicht.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.dspin.de/data/textcorpus", IsNullable = false)]
  public partial class tokens
  {

    private token[] tokenField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("token")]
    public token[] token
    {
      get { return this.tokenField; }
      set { this.tokenField = value; }
    }
  }
}