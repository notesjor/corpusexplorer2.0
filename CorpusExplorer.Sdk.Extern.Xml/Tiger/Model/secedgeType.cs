#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tiger.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  public class secedgeType
  {
    private string idrefField;
    private string labelField;

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string idref
    {
      get => idrefField;
      set => idrefField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string label
    {
      get => labelField;
      set => labelField = value;
    }
  }
}