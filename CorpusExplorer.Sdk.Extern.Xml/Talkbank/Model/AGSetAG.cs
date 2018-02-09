#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "2.0.50727.3038")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.talkbank.org/ns/talkbank")]
  public class AGSetAG
  {
    private AGSetAGAnchor[] anchorField;
    private AGSetAGAnnotation[] annotationField;
    private string idField;
    private Metadata metadataField;
    private string timelineField;
    private string typeField;

    /// <remarks />
    [XmlElement("Anchor")]
    public AGSetAGAnchor[] Anchor { get { return anchorField; } set { anchorField = value; } }

    /// <remarks />
    [XmlElement("Annotation")]
    public AGSetAGAnnotation[] Annotation { get { return annotationField; } set { annotationField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    public Metadata Metadata { get { return metadataField; } set { metadataField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string timeline { get { return timelineField; } set { timelineField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string type { get { return typeField; } set { typeField = value; } }
  }
}