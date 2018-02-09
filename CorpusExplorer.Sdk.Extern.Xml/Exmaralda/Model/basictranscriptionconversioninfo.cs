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
  [XmlRoot("basic-transcription-conversion-info", Namespace = "", IsNullable = false)]
  public class basictranscriptionconversioninfo
  {
    private conversiontier[] conversiontierField;
    private conversiontli[] conversiontimelineField;

    /// <remarks />
    [XmlElement("conversion-tier")]
    public conversiontier[] conversiontier { get { return conversiontierField; } set { conversiontierField = value; } }

    /// <remarks />
    [XmlArray("conversion-timeline")]
    [XmlArrayItem("conversion-tli", IsNullable = false)]
    public conversiontli[] conversiontimeline
    {
      get { return conversiontimelineField; }
      set { conversiontimelineField = value; }
    }
  }
}