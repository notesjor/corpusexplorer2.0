using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.BonnerFruehneuhochdeutschkorpus.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class Landschaft
  {
    private string ortField;

    private Sprachraum sprachraumField;

    /// <remarks />
    public string Ort
    {
      get => ortField;
      set => ortField = value;
    }

    /// <remarks />
    public Sprachraum Sprachraum
    {
      get => sprachraumField;
      set => sprachraumField = value;
    }
  }
}