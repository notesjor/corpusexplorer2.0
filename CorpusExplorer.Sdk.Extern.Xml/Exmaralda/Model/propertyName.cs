#region

using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [XmlType(AnonymousType = true)]
  public enum propertyName
  {
    /// <remarks />
    [XmlEnum("font-color")] fontcolor,

    /// <remarks />
    [XmlEnum("bg-color")] bgcolor,

    /// <remarks />
    [XmlEnum("font-size")] fontsize,

    /// <remarks />
    [XmlEnum("font-name")] fontname,

    /// <remarks />
    frame,

    /// <remarks />
    [XmlEnum("font-face")] fontface,

    /// <remarks />
    [XmlEnum("chunk-border")] chunkborder,

    /// <remarks />
    [XmlEnum("chunk-border-color")] chunkbordercolor,

    /// <remarks />
    [XmlEnum("chunk-border-style")] chunkborderstyle,

    /// <remarks />
    [XmlEnum("text-alignment")] textalignment,

    /// <remarks />
    [XmlEnum("row-height-calculation")] rowheightcalculation,

    /// <remarks />
    [XmlEnum("fixed-row-height")] fixedrowheight
  }
}