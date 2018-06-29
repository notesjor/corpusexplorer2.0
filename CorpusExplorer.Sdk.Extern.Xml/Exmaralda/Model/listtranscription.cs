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
  [XmlRoot("list-transcription", Namespace = "", IsNullable = false)]
  public class listtranscription
  {
    private head headField;
    private listbody listbodyField;

    /// <remarks />
    public head head
    {
      get => headField;
      set => headField = value;
    }

    /// <remarks />
    [XmlElement("list-body")]
    public listbody listbody
    {
      get => listbodyField;
      set => listbodyField = value;
    }
  }
}