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
  [XmlRoot("conversion-timeline", Namespace = "", IsNullable = false)]
  public class conversiontimeline
  {
    private conversiontli[] conversiontliField;

    /// <remarks />
    [XmlElement("conversion-tli")]
    public conversiontli[] conversiontli
    {
      get => conversiontliField;
      set => conversiontliField = value;
    }
  }
}