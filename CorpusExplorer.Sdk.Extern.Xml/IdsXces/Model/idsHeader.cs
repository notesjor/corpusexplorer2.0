using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.IdsXces.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.81.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class idsHeader
  {
    private encodingDesc encodingDescField;

    private fileDesc fileDescField;

    private string patternField;

    private profileDesc profileDescField;

    private string statusField;

    private string tEIformField;

    private string typeField;

    private decimal versionField;

    /// <remarks />
    public encodingDesc encodingDesc
    {
      get => encodingDescField;
      set => encodingDescField = value;
    }

    /// <remarks />
    public fileDesc fileDesc
    {
      get => fileDescField;
      set => fileDescField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string pattern
    {
      get => patternField;
      set => patternField = value;
    }

    /// <remarks />
    public profileDesc profileDesc
    {
      get => profileDescField;
      set => profileDescField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string status
    {
      get => statusField;
      set => statusField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string TEIform
    {
      get => tEIformField;
      set => tEIformField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string type
    {
      get => typeField;
      set => typeField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public decimal version
    {
      get => versionField;
      set => versionField = value;
    }
  }
}