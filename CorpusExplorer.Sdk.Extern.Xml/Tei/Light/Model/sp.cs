using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Light.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.tei-c.org/ns/1.0")]
  [XmlRoot(Namespace = "http://www.tei-c.org/ns/1.0", IsNullable = false)]
  public class sp
  {
    private p[] pField;

    private speaker speakerField;

    private string whoField;

    /// <remarks />
    [XmlElement("p")]
    public p[] p
    {
      get => pField;
      set => pField = value;
    }

    /// <remarks />
    public speaker speaker
    {
      get => speakerField;
      set => speakerField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string who
    {
      get => whoField;
      set => whoField = value;
    }
  }
}