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
  public class idsText
  {
    private idsHeader idsHeaderField;

    private text textField;

    private decimal versionField;

    /// <remarks />
    public idsHeader idsHeader
    {
      get => idsHeaderField;
      set => idsHeaderField = value;
    }

    /// <remarks />
    public text text
    {
      get => textField;
      set => textField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public decimal version
    {
      get => versionField;
      set => versionField = value;
    }
  }
}