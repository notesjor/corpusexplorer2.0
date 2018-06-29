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
  [XmlRoot("sg", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class signGroupType
  {
    private object[] itemsField;
    private sw[] swField;

    /// <remarks />
    [XmlElement("e", typeof(eventType))]
    [XmlElement("freecode", typeof(freecodeType))]
    [XmlElement("g", typeof(groupType))]
    [XmlElement("internal-media", typeof(mediaType))]
    [XmlElement("italic", typeof(italic))]
    [XmlElement("long-feature", typeof(longfeature))]
    [XmlElement("nonvocal", typeof(nonvocal))]
    [XmlElement("overlap-point", typeof(overlapPointType))]
    [XmlElement("pause", typeof(pauseType))]
    [XmlElement("quotation", typeof(quotation))]
    [XmlElement("quotation2", typeof(quotation2))]
    [XmlElement("s", typeof(separatorType))]
    [XmlElement("tagMarker", typeof(tagMarkerType))]
    [XmlElement("underline", typeof(underline))]
    [XmlElement("w", typeof(wordType))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlElement("sw")]
    public sw[] sw
    {
      get => swField;
      set => swField = value;
    }
  }
}