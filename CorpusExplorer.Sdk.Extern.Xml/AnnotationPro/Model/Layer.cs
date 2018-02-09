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
    public string ForeColor { get { return foreColorField; } set { foreColorField = value; } }

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string BackColor { get { return backColorField; } set { backColorField = value; } }

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string Height { get { return heightField; } set { heightField = value; } }

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string CoordinateControlStyle
    {
      get { return coordinateControlStyleField; }
      set { coordinateControlStyleField = value; }
    }

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string ChartMinimum { get { return chartMinimumField; } set { chartMinimumField = value; } }

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string ChartMaximum { get { return chartMaximumField; } set { chartMaximumField = value; } }


    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string FontSize { get { return fontSizeField; } set { fontSizeField = value; } }


    /// <remarks />
    public string Id { get { return idField; } set { idField = value; } }

    /// <remarks />
    public bool IncludeInFrequency { get { return includeInFrequencyField; } set { includeInFrequencyField = value; } }

    /// <remarks />
    public bool IsClosed { get { return isClosedField; } set { isClosedField = value; } }

    /// <remarks />
    public bool IsLocked { get { return isLockedField; } set { isLockedField = value; } }

    /// <remarks />
    public bool IsSelected { get { return isSelectedField; } set { isSelectedField = value; } }

    /// <remarks />
    public bool IsVisible { get { return isVisibleField; } set { isVisibleField = value; } }

    /// <remarks />
    public string Name { get { return nameField; } set { nameField = value; } }

    /// <remarks />
    public string Parameter1Name { get { return parameter1NameField; } set { parameter1NameField = value; } }

    /// <remarks />
    public string Parameter2Name { get { return parameter2NameField; } set { parameter2NameField = value; } }

    /// <remarks />
    public string Parameter3Name { get { return parameter3NameField; } set { parameter3NameField = value; } }

    /// <remarks />
    public bool ShowAsChart { get { return showAsChartField; } set { showAsChartField = value; } }

    /// <remarks />
    public bool ShowBoundaries { get { return showBoundariesField; } set { showBoundariesField = value; } }

    /// <remarks />
    public bool ShowOnSpectrogram { get { return showOnSpectrogramField; } set { showOnSpectrogramField = value; } }
  }
}