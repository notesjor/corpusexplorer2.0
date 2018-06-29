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
  [XmlRoot("mw", Namespace = "http://www.talkbank.org/ns/talkbank", IsNullable = false)]
  public class morphemicWordType
  {
    private morphemic_marker[] mkField;
    private morphemicPrefixType[] mpfxField;
    private posType posField;
    private string stemField;

    /// <remarks />
    [XmlElement("mpfx")]
    public morphemicPrefixType[] mpfx
    {
      get => mpfxField;
      set => mpfxField = value;
    }

    /// <remarks />
    [XmlElement("mk")]
    public morphemic_marker[] mk
    {
      get => mkField;
      set => mkField = value;
    }


    /// <remarks />
    public posType pos
    {
      get => posField;
      set => posField = value;
    }

    /// <remarks />
    public string stem
    {
      get => stemField;
      set => stemField = value;
    }
  }
}