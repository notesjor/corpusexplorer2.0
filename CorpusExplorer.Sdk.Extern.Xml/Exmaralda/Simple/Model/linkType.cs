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
  public enum linkType
  {
    /// <remarks />
    aud,

    /// <remarks />
    vid,

    /// <remarks />
    img,

    /// <remarks />
    txt,

    /// <remarks />
    oth
  }
}