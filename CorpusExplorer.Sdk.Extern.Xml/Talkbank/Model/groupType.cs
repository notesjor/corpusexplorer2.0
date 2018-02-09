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
  [XmlRoot("g", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class groupType
  {
    private object[] items1Field;
    private object[] itemsField;

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
    [XmlElement("pg", typeof(phoneticGroupType))]
    [XmlElement("quotation", typeof(quotation))]
    [XmlElement("quotation2", typeof(quotation2))]
    [XmlElement("s", typeof(separatorType))]
    [XmlElement("sg", typeof(signGroupType))]
    [XmlElement("tagMarker", typeof(tagMarkerType))]
    [XmlElement("underline", typeof(underline))]
    [XmlElement("w", typeof(wordType))]
    public object[] Items { get { return itemsField; } set { itemsField = value; } }

    /// <remarks />
    [XmlElement("duration", typeof(decimal))]
    [XmlElement("error", typeof(string))]
    [XmlElement("ga", typeof(groupAnnotationType))]
    [XmlElement("k", typeof(markers))]
    [XmlElement("overlap", typeof(overlapType))]
    [XmlElement("r", typeof(repetitionType))]
    public object[] Items1 { get { return items1Field; } set { items1Field = value; } }
  }
}