namespace CorpusExplorer.Sdk.Extern.Xml.AltoXml._1._2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class OCRProcessing
  {

    private processingSoftware preProcessingStepField;

    private processingSoftware ocrProcessingStepField;

    private string idField;

    /// <remarks/>
    public processingSoftware preProcessingStep
    {
      get { return this.preProcessingStepField; }
      set { this.preProcessingStepField = value; }
    }

    /// <remarks/>
    public processingSoftware ocrProcessingStep
    {
      get { return this.ocrProcessingStepField; }
      set { this.ocrProcessingStepField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
    public string ID
    {
      get { return this.idField; }
      set { this.idField = value; }
    }
  }
}