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
  [XmlRoot("conversion-info", Namespace = "", IsNullable = false)]
  public class conversioninfo
  {
    private basictranscriptionconversioninfo basictranscriptionconversioninfoField;

    /// <remarks />
    [XmlElement("basic-transcription-conversion-info")]
    public basictranscriptionconversioninfo basictranscriptionconversioninfo
    {
      get { return basictranscriptionconversioninfoField; }
      set { basictranscriptionconversioninfoField = value; }
    }
  }
}