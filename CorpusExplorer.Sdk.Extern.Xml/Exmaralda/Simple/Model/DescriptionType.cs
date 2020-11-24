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
  public class DescriptionType
  {
    private KeyType[] keyField;

    /// <remarks />
    [XmlElement("Key")]
    public KeyType[] Key
    {
      get => keyField;
      set => keyField = value;
    }
  }
}