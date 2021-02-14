#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Flk.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot("folker-transcription", Namespace = "", IsNullable = false)]
  public class folkertranscription
  {
    private contribution[] contributionField;
    private object headField;
    private recording recordingField;
    private speaker[] speakersField;
    private timepoint[] timelineField;

    /// <remarks />
    [XmlElement("contribution")]
    public contribution[] contribution
    {
      get => contributionField;
      set => contributionField = value;
    }

    /// <remarks />
    public object head
    {
      get => headField;
      set => headField = value;
    }

    /// <remarks />
    public recording recording
    {
      get => recordingField;
      set => recordingField = value;
    }

    /// <remarks />
    [XmlArrayItem("speaker", IsNullable = false)]
    public speaker[] speakers
    {
      get => speakersField;
      set => speakersField = value;
    }

    /// <remarks />
    [XmlArrayItem("timepoint", IsNullable = false)]
    public timepoint[] timeline
    {
      get => timelineField;
      set => timelineField = value;
    }
  }
}