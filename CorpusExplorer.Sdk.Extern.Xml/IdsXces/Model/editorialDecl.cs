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
  public class editorialDecl
  {
    private string defaultField;

    private pagination paginationField;

    private transduction[] transductionField;

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string Default
    {
      get => defaultField;
      set => defaultField = value;
    }

    /// <remarks />
    public pagination pagination
    {
      get => paginationField;
      set => paginationField = value;
    }

    /// <remarks />
    [XmlElement("transduction")]
    public transduction[] transduction
    {
      get => transductionField;
      set => transductionField = value;
    }
  }
}