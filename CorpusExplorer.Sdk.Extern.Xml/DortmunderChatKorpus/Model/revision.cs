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
  public class revision
  {
    private string byField;
    private string noField;
    private string[] textField;

    /// <remarks />
    [XmlAttribute]
    public string by { get { return byField; } set { byField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "NMTOKEN")]
    public string no { get { return noField; } set { noField = value; } }

    /// <remarks />
    [XmlText]
    public string[] Text { get { return textField; } set { textField = value; } }
  }
}