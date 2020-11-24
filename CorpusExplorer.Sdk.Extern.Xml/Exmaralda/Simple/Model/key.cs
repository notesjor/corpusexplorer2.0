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
  public class key
  {
    private string contentField;
    private string descriptionField;
    private font fontField;

    /// <remarks />
    public string content
    {
      get => contentField;
      set => contentField = value;
    }

    /// <remarks />
    public string description
    {
      get => descriptionField;
      set => descriptionField = value;
    }

    /// <remarks />
    public font font
    {
      get => fontField;
      set => fontField = value;
    }
  }
}