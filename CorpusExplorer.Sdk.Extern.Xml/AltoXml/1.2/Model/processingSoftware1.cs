namespace CorpusExplorer.Sdk.Extern.Xml.AltoXml._1._2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute("processingSoftware", Namespace = "", IsNullable = false)]
  public partial class processingSoftware1
  {

    private string softwareCreatorField;

    private string softwareNameField;

    private string softwareVersionField;

    /// <remarks/>
    public string softwareCreator
    {
      get { return this.softwareCreatorField; }
      set { this.softwareCreatorField = value; }
    }

    /// <remarks/>
    public string softwareName
    {
      get { return this.softwareNameField; }
      set { this.softwareNameField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "NMTOKEN")]
    public string softwareVersion
    {
      get { return this.softwareVersionField; }
      set { this.softwareVersionField = value; }
    }
  }
}