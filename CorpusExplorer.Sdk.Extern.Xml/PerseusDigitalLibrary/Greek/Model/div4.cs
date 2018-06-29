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
  public class div4
  {
    private head headField;

    private string orgField;

    private string partField;

    private p pField;

    private string sampleField;

    private string tEIformField;

    private string typeField;

    /// <remarks />
    public head head
    {
      get => headField;
      set => headField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string org
    {
      get => orgField;
      set => orgField = value;
    }

    /// <remarks />
    public p p
    {
      get => pField;
      set => pField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string part
    {
      get => partField;
      set => partField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string sample
    {
      get => sampleField;
      set => sampleField = value;
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