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
  public class window
  {
    private string edateField;

    private string sdateField;

    /// <remarks />
    [XmlAttribute]
    public string edate
    {
      get => edateField;
      set => edateField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string sdate
    {
      get => sdateField;
      set => sdateField = value;
    }
  }
}