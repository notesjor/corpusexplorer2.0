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
  public class bibl
  {
    private string authorField;

    private string defaultField;

    private title titleField;

    /// <remarks />
    public string author
    {
      get => authorField;
      set => authorField = value;
    }

    /// <remarks />
    [XmlAttribute(DataType = "NCName")]
    public string Default
    {
      get => defaultField;
      set => defaultField = value;
    }

    /// <remarks />
    public title title
    {
      get => titleField;
      set => titleField = value;
    }
  }
}