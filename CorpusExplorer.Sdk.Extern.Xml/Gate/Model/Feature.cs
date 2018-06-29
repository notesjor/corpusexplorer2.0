using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CorpusExplorer.Sdk.Extern.Xml.Gate.Model
{
  /// <remarks />
  [GeneratedCode("xsd", "4.6.1055.0")]
  [Serializable]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  [XmlRoot(Namespace = "", IsNullable = false)]
  public class Feature
  {
    private Name nameField;

    private Value valueField;

    /// <remarks />
    public Name Name
    {
      get => nameField;
      set => nameField = value;
    }

    /// <remarks />
    public Value Value
    {
      get => valueField;
      set => valueField = value;
    }
  }
}