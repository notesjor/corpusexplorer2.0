#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.DortmunderChatKorpus.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class head
  {
    private creator[] creatorListField;
    private record recordField;
    private revision[] revisionHistoryField;

    /// <remarks />
    [XmlArrayItem("creator", IsNullable = false)]
    public creator[] creatorList
    {
      get => creatorListField;
      set => creatorListField = value;
    }

    /// <remarks />
    public record record
    {
      get => recordField;
      set => recordField = value;
    }

    /// <remarks />
    [XmlArrayItem("revision", IsNullable = false)]
    public revision[] revisionHistory
    {
      get => revisionHistoryField;
      set => revisionHistoryField = value;
    }
  }
}