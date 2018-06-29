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
  public class praefix_block
  {
    private string getrenntField;

    private string[] praefixField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string getrennt
    {
      get => getrenntField;
      set => getrenntField = value;
    }

    /// <remarks />
    [XmlElement("praefix")]
    public string[] praefix
    {
      get => praefixField;
      set => praefixField = value;
    }
  }
}