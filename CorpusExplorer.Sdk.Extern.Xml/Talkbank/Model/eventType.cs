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
  [XmlRoot("e", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class eventType
  {
    private object itemField;
    private object[] itemsField;

    /// <remarks />
    [XmlElement("action", typeof(object))]
    [XmlElement("happening", typeof(string))]
    [XmlElement("otherSpokenEvent", typeof(otherSpokenEvent))]
    public object Item
    {
      get => itemField;
      set => itemField = value;
    }

    /// <remarks />
    [XmlElement("duration", typeof(decimal))]
    [XmlElement("error", typeof(string))]
    [XmlElement("ga", typeof(groupAnnotationType))]
    [XmlElement("k", typeof(markers))]
    [XmlElement("overlap", typeof(overlapType))]
    [XmlElement("r", typeof(repetitionType))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }
  }
}