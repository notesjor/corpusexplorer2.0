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
  [XmlRoot(Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class AGSet
  {
    private AGSetAG[] agField;
    private string idField;
    private Metadata metadataField;
    private AGSetTimeline[] timelineField;
    private string versionField;

    public AGSet() { versionField = "1.0"; }

    /// <remarks />
    [XmlElement("Timeline")]
    public AGSetTimeline[] Timeline { get { return timelineField; } set { timelineField = value; } }

    /// <remarks />
    [XmlElement("AG")]
    public AGSetAG[] AG { get { return agField; } set { agField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    public Metadata Metadata { get { return metadataField; } set { metadataField = value; } }


    /// <remarks />
    [XmlAttribute]
    public string version { get { return versionField; } set { versionField = value; } }
  }
}