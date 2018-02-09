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
  public class AGSetTimeline
  {
    private string idField;
    private Metadata metadataField;
    private AGSetTimelineSignal[] signalField;

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string id { get { return idField; } set { idField = value; } }

    /// <remarks />
    public Metadata Metadata { get { return metadataField; } set { metadataField = value; } }

    /// <remarks />
    [XmlElement("Signal")]
    public AGSetTimelineSignal[] Signal { get { return signalField; } set { signalField = value; } }
  }
}