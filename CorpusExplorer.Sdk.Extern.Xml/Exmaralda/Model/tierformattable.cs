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
  [XmlRoot("tierformat-table", Namespace = "", IsNullable = false)]
  public class tierformattable
  {
    private referencedfile[] referencedfileField;
    private tierformat[] tierformatField;
    private timelineitemformat[] timelineitemformatField;

    /// <remarks />
    [XmlElement("referenced-file")]
    public referencedfile[] referencedfile
    {
      get => referencedfileField;
      set => referencedfileField = value;
    }

    /// <remarks />
    [XmlElement("tier-format")]
    public tierformat[] tierformat
    {
      get => tierformatField;
      set => tierformatField = value;
    }

    /// <remarks />
    [XmlElement("timeline-item-format")]
    public timelineitemformat[] timelineitemformat
    {
      get => timelineitemformatField;
      set => timelineitemformatField = value;
    }
  }
}