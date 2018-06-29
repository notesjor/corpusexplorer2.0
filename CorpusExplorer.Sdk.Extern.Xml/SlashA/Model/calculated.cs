using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.SlashA.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.81.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.dspin.de/data/metadata")]
  [XmlRoot(Namespace = "http://www.dspin.de/data/metadata", IsNullable = false)]
  public class calculated
  {
    private string dateField;

    /// <remarks />
    [XmlAttribute]
    public string date
    {
      get => dateField;
      set => dateField = value;
    }
  }
}