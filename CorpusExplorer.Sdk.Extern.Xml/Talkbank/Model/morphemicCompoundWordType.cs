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
  [XmlType(Namespace = "http://www.talkbank.org/ns/talkbank")]
  [XmlRoot("mwc", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class morphemicCompoundWordType
  {
    private morphemicPrefixType[] mpfxField;
    private morphemicWordType[] mwField;
    private posType posField;

    /// <remarks />
    [XmlElement("mpfx")]
    public morphemicPrefixType[] mpfx { get { return mpfxField; } set { mpfxField = value; } }

    /// <remarks />
    [XmlElement("mw")]
    public morphemicWordType[] mw { get { return mwField; } set { mwField = value; } }

    /// <remarks />
    public posType pos { get { return posField; } set { posField = value; } }
  }
}