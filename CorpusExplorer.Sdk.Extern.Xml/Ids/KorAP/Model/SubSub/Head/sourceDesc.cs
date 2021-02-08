using CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.SubSub.Head;

namespace CorpusExplorer.Sdk.Extern.Xml.Ids.KorAP.Model.SubSub.Head
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class sourceDesc
  {

    private biblStruct biblStructField;

    private reference[] referenceField;

    private string defaultField;

    /// <remarks/>
    public biblStruct biblStruct
    {
      get { return this.biblStructField; }
      set { this.biblStructField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("reference")]
    public reference[] reference
    {
      get { return this.referenceField; }
      set { this.referenceField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string Default
    {
      get { return this.defaultField; }
      set { this.defaultField = value; }
    }
  }
}