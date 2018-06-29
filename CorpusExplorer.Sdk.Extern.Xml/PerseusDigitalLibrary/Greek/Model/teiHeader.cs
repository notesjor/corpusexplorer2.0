using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.PerseusDigitalLibrary.Greek.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class teiHeader
  {
    private fileDesc fileDescField;

    private object[] itemsField;

    private revisionDesc revisionDescField;

    private string statusField;

    private string tEIformField;

    private string typeField;

    /// <remarks />
    public fileDesc fileDesc
    {
      get => fileDescField;
      set => fileDescField = value;
    }

    /// <remarks />
    [XmlElement("encodingDesc", typeof(encodingDesc))]
    [XmlElement("profileDesc", typeof(profileDesc))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }

    /// <remarks />
    public revisionDesc revisionDesc
    {
      get => revisionDescField;
      set => revisionDescField = value;
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
  }
}