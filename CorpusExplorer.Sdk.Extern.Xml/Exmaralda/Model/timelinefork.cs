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
  [XmlRoot("timeline-fork", Namespace = "", IsNullable = false)]
  public class timelinefork
  {
    private string endField;
    private string startField;
    private tli[] tliField;

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string end { get { return endField; } set { endField = value; } }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string start { get { return startField; } set { startField = value; } }

    /// <remarks />
    [XmlElement("tli")]
    public tli[] tli { get { return tliField; } set { tliField = value; } }
  }
}