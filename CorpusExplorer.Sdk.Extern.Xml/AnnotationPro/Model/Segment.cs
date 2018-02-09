using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.AnnotationPro.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "2.0.50727.3038")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://tempuri.org/AnnotationSystemDataSet.xsd")]
  [XmlRoot(Namespace = "http://tempuri.org/AnnotationSystemDataSet.xsd", IsNullable = false)]
  public class Segment
  {
    private string backColorField;
    private string borderColorField;
    private decimal durationField;
    private string featureField;
    private string foreColorField;
    private string groupField;
    private string idField;
    private string idLayerField;
    private bool isMarkerField;
    private bool isSelectedField;
    private string labelField;
    private string languageField;
    private string markerField;
    private string nameField;
    private string parameter1Field;
    private string parameter2Field;
    private string parameter3Field;
    private string rScriptField;
    private decimal startField;

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string ForeColor { get { return foreColorField; } set { foreColorField = value; } }

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string BackColor { get { return backColorField; } set { backColorField = value; } }

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string BorderColor { get { return borderColorField; } set { borderColorField = value; } }

    /// <remarks />
    public decimal Duration { get { return durationField; } set { durationField = value; } }

    /// <remarks />
    public string Feature { get { return featureField; } set { featureField = value; } }


    /// <remarks />
    public string Group { get { return groupField; } set { groupField = value; } }

    /// <remarks />
    public string Id { get { return idField; } set { idField = value; } }

    /// <remarks />
    public string IdLayer { get { return idLayerField; } set { idLayerField = value; } }

    /// <remarks />
    public bool IsMarker { get { return isMarkerField; } set { isMarkerField = value; } }

    /// <remarks />
    public bool IsSelected { get { return isSelectedField; } set { isSelectedField = value; } }

    /// <remarks />
    public string Label { get { return labelField; } set { labelField = value; } }

    /// <remarks />
    public string Language { get { return languageField; } set { languageField = value; } }

    /// <remarks />
    public string Marker { get { return markerField; } set { markerField = value; } }

    /// <remarks />
    public string Name { get { return nameField; } set { nameField = value; } }

    /// <remarks />
    public string Parameter1 { get { return parameter1Field; } set { parameter1Field = value; } }

    /// <remarks />
    public string Parameter2 { get { return parameter2Field; } set { parameter2Field = value; } }

    /// <remarks />
    public string Parameter3 { get { return parameter3Field; } set { parameter3Field = value; } }

    /// <remarks />
    public string RScript { get { return rScriptField; } set { rScriptField = value; } }

    /// <remarks />
    public decimal Start { get { return startField; } set { startField = value; } }
  }
}