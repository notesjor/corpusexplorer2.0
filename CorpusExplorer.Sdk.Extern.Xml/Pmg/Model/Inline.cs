using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Pmg.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlRoot("em", Namespace = "", IsNullable = false)]
  public class Inline
  {
    private object[] inlineField;

    private string[] textField;

    /// <remarks />
    [XmlElement("inline")]
    public object[] inline { get { return inlineField; } set { inlineField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }
  }
}