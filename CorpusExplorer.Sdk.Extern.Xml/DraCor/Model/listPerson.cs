namespace CorpusExplorer.Sdk.Extern.Xml.DraCor.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public partial class listPerson
  {

    private object[] itemsField;

    private listRelation listRelationField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("person", typeof(person))]
    [System.Xml.Serialization.XmlElementAttribute("personGrp", typeof(personGrp))]
    public object[] Items
    {
      get { return this.itemsField; }
      set { this.itemsField = value; }
    }

    /// <remarks/>
    public listRelation listRelation
    {
      get { return this.listRelationField; }
      set { this.listRelationField = value; }
    }
  }
}