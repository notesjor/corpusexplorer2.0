#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple.Model
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
    public object Item
    {
      get => itemField;
      set => itemField = value;
    }

    /// <remarks />
    public output output
    {
      get => outputField;
      set => outputField = value;
    }

    /// <remarks />
    public target target
    {
      get => targetField;
      set => targetField = value;
    }
  }
}