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
  public class orig
  {
    private string regaltField;

    private string regField;

    private string[] textField;

    /// <remarks />
    [XmlAttribute]
    public string reg { get { return regField; } set { regField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string regalt { get { return regaltField; } set { regaltField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }
  }
}