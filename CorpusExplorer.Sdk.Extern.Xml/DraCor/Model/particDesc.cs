namespace CorpusExplorer.Sdk.Extern.Xml.DraCor.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class particDesc
  {

    private listPerson listPersonField;

    private person personField;

    /// <remarks/>
    public listPerson listPerson
    {
      get { return this.listPersonField; }
      set { this.listPersonField = value; }
    }

    /// <remarks/>
    public person person
    {
      get { return this.personField; }
      set { this.personField = value; }
    }
  }
}