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
  public class transitions
  {
    private string commentField;
    private string forbiddenField;
    private string sourceField;
    private transition[] transitionField;

    /// <remarks />
    public string comment
    {
      get => commentField;
      set => commentField = value;
    }

    /// <remarks />
    public string forbidden
    {
      get => forbiddenField;
      set => forbiddenField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string source
    {
      get => sourceField;
      set => sourceField = value;
    }

    /// <remarks />
    [XmlElement("transition")]
    public transition[] transition
    {
      get => transitionField;
      set => transitionField = value;
    }
  }
}