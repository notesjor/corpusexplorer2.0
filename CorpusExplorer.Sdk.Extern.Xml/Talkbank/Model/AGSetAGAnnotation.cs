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
  public class AGSetAGAnnotation
  {
    private string endField;
    private AGSetAGAnnotationFeature[] featureField;
    private string idField;
    private string startField;
    private string typeField;

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string end
    {
      get => endField;
      set => endField = value;
    }

    /// <remarks />
    [XmlElement("Feature")]
    public AGSetAGAnnotationFeature[] Feature
    {
      get => featureField;
      set => featureField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string start
    {
      get => startField;
      set => startField = value;
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