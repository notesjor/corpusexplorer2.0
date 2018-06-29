using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.DariahDe.GeoBrowser.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class TimeStamp
  {
    private string whenField;

    /// <remarks />
    [XmlElement(DataType = "integer")]
    public string when
    {
      get => whenField;
      set => whenField = value;
    }
  }
}