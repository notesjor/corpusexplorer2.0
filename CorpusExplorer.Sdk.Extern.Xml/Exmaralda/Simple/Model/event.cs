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
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class @event
  {
    private string endField;
    private eventMedium mediumField;
    private bool mediumFieldSpecified;
    private string startField;
    private string[] textField;
    private udinformation[] udinformationField;
    private string urlField;

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string end
    {
      get => endField;
      set => endField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public eventMedium medium
    {
      get => mediumField;
      set => mediumField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool mediumSpecified
    {
      get => mediumFieldSpecified;
      set => mediumFieldSpecified = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string start
    {
      get => startField;
      set => startField = value;
    }

    /// <remarks />
    [XmlText]
    public string[] Text
    {
      get => textField;
      set => textField = value;
    }

    /// <remarks />
    [XmlElement("ud-information")]
    public udinformation[] udinformation
    {
      get => udinformationField;
      set => udinformationField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string url
    {
      get => urlField;
      set => urlField = value;
    }
  }
}