#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.DortmunderChatKorpus.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class message
  {
    private string colorField;
    private string creatorField;
    private string idField;
    private messageBody messageBodyField;
    private messageHead messageHeadField;
    private string timestamp1Field;
    private string timestampField;
    private messageType typeField;

    /// <remarks />
    [XmlAttribute]
    public string color
    {
      get => colorField;
      set => colorField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string creator
    {
      get => creatorField;
      set => creatorField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlElement(Order = 2)]
    public messageBody messageBody
    {
      get => messageBodyField;
      set => messageBodyField = value;
    }

    /// <remarks />
    [XmlElement(Order = 1)]
    public messageHead messageHead
    {
      get => messageHeadField;
      set => messageHeadField = value;
    }

    /// <remarks />
    [XmlElement(Order = 0)]
    public string timestamp
    {
      get => timestampField;
      set => timestampField = value;
    }

    /// <remarks />
    [XmlElement("timestamp", Order = 3)]
    public string timestamp1
    {
      get => timestamp1Field;
      set => timestamp1Field = value;
    }

    /// <remarks />
    [XmlAttribute]
    public messageType type
    {
      get => typeField;
      set => typeField = value;
    }
  }
}