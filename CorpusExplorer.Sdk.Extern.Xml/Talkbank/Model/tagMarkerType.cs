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
  [XmlType(Namespace = "http://www.talkbank.org/ns/talkbank")]
  [XmlRoot("tagMarker", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class tagMarkerType
  {
    private morType[] morField;
    private tagMarkerTypeType typeField;

    /// <remarks />
    [XmlElement("mor")]
    public morType[] mor { get { return morField; } set { morField = value; } }

    /// <remarks />
    [XmlAttribute]
    public tagMarkerTypeType type { get { return typeField; } set { typeField = value; } }
  }
}