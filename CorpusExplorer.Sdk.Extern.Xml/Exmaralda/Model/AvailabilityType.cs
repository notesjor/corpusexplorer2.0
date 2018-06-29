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
  public class AvailabilityType
  {
    private bool availableField;
    private string copyrightField;
    private KeyType[] obtainingInformationField;
    private string[] uRLField;

    /// <remarks />
    public bool Available
    {
      get => availableField;
      set => availableField = value;
    }

    /// <remarks />
    public string Copyright
    {
      get => copyrightField;
      set => copyrightField = value;
    }

    /// <remarks />
    [XmlArrayItem("Key", IsNullable = false)]
    public KeyType[] ObtainingInformation
    {
      get => obtainingInformationField;
      set => obtainingInformationField = value;
    }

    /// <remarks />
    [XmlElement("URL", DataType = "anyURI")]
    public string[] URL
    {
      get => uRLField;
      set => uRLField = value;
    }
  }
}