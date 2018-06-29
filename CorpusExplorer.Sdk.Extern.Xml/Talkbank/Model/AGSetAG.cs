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
    public AGSetAGAnchor[] Anchor
    {
      get => anchorField;
      set => anchorField = value;
    }

    /// <remarks />
    [XmlElement("Annotation")]
    public AGSetAGAnnotation[] Annotation
    {
      get => annotationField;
      set => annotationField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    public Metadata Metadata
    {
      get => metadataField;
      set => metadataField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string timeline
    {
      get => timelineField;
      set => timelineField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string type
    {
      get => typeField;
      set => typeField = value;
    }
  }
}