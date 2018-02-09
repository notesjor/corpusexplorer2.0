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
  [XmlType(AnonymousType = true, Namespace = "http://www.talkbank.org/ns/talkbank")]
  public enum wordTypeFormType
  {
    /// <remarks />
    addition,

    /// <remarks />
    babbling,

    /// <remarks />
    [XmlEnum("child-invented")]
    childinvented,

    /// <remarks />
    dialect,

    /// <remarks />
    [XmlEnum("family-specific")]
    familyspecific,

    /// <remarks />
    [XmlEnum("filled pause")]
    filledpause,

    /// <remarks />
    [XmlEnum("filler syllable")]
    fillersyllable,

    /// <remarks />
    generic,

    /// <remarks />
    interjection,

    /// <remarks />
    kana,

    /// <remarks />
    letter,

    /// <remarks />
    neologism,

    /// <remarks />
    [XmlEnum("no voice")]
    novoice,

    /// <remarks />
    onomatopoeia,

    /// <remarks />
    [XmlEnum("phonology consistent")]
    phonologyconsistent,

    /// <remarks />
    [XmlEnum("proto-morpheme")]
    protomorpheme,

    /// <remarks />
    [XmlEnum("quoted metareference")]
    quotedmetareference,

    /// <remarks />
    [XmlEnum("sign speech")]
    signspeech,

    /// <remarks />
    singing,

    /// <remarks />
    [XmlEnum("signed language")]
    signedlanguage,

    /// <remarks />
    test,

    /// <remarks />
    UNIBET,

    /// <remarks />
    [XmlEnum("words to be excluded")]
    wordstobeexcluded,

    /// <remarks />
    [XmlEnum("word play")]
    wordplay
  }
}