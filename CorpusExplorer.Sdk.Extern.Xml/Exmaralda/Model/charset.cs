#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot("char-set", Namespace = "", IsNullable = false)]
  public class charset
  {
    private string[] charField;
    private string commentField;
    private string idField;

    /// <remarks />
    [XmlElement("char")]
    public string[] @char { get { return charField; } set { charField = value; } }

    /// <remarks />
    public string comment { get { return commentField; } set { commentField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string id { get { return idField; } set { idField = value; } }
  }
}