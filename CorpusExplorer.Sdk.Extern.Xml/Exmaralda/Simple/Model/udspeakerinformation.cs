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
  [XmlRoot("ud-speaker-information", Namespace = "", IsNullable = false)]
  public class udspeakerinformation
  {
    private udinformation[] udinformationField;

    /// <remarks />
    [XmlElement("ud-information")]
    public udinformation[] udinformation
    {
      get => udinformationField;
      set => udinformationField = value;
    }
  }
}