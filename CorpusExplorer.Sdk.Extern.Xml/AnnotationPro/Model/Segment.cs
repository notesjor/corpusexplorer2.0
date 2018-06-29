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
    public string ForeColor
    {
      get => foreColorField;
      set => foreColorField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string BackColor
    {
      get => backColorField;
      set => backColorField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string BorderColor
    {
      get => borderColorField;
      set => borderColorField = value;
    }

    /// <remarks />
    public decimal Duration
    {
      get => durationField;
      set => durationField = value;
    }

    /// <remarks />
    public string Feature
    {
      get => featureField;
      set => featureField = value;
    }


    /// <remarks />
    public string Group
    {
      get => groupField;
      set => groupField = value;
    }

    /// <remarks />
    public string Id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    public string IdLayer
    {
      get => idLayerField;
      set => idLayerField = value;
    }

    /// <remarks />
    public bool IsMarker
    {
      get => isMarkerField;
      set => isMarkerField = value;
    }

    /// <remarks />
    public bool IsSelected
    {
      get => isSelectedField;
      set => isSelectedField = value;
    }

    /// <remarks />
    public string Label
    {
      get => labelField;
      set => labelField = value;
    }

    /// <remarks />
    public string Language
    {
      get => languageField;
      set => languageField = value;
    }

    /// <remarks />
    public string Marker
    {
      get => markerField;
      set => markerField = value;
    }

    /// <remarks />
    public string Name
    {
      get => nameField;
      set => nameField = value;
    }

    /// <remarks />
    public string Parameter1
    {
      get => parameter1Field;
      set => parameter1Field = value;
    }

    /// <remarks />
    public string Parameter2
    {
      get => parameter2Field;
      set => parameter2Field = value;
    }

    /// <remarks />
    public string Parameter3
    {
      get => parameter3Field;
      set => parameter3Field = value;
    }

    /// <remarks />
    public string RScript
    {
      get => rScriptField;
      set => rScriptField = value;
    }

    /// <remarks />
    public decimal Start
    {
      get => startField;
      set => startField = value;
    }
  }
}