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
  [XmlRoot("list-body", Namespace = "", IsNullable = false)]
  public class listbody
  {
    private tli[] commontimelineField;
    private speakercontribution[] speakercontributionField;
    private timelinefork[] timelineforkField;

    /// <remarks />
    [XmlArray("common-timeline")]
    [XmlArrayItem("tli", IsNullable = false)]
    public tli[] commontimeline
    {
      get => commontimelineField;
      set => commontimelineField = value;
    }

    /// <remarks />
    [XmlElement("speaker-contribution")]
    public speakercontribution[] speakercontribution
    {
      get => speakercontributionField;
      set => speakercontributionField = value;
    }

    /// <remarks />
    [XmlElement("timeline-fork")]
    public timelinefork[] timelinefork
    {
      get => timelineforkField;
      set => timelineforkField = value;
    }
  }
}