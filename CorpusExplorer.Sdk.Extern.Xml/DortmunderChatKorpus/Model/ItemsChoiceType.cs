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
  [XmlType(IncludeInSchema = false)]
  public enum ItemsChoiceType
  {
    /// <remarks />
    address,

    /// <remarks />
    asteriskExpression,

    /// <remarks />
    emoticon,

    /// <remarks />
    img,

    /// <remarks />
    nickname,

    /// <remarks />
    roomname
  }
}