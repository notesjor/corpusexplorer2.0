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
  public class tier
  {
    private string categoryField;
    private string displaynameField;
    private @event[] eventField;
    private string idField;
    private string speakerField;
    private tierType typeField;
    private udinformation[] udtierinformationField;

    /// <remarks />
    [XmlAttribute]
    public string category
    {
      get => categoryField;
      set => categoryField = value;
    }

    /// <remarks />
    [XmlAttribute("display-name")]
    public string displayname
    {
      get => displaynameField;
      set => displaynameField = value;
    }

    /// <remarks />
    [XmlElement("event")]
    public @event[] @event
    {
      get => eventField;
      set => eventField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "ID")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "IDREF")]
    public string speaker
    {
      get => speakerField;
      set => speakerField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public tierType type
    {
      get => typeField;
      set => typeField = value;
    }

    /// <remarks />
    [XmlArray("ud-tier-information")]
    [XmlArrayItem("ud-information", IsNullable = false)]
    public udinformation[] udtierinformation
    {
      get => udtierinformationField;
      set => udtierinformationField = value;
    }
  }
}