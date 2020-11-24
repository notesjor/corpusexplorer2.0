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
  [XmlRoot("timeline-item-format", Namespace = "", IsNullable = false)]
  public class timelineitemformat
  {
    private timelineitemformatAbsolutetimeformat absolutetimeformatField;
    private bool absolutetimeformatFieldSpecified;
    private string milisecondsdigitsField;
    private string showeverynthabsoluteField;
    private string showeverynthnumberingField;

    /// <remarks />
    [XmlAttribute("absolute-time-format")]
    public timelineitemformatAbsolutetimeformat absolutetimeformat
    {
      get => absolutetimeformatField;
      set => absolutetimeformatField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool absolutetimeformatSpecified
    {
      get => absolutetimeformatFieldSpecified;
      set => absolutetimeformatFieldSpecified = value;
    }

    /// <remarks />
    [XmlAttribute("miliseconds-digits")]
    public string milisecondsdigits
    {
      get => milisecondsdigitsField;
      set => milisecondsdigitsField = value;
    }

    /// <remarks />
    [XmlAttribute("show-every-nth-absolute")]
    public string showeverynthabsolute
    {
      get => showeverynthabsoluteField;
      set => showeverynthabsoluteField = value;
    }

    /// <remarks />
    [XmlAttribute("show-every-nth-numbering")]
    public string showeverynthnumbering
    {
      get => showeverynthnumberingField;
      set => showeverynthnumberingField = value;
    }
  }
}