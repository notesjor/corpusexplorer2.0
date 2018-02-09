#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Talkbank.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "2.0.50727.3038")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.talkbank.org/ns/talkbank")]
  [XmlRoot(Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class otherSpokenEvent
  {
    private wordType wField;
    private string whoField;

    /// <remarks />
    public wordType w { get { return wField; } set { wField = value; } }

    /// <remarks />
    [XmlAttribute]
    public string who { get { return whoField; } set { whoField = value; } }
  }
}