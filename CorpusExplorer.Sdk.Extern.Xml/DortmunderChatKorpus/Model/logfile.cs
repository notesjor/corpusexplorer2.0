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
  public class logfile
  {
    private message[] bodyField;
    private head headField;

    /// <remarks />
    [XmlArrayItem("message", IsNullable = false)]
    public message[] body
    {
      get => bodyField;
      set => bodyField = value;
    }

    /// <remarks />
    public head head
    {
      get => headField;
      set => headField = value;
    }
  }
}