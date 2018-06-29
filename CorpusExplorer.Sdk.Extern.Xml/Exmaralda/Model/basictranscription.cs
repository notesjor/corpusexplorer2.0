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
  [XmlRoot("basic-transcription", Namespace = "", IsNullable = false)]
  public class basictranscription
  {
    private basicbody basicbodyField;
    private head headField;
    private string idField;
    private tierformattable tierformattableField;

    /// <remarks />
    [XmlElement("basic-body")]
    public basicbody basicbody
    {
      get => basicbodyField;
      set => basicbodyField = value;
    }

    /// <remarks />
    [XmlElement("head")]
    public head head
    {
      get => headField;
      set => headField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string Id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    [XmlElement("tierformat-table")]
    public tierformattable tierformattable
    {
      get => tierformattableField;
      set => tierformattableField = value;
    }
  }
}