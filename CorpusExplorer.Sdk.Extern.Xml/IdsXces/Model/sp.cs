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
  public class sp
  {
    private object itemField;

    private string speakerField;

    private stage stageField;

    private string whoField;

    /// <remarks />
    [XmlElement("p", typeof(p))]
    [XmlElement("poem", typeof(poem))]
    public object Item { get { return itemField; } set { itemField = value; } }

    /// <remarks />
    public string speaker { get { return speakerField; } set { speakerField = value; } }

    /// <remarks />
    public stage stage { get { return stageField; } set { stageField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string who { get { return whoField; } set { whoField = value; } }
  }
}