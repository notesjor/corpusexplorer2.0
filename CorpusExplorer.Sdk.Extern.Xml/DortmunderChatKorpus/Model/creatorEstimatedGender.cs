#region

using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.DortmunderChatKorpus.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [XmlType(AnonymousType = true)]
  public enum creatorEstimatedGender
  {
    /// <remarks />
    male,

    /// <remarks />
    female,

    /// <remarks />
    system,

    /// <remarks />
    bot,

    /// <remarks />
    unknown
  }
}