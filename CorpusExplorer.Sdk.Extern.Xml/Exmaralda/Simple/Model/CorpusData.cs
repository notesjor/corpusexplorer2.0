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
  public class CorpusData
  {
    private object[] itemsField;

    /// <remarks />
    [XmlElement("Communication", typeof(CommunicationType))]
    [XmlElement("Speaker", typeof(PersonType))]
    public object[] Items
    {
      get => itemsField;
      set => itemsField = value;
    }
  }
}