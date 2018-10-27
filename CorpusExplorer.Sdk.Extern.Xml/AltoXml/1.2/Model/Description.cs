namespace CorpusExplorer.Sdk.Extern.Xml.AltoXml._1._2.Model
{
  /// <remarks/>
  [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
  [System.SerializableAttribute()]
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.ComponentModel.DesignerCategoryAttribute("code")]
  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
  [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
  public partial class Description
  {

    private string measurementUnitField;

    private sourceImageInformation sourceImageInformationField;

    private OCRProcessing oCRProcessingField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "NCName")]
    public string MeasurementUnit
    {
      get { return this.measurementUnitField; }
      set { this.measurementUnitField = value; }
    }

    /// <remarks/>
    public sourceImageInformation sourceImageInformation
    {
      get { return this.sourceImageInformationField; }
      set { this.sourceImageInformationField = value; }
    }

    /// <remarks/>
    public OCRProcessing OCRProcessing
    {
      get { return this.oCRProcessingField; }
      set { this.oCRProcessingField = value; }
    }
  }
}