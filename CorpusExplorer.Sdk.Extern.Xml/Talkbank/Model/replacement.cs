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
  public class replacement
  {
    private bool realField;
    private bool realFieldSpecified;
    private wordType[] wField;

    /// <remarks />
    [XmlAttribute]
    public bool real
    {
      get => realField;
      set => realField = value;
    }

    /// <remarks />
    [XmlIgnore]
    public bool realSpecified
    {
      get => realFieldSpecified;
      set => realFieldSpecified = value;
    }

    /// <remarks />
    [XmlElement("w")]
    public wordType[] w
    {
      get => wField;
      set => wField = value;
    }
  }
}