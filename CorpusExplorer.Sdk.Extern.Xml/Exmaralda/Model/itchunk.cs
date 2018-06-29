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
  [XmlType(AnonymousType = true, Namespace = "http://tempuri.org/interlinear-text")]
  [XmlRoot("it-chunk", Namespace = "http://tempuri.org/interlinear-text", IsNullable = false)]
  public class itchunk
  {
    private string endsyncField;
    private string formatrefField;
    private link[] linkField;
    private run[] runField;
    private string startsyncField;
    private udattribute[] udinformationField;

    /// <remarks />
    [XmlAttribute("end-sync")]
    public string endsync
    {
      get => endsyncField;
      set => endsyncField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string formatref
    {
      get => formatrefField;
      set => formatrefField = value;
    }

    /// <remarks />
    [XmlElement("link")]
    public link[] link
    {
      get => linkField;
      set => linkField = value;
    }

    /// <remarks />
    [XmlElement("run")]
    public run[] run
    {
      get => runField;
      set => runField = value;
    }

    /// <remarks />
    [XmlAttribute("start-sync")]
    public string startsync
    {
      get => startsyncField;
      set => startsyncField = value;
    }

    /// <remarks />
    [XmlArray("ud-information")]
    [XmlArrayItem("ud-attribute", IsNullable = false)]
    public udattribute[] udinformation
    {
      get => udinformationField;
      set => udinformationField = value;
    }
  }
}