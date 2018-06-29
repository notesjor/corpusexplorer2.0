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
  public class Layer
  {
    private string backColorField;
    private string chartMaximumField;
    private string chartMinimumField;
    private string coordinateControlStyleField;
    private string fontSizeField;
    private string foreColorField;
    private string heightField;
    private string idField;
    private bool includeInFrequencyField;
    private bool isClosedField;
    private bool isLockedField;
    private bool isSelectedField;
    private bool isVisibleField;
    private string nameField;
    private string parameter1NameField;
    private string parameter2NameField;
    private string parameter3NameField;
    private bool showAsChartField;
    private bool showBoundariesField;
    private bool showOnSpectrogramField;

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
    public string Height
    {
      get => heightField;
      set => heightField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string CoordinateControlStyle
    {
      get => coordinateControlStyleField;
      set => coordinateControlStyleField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string ChartMinimum
    {
      get => chartMinimumField;
      set => chartMinimumField = value;
    }

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string ChartMaximum
    {
      get => chartMaximumField;
      set => chartMaximumField = value;
    }


    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string FontSize
    {
      get => fontSizeField;
      set => fontSizeField = value;
    }


    /// <remarks />
    public string Id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    public bool IncludeInFrequency
    {
      get => includeInFrequencyField;
      set => includeInFrequencyField = value;
    }

    /// <remarks />
    public bool IsClosed
    {
      get => isClosedField;
      set => isClosedField = value;
    }

    /// <remarks />
    public bool IsLocked
    {
      get => isLockedField;
      set => isLockedField = value;
    }

    /// <remarks />
    public bool IsSelected
    {
      get => isSelectedField;
      set => isSelectedField = value;
    }

    /// <remarks />
    public bool IsVisible
    {
      get => isVisibleField;
      set => isVisibleField = value;
    }

    /// <remarks />
    public string Name
    {
      get => nameField;
      set => nameField = value;
    }

    /// <remarks />
    public string Parameter1Name
    {
      get => parameter1NameField;
      set => parameter1NameField = value;
    }

    /// <remarks />
    public string Parameter2Name
    {
      get => parameter2NameField;
      set => parameter2NameField = value;
    }

    /// <remarks />
    public string Parameter3Name
    {
      get => parameter3NameField;
      set => parameter3NameField = value;
    }

    /// <remarks />
    public bool ShowAsChart
    {
      get => showAsChartField;
      set => showAsChartField = value;
    }

    /// <remarks />
    public bool ShowBoundaries
    {
      get => showBoundariesField;
      set => showBoundariesField = value;
    }

    /// <remarks />
    public bool ShowOnSpectrogram
    {
      get => showOnSpectrogramField;
      set => showOnSpectrogramField = value;
    }
  }
}