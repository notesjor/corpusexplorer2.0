#region

using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Folker.Flk.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [XmlType(AnonymousType = true)]
  public enum phraseType
  {
    /// <remarks />
    [XmlEnum("intonation-phrase")] intonationphrase,

    /// <remarks />
    fragment,

    /// <remarks />
    unaccentuated
  }
}