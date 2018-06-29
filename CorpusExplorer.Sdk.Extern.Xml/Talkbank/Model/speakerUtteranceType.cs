#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
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
  [XmlRoot("u", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class speakerUtteranceType
  {
    private object[] items1Field;
    private object[] itemsField;
    private string langField;
    private linkerType[] linkerField;
    private mediaType mediaField;
    private postcodeType[] postcodeField;
    private terminatorType tField;
    private string uIDField;
    private string whoField;

    /// <remarks />
    [XmlElement("linker")]
    public linkerType[] linker
    {
      get => linkerField;
      set => linkerField = value;
    }

    /// <remarks />
    [XmlElement("blob", typeof(blob))]
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
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    [XmlElement("postcode")]
    public postcodeType[] postcode
    {
      get => postcodeField;
      set => postcodeField = value;
    }

    /// <remarks />
    [XmlElement("a", typeof(annotationType))]
    [XmlElement("error", typeof(string))]
    [XmlElement("k", typeof(markers))]
    [XmlElement("r", typeof(repetitionType))]
    public object[] Items1
    {
      get => items1Field;
      set => items1Field = value;
    }

    /// <remarks />
    [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string lang
    {
      get => langField;
      set => langField = value;
    }


    /// <remarks />
    public mediaType media
    {
      get => mediaField;
      set => mediaField = value;
    }


    /// <remarks />
    public terminatorType t
    {
      get => tField;
      set => tField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string uID
    {
      get => uIDField;
      set => uIDField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string who
    {
      get => whoField;
      set => whoField = value;
    }
  }
}