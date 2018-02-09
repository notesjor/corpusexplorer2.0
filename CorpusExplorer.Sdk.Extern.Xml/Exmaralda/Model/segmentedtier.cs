#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot("segmented-tier", Namespace = "", IsNullable = false)]
  public class segmentedtier
  {
    private annotation[] annotationField;
    private string categoryField;
    private string displaynameField;
    private string idField;
    private segmentation[] segmentationField;
    private string speakerField;
    private timelinefork[] timelineforkField;
    private segmentedtierType typeField;

    /// <remarks />
    [XmlElement("annotation")]
    public annotation[] annotation { get { return annotationField; } set { annotationField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string category { get { return categoryField; } set { categoryField = value; } }

    /// <remarks />
    [XmlAttribute("display-name")]
    public string displayname { get { return displaynameField; } set { displaynameField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    [XmlElement("segmentation")]
    public segmentation[] segmentation { get { return segmentationField; } set { segmentationField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string speaker { get { return speakerField; } set { speakerField = value; } }

    /// <remarks />
    [XmlElement("timeline-fork")]
    public timelinefork[] timelinefork { get { return timelineforkField; } set { timelineforkField = value; } }

    /// <remarks />
    [XmlAttribute]
    public segmentedtierType type { get { return typeField; } set { typeField = value; } }
  }
}