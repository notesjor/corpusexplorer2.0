using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.SlashA.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.81.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/textcorpus")]
  [XmlRoot(Namespace = "http://www.dspin.de/data/textcorpus", IsNullable = false)]
  public class token
  {
    private string idField;

    private string[] textField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string ID { get { return idField; } set { idField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }
  }
}