#region

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#endregion

namespace CorpusExplorer.Sdk.Extern.Xml.Exmaralda.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.0.30319.33440")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot("segmented-transcription", Namespace = "", IsNullable = false)]
  public class segmentedtranscription
  {
    private conversioninfo conversioninfoField;
    private head headField;
    private segmentedbody segmentedbodyField;

    /// <remarks />
    [XmlElement("conversion-info")]
    public conversioninfo conversioninfo
    {
      get => conversioninfoField;
      set => conversioninfoField = value;
    }

    /// <remarks />
    [XmlElement("head")]
    public head head
    {
      get => headField;
      set => headField = value;
    }

    /// <remarks />
    [XmlElement("segmented-body")]
    public segmentedbody segmentedbody
    {
      get => segmentedbodyField;
      set => segmentedbodyField = value;
    }
  }
}