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
  public class messageHead
  {
    private string modeField;
    private nickname nicknameField;

    /// <remarks />
    public string mode { get { return modeField; } set { modeField = value; } }

    /// <remarks />
    public nickname nickname { get { return nicknameField; } set { nicknameField = value; } }
  }
}