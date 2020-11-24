#region

using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Simple.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [XmlType(AnonymousType = true, Namespace = "http://tempuri.org/interlinear-text")]
  public enum itlineBreaktype
  {
    /// <remarks />
    NB_TIME,

    /// <remarks />
    NB_NOTIME,

    /// <remarks />
    NB_DEP,

    /// <remarks />
    NB_LNK,

    /// <remarks />
    B,

    /// <remarks />
    IMG,

    /// <remarks />
    OTH
  }
}