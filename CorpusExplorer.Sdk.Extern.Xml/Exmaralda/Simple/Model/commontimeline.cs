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
  [XmlRoot("common-timeline", Namespace = "", IsNullable = false)]
  public class commontimeline
  {
    private tli[] tliField;

    /// <remarks />
    [XmlElement("tli")]
    public tli[] tli
    {
      get => tliField;
      set => tliField = value;
    }
  }
}