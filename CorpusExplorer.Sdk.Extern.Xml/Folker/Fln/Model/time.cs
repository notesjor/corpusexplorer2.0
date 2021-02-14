namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Fln.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class time
  {

    private string olField;

    private decimal time1Field;

    private string timepointreferenceField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string ol
    {
      get { return this.olField; }
      set { this.olField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("time")]
    public decimal time1
    {
      get { return this.time1Field; }
      set { this.time1Field = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("timepoint-reference", DataType = "NCName")]
    public string timepointreference
    {
      get { return this.timepointreferenceField; }
      set { this.timepointreferenceField = value; }
    }
  }
}