#region

using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "2.0.50727.3038")]
  [Serializable]
  [XmlType(Namespace = "http://www.talkbank.org/ns/talkbank")]
  public enum optionType
  {
    /// <remarks />
    CA,

    /// <remarks />
    bullets,

    /// <remarks />
    heritage,

    /// <remarks />
    multi,

    /// <remarks />
    IPA,

    /// <remarks />
    sign,

    /// <remarks />
    caps
  }
}