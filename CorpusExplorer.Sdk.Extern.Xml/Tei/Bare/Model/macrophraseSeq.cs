#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Tei.Bare.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(TypeName = "macro.phraseSeq", Namespace = "http://www.tei-c.org/ns/1.0")]
  public class macrophraseSeq
  {
    private modelphrase[] modelphraseField;
    private string[] textField;

    /// <remarks />
    [XmlElement("model.phrase")]
    public modelphrase[] modelphrase
    {
      get => modelphraseField;
      set => modelphraseField = value;
    }

    /// <remarks />
    [XmlText]
    public string[] Text
    {
      get => textField;
      set => textField = value;
    }
  }
}