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
  [XmlRoot("timeline-fork", Namespace = "", IsNullable = false)]
  public class timelinefork
  {
    private string endField;
    private string startField;
    private tli[] tliField;

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string end
    {
      get => endField;
      set => endField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string start
    {
      get => startField;
      set => startField = value;
    }

    /// <remarks />
    [XmlElement("tli")]
    public tli[] tli
    {
      get => tliField;
      set => tliField = value;
    }
  }
}