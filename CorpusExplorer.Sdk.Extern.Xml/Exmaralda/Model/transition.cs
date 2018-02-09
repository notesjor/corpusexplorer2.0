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
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class transition
  {
    private object itemField;
    private output outputField;
    private target targetField;

    /// <remarks />
    [XmlElement("input-char", typeof(string))]
    [XmlElement("input-char-set", typeof(inputcharset))]
    [XmlElement("input-end", typeof(inputend))]
    [XmlElement("input-other", typeof(inputother))]
    public object Item { get { return itemField; } set { itemField = value; } }

    /// <remarks />
    public output output { get { return outputField; } set { outputField = value; } }

    /// <remarks />
    public target target { get { return targetField; } set { targetField = value; } }
  }
}