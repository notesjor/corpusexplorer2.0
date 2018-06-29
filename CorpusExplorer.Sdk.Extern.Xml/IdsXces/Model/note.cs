using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.IdsXces.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.81.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class note
  {
    private string idField;

    private p pField;

    private string placeField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string id
    {
      get => idField;
      set => idField = value;
    }

    /// <remarks />
    public p p
    {
      get => pField;
      set => pField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string place
    {
      get => placeField;
      set => placeField = value;
    }
  }
}