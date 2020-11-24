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
  [XmlRoot("conversion-tier", Namespace = "", IsNullable = false)]
  public class conversiontier
  {
    private string categoryField;
    private string displaynameField;
    private string nameField;
    private string segmentedtieridField;
    private conversiontierType typeField;

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
    [XmlAttribute]
    public string name
    {
      get => nameField;
      set => nameField = value;
    }

    /// <remarks />
    [XmlAttribute("segmented-tier-id", DataType = "IDREF")]
    public string segmentedtierid
    {
      get => segmentedtieridField;
      set => segmentedtieridField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public conversiontierType type
    {
      get => typeField;
      set => typeField = value;
    }
  }
}