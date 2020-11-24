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
  [XmlRoot("meta-information", Namespace = "", IsNullable = false)]
  public class metainformation
  {
    private string commentField;
    private string projectnameField;
    private referencedfile referencedfileField;
    private string transcriptionconventionField;
    private string transcriptionnameField;
    private udinformation[] udmetainformationField;

    /// <remarks />
    public string comment
    {
      get => commentField;
      set => commentField = value;
    }

    /// <remarks />
    [XmlElement("project-name")]
    public string projectname
    {
      get => projectnameField;
      set => projectnameField = value;
    }

    /// <remarks />
    [XmlElement("referenced-file")]
    public referencedfile referencedfile
    {
      get => referencedfileField;
      set => referencedfileField = value;
    }

    /// <remarks />
    [XmlElement("transcription-convention")]
    public string transcriptionconvention
    {
      get => transcriptionconventionField;
      set => transcriptionconventionField = value;
    }

    /// <remarks />
    [XmlElement("transcription-name")]
    public string transcriptionname
    {
      get => transcriptionnameField;
      set => transcriptionnameField = value;
    }

    /// <remarks />
    [XmlArray("ud-meta-information")]
    [XmlArrayItem("ud-information", IsNullable = false)]
    public udinformation[] udmetainformation
    {
      get => udmetainformationField;
      set => udmetainformationField = value;
    }
  }
}